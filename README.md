_Repositório apenas para estudo_

# Uma arquitetura, em ASP.Net Core, baseada nos princípios do DDD

Adaptado para .NET 5

Instrutor:

- [Marcos Fabricio Rosa](https://github.com/MarcosRosaSage)

Referências:

- https://github.com/MarcosRosaSage/curso_aspnetcore/blob/master/ApresentacaoAspNetCore2.2.pdf
- https://github.com/MarcosRosaSage/curso_aspnetcore
- https://alexalvess.medium.com/criando-uma-api-em-net-core-baseado-na-arquitetura-ddd-2c6a409c686

<br>
<br>
<hr>

**Criar as Pasta com o comando abaixo:**

```bash
mkdir Api-DDD

cd Api-DDD

mkdir src
```

**Abrir o VS Code**

```bash
code .
```

**Abrir o terminal acessar /src**

```bash
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

**Criar Referências**

```bash
dotnet add Api.Application reference Api.Domain
dotnet add Api.Application reference Api.Service

dotnet add Api.Data reference Api.Domain

dotnet add Api.Service reference Api.Domain
dotnet add Api.Service reference Api.Data
```

Api.Data - Instalação Pacotes EntityFramework

**Para instalar precisar estar dentro da Pasta Api.Data**

```bash
cd Api.Data

dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL // Não usei MySQL
```

Para poder rodar comando no CLI, adicionar no arquivo `src\Api.Data\Data.csproj`

```xml
<ItemGroup>
  <DotNetCliToolReference Include="Microsoft.EntityFrameworkCore.Tools.dotnet " Version="2.0.3" />
</ItemGroup>
```

Para restaurar todos os pacotes

```bash
dotnet restore
```

**Entity Framework Migrations**

```bash
dotnet ef migrations add Initials

dotnet ef database update
```

<br><br><br><br>

## Anotações

**Mapeamento de entidades**

```cs
public class MyContext : DbContext
{
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
      // Forma 1 - Mapear entidade para tabela
      modelBuilder.Entity<UserEntity>(new UserMap().Configure);
      new UserMap().Configure(modelBuilder.Entity<UserEntity>());

      // Forma 2 - Exemplo BALTA
      modelBuilder.ApplyConfiguration(new UserMap());

      // Forma 3 - Varre um determinado assembly para todos os tipos que o implementam IEntityTypeConfiguratione registra cada um automaticamente.
      // Observação: A ordem na qual as configurações serão aplicadas é indefinida,portanto, esse método só deve ser usado quando a ordem não importa.
      modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }
}
```
