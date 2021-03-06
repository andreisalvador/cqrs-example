# CQRS

### História

CQRS é um padrão muito simples que permite muitas oportunidades de arquitetura que, de outra forma, poderiam não existir. O nome é uma sigla para "**C**ommand **Q**uery **R**esponsibility **S**egregation" foi adotado por Greg Young em 2010, porém o conceito já existia a muito tempo.


### Conceito básico

Em seu cerne está a noção de que você pode usar um modelo diferente para atualizar informações do modelo que você usa para ler informações.

Modelo padrão:

![Imagem de modelo crud](https://martinfowler.com/bliki/images/cqrs/single-model.png)

Modelo com CQRS:

![Imagem de modelo CQRS](https://martinfowler.com/bliki/images/cqrs/cqrs.png)


### Como fuciona

Basicamente, o CQRS afirma que as operações que acionam as transições de estado devem ser descritas como comandos e qualquer recuperação de dados que vai além da necessidade de execução do comando deve ser chamada de query. Como os requisitos operacionais para a execução de comandos e consultas são frequentemente diferentes, os desenvolvedores devem considerar o uso de diferentes técnicas de persistência para lidar com comandos e queries, portanto, segregando-os.

É possível criar modelos de dados in-memory que podem compartilhar o mesmo banco de dados, caso em que o banco de dados atua como a comunicação entre os dois modelos. No entanto, eles também podem usar bancos de dados separados, tornando o banco de dados do lado da consulta um ReportingDatabase em tempo real. Nesse caso, deve haver algum mecanismo de comunicação entre os dois modelos ou seus bancos de dados.

Exemplo com banco in-memory:

![Imagem do modelo com banco in-memory](https://www.eduardopires.net.br/wp-content/uploads/2016/07/CQRS_FluxoSimples.jpg)



### Referências

https://udidahan.com/2009/12/09/clarified-cqrs/

https://martinfowler.com/bliki/CQRS.html

https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs

http://codebetter.com/gregyoung/2010/02/16/cqrs-task-based-uis-event-sourcing-agh
