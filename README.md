**Criar as Pasta com o comando abaixo:**

```bash
mkdir dojo

cd dojo

mkdir src

cd src
```

**Criar solução**

```bash
dotnet new sln --name Api
```

**Criar camada de Aplicação**

```bash
dotnet new webapi -n Application -o Api.Application

dotnet sln add Api.Application

dotnet build
```

**Abrir o VS Code**

```bash
cd ..

code .
```

```bash
cd src
```

**Criar a Camada de Dominio**

```bash
dotnet new classlib -n Domain -o Api.Domain
dotnet sln add Api.Domain
dotnet build
```

**Criar a Camada de Data**

```bash
dotnet new classlib -n Data -o Api.Data
dotnet sln add Api.Data
```

**Criar a Camada de Service**

```bash
dotnet new classlib -n Service -o Api.Service
dotnet sln add Api.Service
```

**Referências**

```bash
dotnet add Api.Application reference Api.Domain
dotnet add Api.Application reference Api.Service

dotnet add Api.Data reference Api.Domain

dotnet add Api.Service reference Api.Domain
dotnet add Api.Service reference Api.Data
```

Api.Data - Instalação Pacotes Entity Framework

**Para instalar precisar estar dentro da Pasta Api.Data**

```bash
cd Api.Data

dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Pomelo.EntityFrameworkCore.MySql

dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.SqlServer.Design
```
