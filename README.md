# microservice-users
Projeto desenvolvido como pré-requisito do processo de recrutamento e seleção para Desenvolvedor .Net - Junto Seguros. O projeto em questão implementa um microserviço para o gerenciamento de usuários. Para persistir e recuperar dados, utilizou-se o banco de dados Microsoft SQL Server juntamente ao Entity Framework – adotando a técnica de modelagem Code First. Empregou-se também o design de software orientado à domínio (DDD) juntamente à técnicas de Clean Architecture/Code a fim de estabelecer limites arquiteturais bem definidos. 

## Arquitetura

![Arquitetura](https://github.com/erickerate/microservice-users/blob/main/assets/Arquitetura.png)

## Requisitos
* Docker Desktop
* .Net 8 SDK

## Executar
As etapas a serem executadas são:
1. Clonar este repositório: `gh repo clone erickerate/microservice-users`
2. cd na pasta: `cd microservice-users/src`
3. Correr `docker compose up`
4. Abra seu navegador em:
   - Microserviço `localhost:5000`
   - Prometheus `localhost:5500`
   - Grafana `localhost:3000`

## Autenticação
Para efetuar a autenticação, obtenha o token através do endpoint `UserAuth`. Pode-se obter este token através de um usuário cadastrado ou usuário administrador `admin@juntoseguros.com.br`, previamente cadastrado. Uma vez obtido o token, deve-se autorizar utilizando a sintaxe "Bearer {token}".

## Observabilidade

Prometheus
![Prometheus](https://github.com/erickerate/microservice-users/blob/main/assets/Prometheus.png)

Grafana
![Grafana](https://github.com/erickerate/microservice-users/blob/main/assets/Grafana.png)

Login Grafana:
`admin`
`@admin`

## Obrigado!
