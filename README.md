# 🛡️ Seguros - Teste Técnico INDT

Este projeto simula uma plataforma de seguros, com foco em boas práticas de arquitetura de software, microsserviços, mensageria, testes automatizados e uso de Docker.

---

## 📌 Visão Geral

A aplicação é composta por dois microserviços:

### 1. PropostaService
Responsável por:
- Criar propostas de seguro
- Listar propostas
- Alterar status da proposta (Em Análise, Aprovada, Rejeitada)
- Expor API REST

### 2. ContratacaoService
Responsável por:
- Contratar uma proposta (somente se Aprovada)
- Armazenar informações da contratação (ID da proposta, data de contratação)
- Consumir eventos via fila (RabbitMQ)
- Listar todas as contratações
- Expor API REST

---

## 🧰 Tecnologias Utilizadas

- ✅ .NET 8 + C#
- ✅ ASP.NET Core
- ✅ Entity Framework Core
- ✅ SQL Server (via Docker)
- ✅ RabbitMQ (via Docker)
- ✅ MassTransit
- ✅ Arquitetura Hexagonal (Ports & Adapters)
- ✅ Clean Architecture + DDD + SOLID
- ✅ Testes: xUnit + Moq + FluentAssertions
- ✅ Docker + Docker Compose

---

## 🐳 Como Executar o Projeto

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Docker](https://www.docker.com/)

### Subindo os serviços

1. Clone o repositório:

```bash
git clone https://github.com/AlisonMartins01/Seguros.git
cd seguros
```

2. Suba os serviços com Docker Compose:

```bash
docker-compose up -d
```

3. Acesse:

- PropostaService: [http://localhost:5088/swagger](http://localhost:5088/swagger)
- RabbitMQ: [http://localhost:15672](http://localhost:15672) (user: `guest`, pass: `guest`)

---

## 🧪 Rodando os Testes
# Rodar todos os testes (unitários e de integração de todos os serviços)
```bash
dotnet test
```

Os testes cobrem a criação de propostas via API REST utilizando `WebApplicationFactory`, mocks com `Moq`, e verificação de respostas HTTP.

---

## 📂 Estrutura de Pastas

```
/src
  /PropostaService
    /API
    /Application
    /Domain
    /Infrastructure
  /ContratacaoService
    /API
    /Application
    /Domain
    /Infrastructure
  /Seguro.Contracts
    /Events
  /Tests
    /ContratacaoService.IntegrationTest
    /ContratacaoServices.Tests
    /PropostaService.IntegrationTests
    /PropostaServices.Tests
/docker-compose.yml
```

---

## 📄 Principais Endpoints

### 🔹 Propostas

- `POST /Propostas` – Criar nova proposta
- `GET /Propostas` – Listar propostas
- `PATCH /Propostas/{id}/status` – Atualizar status (Aprovada, Rejeitada)

### 🔸 Contratação
- `GET /Contratacoes` – Listar contratações

---

## 🗺️ Diagrama da Arquitetura (simplificado)

```
+-------------------+             +-----------------------+
|  PropostaService  |---fila--->  |  ContratacaoService   |
| (API REST)        |             | (Consumer + Storage)  |
+-------------------+             +-----------------------+
```

---

## 👤 Autor

Desenvolvido por **Alison Martins**  
[GitHub](https://github.com/AlisonMartins01) • [LinkedIn](https://www.linkedin.com/in/alison-martins-9785aa186/)

---

## 📝 Licença

Este projeto foi desenvolvido exclusivamente para fins de avaliação técnica.