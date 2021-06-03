# dotnet-tests-code-coverage
Cobertura de código nos testes de uma aplicação .NET

## Referências

- [Cobertura de Testes com Coverlet](https://renatogroffe.medium.com/net-5-cobertura-de-testes-com-coverlet-7cbec2f052d9)
- [Coverlet Documentação](https://github.com/coverlet-coverage/coverlet)
- [POSTMAN: Dynamic Variables](https://learning.postman.com/docs/writing-scripts/script-references/variables-list/)
- [Running collections on the command line with Newman](https://learning.postman.com/docs/running-collections/using-newman-cli/command-line-integration-with-newman/)
- [](https://renatogroffe.medium.com/automatizando-testes-de-apis-rest-com-postman-newman-a90f0d90df09)

## Rodando Testes de Integração via Newman

```bash
newman run tests/SampleApp.Integration.Tests/integration-tests.json -e tests/SampleApp.Integration.Tests/local.environment.json --insecure
```
