
# Duffnization

Código criado para teste de conhecimentos técnicos da empresa KarHub


## Duffnization.CRUD.API

API em NodeJS responsável por realizar o CRUD de estilos de cerveja.
## Duffnization.API

API em .NET 6 (C#) responsável por:
- Realizar consultar os estilos de cerveja na API de CRUD
- Identificar qual estilo  mais adequado dada uma determinada temperatura.
- Identificar playlists com o nome do estilo de cerveja e escolher uma randomicamente.

## Instalação ambiente desenvolvimento

- Pré-requisitos
    
    [Visual Studio 2019 or mais atual](https://visualstudio.microsoft.com/pt-br/vs/community/)
    
    [NodeJS v18.12.1](https://nodejs.org/dist/v18.12.1/node-v18.12.1-x64.msi) 

    [Docker Desktop](https://www.docker.com/get-started/)

    [Imagem Docker Sql Server](https://hub.docker.com/_/microsoft-mssql-server)

    [Python 3.11.1](https://www.python.org/downloads/release/python-3111/)

    [Git 2.38.1 ou mais atual](https://git-scm.com/downloads)

    [Azure Data Studio](https://azure.microsoft.com/pt-br/products/data-studio/) ou Sql Management Express
   

- Configurando

      Instale as ferramentas de pré-requisitos e reinicie o PC

  *1. Baixando os fontes*      

       1.1 Crie um diretório para armazenar os fontes, por exemplo: C:\Trabalho\Duffnization*
       1.2 Abra o Prompt de Comando em modo administrador e navegue até o diretório criado
       1.3 Clone o repositório (git clone https://github.com/humbertopalaia/duffnization.git)

  *2. Banco de dados*

        2.1 Através do docker suba um container com o banco de dados Sql Server
        2.2 Crie um novo banco de dados de nome Duffnization
        2.3 Conecte no banco de dados com um usuário master
        2.4 Execute o script CREATEDATABASE.sql localizado na pasta Script na raiz do diretório clonado

  *3. Baixando pacotes Duffnization.CRUD.API (NodeJS)*

        1. Entre na subpasta Duffnization.CRUD.API e digite o comando npm install   

- Executando
    
    - Duffnization.CRUD.API (NodeJS)
        
          1. Abra o Visual Studio Code ou editor de sua preferência em modo administrador
          2. Abra a pasta do projeto Duffnization.CRUD.API
          3. No arquivo .env localizado no diretório da aplicação, configure as credenciais de acesso 
          e o caminho do banco de dados instalado via docker.
          3. No terminal, execute o comando "npm start", sem as aspas

          
           OBS: Por default, a aplicação irá rodar na porta 8000, caso por algum motivo precise alterar, 
           a configuração estão no arquivo .env na raiz da aplicação

    - Duffnization.API (C# .NET 6)
        
          1. Abrir o Visual Studio em modo administrador
          2. Abrir a solution Duffnization.API.sln localizada no subdiretório "Duffnization.API\Duffnization.API"
          3. Execute um Rebuild da solução
          4. Execute o projeto o projeto Duffnization.API

           OBS: Por default a url de acesso a API de CRUD está configurada para localhost:8000, caso necessário, 
           pode ser alterado no appsettings.json da aplicação na chave "CRUD:BaseURL"


## Deploy

- Duffnization.API (C# .NET 6)

    **Ambiente Windows x64**
    
      dotnet publish -o deploy -f net6.0 -r win-x64 -c Release --self-contained true

    **Ambiente Windows x86 (NÃO RECOMENDADO)**

      dotnet publish -o deploy -f net6.0 -r win-x86 -c Release --self-contained true

    **Ambiente Linux x64**
        
        dotnet publish -o deploy -f net6.0 -r linux-x64 -c Release --self-contained true


- Duffnization.CRUD.API (NodeJS)

    npm run deploy


