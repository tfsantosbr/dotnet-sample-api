# .NET Complete Sample API

Cobertura de código nos testes de uma aplicação .NET

## Implementações

- CQRS Pattern
- Notification Pattern
- Testes unitários
- Testes de Integração
- Cobertura de Testes
- Testes de Carga
- Docker
- CI/CD com Github Actions

## Referências

- [CQRS Pattern](https://github.com/tfsantosbr/dotnet-cqrs-pattern)
- [Notification Pattern](https://github.com/tfsantosbr/dotnet-notification-pattern)
- [Cobertura de Testes com Coverlet](https://renatogroffe.medium.com/net-5-cobertura-de-testes-com-coverlet-7cbec2f052d9)
- [Coverlet Documentação](https://github.com/coverlet-coverage/coverlet)
- [POSTMAN: Dynamic Variables](https://learning.postman.com/docs/writing-scripts/script-references/variables-list/)
- [Running collections on the command line with Newman](https://learning.postman.com/docs/running-collections/using-newman-cli/command-line-integration-with-newman/)
- [Automatizando testes de APIs REST com Postman + Newman](https://renatogroffe.medium.com/automatizando-testes-de-apis-rest-com-postman-newman-a90f0d90df09)
- [K6 Testes de Carga](https://k6.io/)

## Testes Unitários

Executando os testes unitários:

```bash
dotnet test ./tests/SampleApp.Tests --verbosity minimal --logger:"html;LogFileName=tests-results.html" --collect:"XPlat Code Coverage"
```

## Migrations

You will need [.NET EF Tools](https://docs.microsoft.com/en-us/ef/core/cli/dotnet) to run this commands

```bash
# add migration
dotnet ef migrations add <MIGRATION_NAME> -p src/SampleApp.Infra/ -c SampleAppContext -s src/SampleApp.Api -o Contexts/Migrations

# remove migration
dotnet ef migrations remove -p src/SampleApp.Infra/ -c SampleAppContext -s src/SampleApp.Api

# update database
dotnet ef database update -p src/SampleApp.Infra -c SampleAppContext -s src/SampleApp.Api

# generate scripts for manual database update
dotnet ef migrations script -p src/SampleApp.Infra/ -c SampleAppContext -s src/SampleApp.Api -o ./scripts/migrations.sql
```

## Cobertura de Testes

Instalando a ferramenta de geração de relatório globalmente:

```bash
dotnet tool install --global dotnet-reportgenerator-globaltool
```

Gerando o relatório:

```bash
cd ./tests/SampleApp.Tests/TestResults
cd $(ls -d */|head -n 1)
reportgenerator "-reports:coverage.cobertura.xml" "-targetdir:coveragereport" -reporttypes:Html
```

## Testes Integrados

Instalando a ferramenta newman para gerar os testes integrados:

```bash
npm install -g newman
```

Executando os testes integrados

```bash
newman run tests/SampleApp.Integration.Tests/integration-tests.json -e tests/SampleApp.Integration.Tests/environments/docker.environment.json --insecure
```

## Testes de Carga

Instalando a ferramenta de testes de Carga K6:

- [K6 Guia de Instalação](https://k6.io/docs/getting-started/installation)

Executando os Testes de Carga:

```bash
k6 run -e HOSTNAME=https://localhost:5001 tests/SampleApp.Load.Tests/script.js
```
