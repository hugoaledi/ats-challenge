# ATS-Challenge

# Projeto criado para demonstrar CRUD de vagas de trabalho utilizando .Net core, modelagem DDD, banco de dados MS SQL Server no backend e no frontend Angular e PO-UI.


### Pré-requisitos

Antes de começar, você vai precisar ter instalado em sua máquina as seguintes ferramentas:
.Net Core (versão 3.1), MS SQL Server e Angular (versão 10.0.6). 

# Clone este repositório
$ git clone <https://github.com/hugoaledi/ats-challenge>

### Rodando o Back End

# Configure a string de conexão com o banco de dados (MS SQL Server)
> Acesse a pasta onde o projeto foi clonado/backend/ATSChallenge.Application
> Edite o arquivo appsettings.Development.json
> Altere o parâmetro "Connection" com sua string de conexão
> Salve o arquivo

# Acesse a pasta onde o projeto foi clonado no terminal/cmd
$ cd ats-challenge

# Vá para a pasta server
$ cd backend/src

# Compile a aplicação
$ dotnet build

# Vá para a pasta principal
$ cd ATSChallenge.Application

# Execute a aplicação em modo de desenvolvimento
$ dotnet run

# O servidor inciará na porta:5000 - acesse <http://localhost:5000>


### Rodando o Front End
# Acesse a pasta onde o projeto foi clonado no terminal/cmd
$ cd ats-challenge

# Vá para a pasta server
$ cd frontend

# Instale as dependências
$ npm install

# Execute a aplicação em modo de desenvolvimento
$ ng serve

# O servidor inciará na porta:4200 - acesse <http://localhost:4200>
