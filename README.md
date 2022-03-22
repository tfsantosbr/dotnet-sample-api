# .NET Complete Sample API

Cobertura de código nos testes de uma aplicação .NET

## Implementações

- CQRS Pattern
- Notification Pattern
- Testes unitários
- Testes de Integração
- Docker
- Cobertura de Testes
- CI/CD com Github Actions

## Referências

- [CQRS Pattern](https://github.com/tfsantosbr/dotnet-cqrs-pattern)
- [Notification Pattern](https://github.com/tfsantosbr/dotnet-notification-pattern)
- [Cobertura de Testes com Coverlet](https://renatogroffe.medium.com/net-5-cobertura-de-testes-com-coverlet-7cbec2f052d9)
- [Coverlet Documentação](https://github.com/coverlet-coverage/coverlet)
- [POSTMAN: Dynamic Variables](https://learning.postman.com/docs/writing-scripts/script-references/variables-list/)
- [Running collections on the command line with Newman](https://learning.postman.com/docs/running-collections/using-newman-cli/command-line-integration-with-newman/)
- [Automatizando testes de APIs REST com Postman + Newman](https://renatogroffe.medium.com/automatizando-testes-de-apis-rest-com-postman-newman-a90f0d90df09)

## Comandos para executar os Testes Unitários

```bash
dotnet test ./tests/SampleApp.Tests --verbosity minimal --logger:"html;LogFileName=tests-results.html" --collect:"XPlat Code Coverage"
```

## Gerar relatório de Cobertura de Testes

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

## Comandos para Rodar os Testes Integrados

Instalando a ferramenta newman para gerar os testes integrados:

```bash
npm install -g newman
```

Executando os testes integrados

```bash
newman run tests/SampleApp.Integration.Tests/integration-tests.json -e tests/SampleApp.Integration.Tests/environments/docker.environment.json --insecure
```
