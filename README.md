# microservice-users
Projeto desenvolvido como pré-requisito do processo de recrutamento e seleção para Desenvolvedor .Net - Junto Seguros.

## Requisitos
* Docker Desktop
* .Net 8 SDK

## Executar
As etapas a serem executadas são:
1. Clonar este repositório: `gh repo clone erickerate/microservice-users`
2. cd na pasta: `cd microservice-users/src`
3. Correr `docker compose up`
4. Abra seu navegador e navegue até:
   - Microserviço `localhost:5000`
   - Prometheus `localhost:5500`
   - Grafana `localhost:3000`

## Autenticação
Para efetuar a autenticação, obtenha o token através do endpoint `UserAuth`. Pode-se obter este token através de um usuário cadastrado ou usuário administrador `admin@juntoseguros.com.br`, previamente cadastrado. Uma vez obtido o token, deve-se autorizar utilizando a sintaxe "Bearer {token}".

## Obrigado!
