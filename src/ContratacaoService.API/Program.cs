using ContratacaoService.Application.Consumers;
using ContratacaoService.Application.Services.Interfaces;
using ContratacaoService.Infrastructure.Persistence;
using ContratacaoService.Infrastructure.Repository;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ContratacaoService.Domain.Repository;
using ContratacaoService.Application.Interfaces;
using ContratacaoService.Application.UseCase;
using ContratacaoService.Infrastructure.Extensions;

public partial class Program {
    public static void Main(string[] args) {

        var builder = WebApplication.CreateBuilder(args);
        if (!builder.Environment.IsEnvironment("Testing"))
        {
            builder.Services.AddDatabase(builder.Configuration);
        }
        //builder.Services.AddDatabase(builder.Configuration);

        builder.Services.AddMassTransit(x =>
        {
            x.AddConsumer<PropostaAprovadaConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("rabbitmq", "/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.ReceiveEndpoint("proposta-aprovada-queue", e =>
                {
                    e.ConfigureConsumer<PropostaAprovadaConsumer>(context);
                });
            });
        });
        builder.Services.AddScoped<IContratacaoService, ContratacaoService.Application.Services.ContratacaoService>();
        builder.Services.AddScoped<IContratacaoRepository, ContratacaoRepository>();
        builder.Services.AddScoped<IContratarPropostaUseCase, ContratarPropostaUseCase>();
        builder.Services.AddScoped<IListarContratacoesUseCase, ListarContratacoesUseCase>();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Contratacao API", Version = "v1" });
        });


        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contratacao API V1");
            });
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        using (var scope = app.Services.CreateScope())
        {
            try
            {
                var db = scope.ServiceProvider.GetRequiredService<ContratacaoDbContext>();
                if (db.Database.IsRelational())
                {
                    db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "Erro ao aplicar as migrations.");
                throw; // para evitar rodar a API sem banco
            }
        }

        app.Run();
    }
}

