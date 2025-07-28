using PropostaServices.Application.UseCases;
using PropostaServices.Domain.Interfaces;
using PropostaServices.Infrastructure.Persistence;
using PropostaServices.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using MassTransit;
using PropostaServices.Infrastructure.Extensions;
using PropostaServices.Application.Services;
using PropostaServices.Application.Services.Interfaces;
using PropostaServices.Application.Interfaces;


public partial class Program {
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddScoped<ICriarPropostaUseCase, CriarPropostaUseCase>();
        builder.Services.AddScoped<IListarPropostasUseCase, ListarPropostasUseCase>();
        builder.Services.AddScoped<IAlterarStatusPropostaUseCase, AlterarStatusPropostaUseCase>();
        builder.Services.AddScoped<IPropostaRepository, PropostaRepository>();
        builder.Services.AddScoped<IPropostaService, PropostaService>();
        
        
        if (!builder.Environment.IsEnvironment("Testing"))
        {
            builder.Services.AddDatabase(builder.Configuration);

            builder.Services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host("rabbitmq", "/", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });
                });
            });
        }
        

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<PropostaDbContext>();
            try
            {
                if (db.Database.IsRelational())
                {
                    db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }


        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}
