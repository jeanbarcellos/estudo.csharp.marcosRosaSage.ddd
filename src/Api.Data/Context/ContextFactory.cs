using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>

    {
        public MyContext CreateDbContext(string[] args)
        {
            // Usado para Criar as Migrações
            var connectionString = "Host=127.0.0.1;Database=dojo;Username=postgres;Password=postgres;Port=5433";

            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new MyContext(optionsBuilder.Options);
        }
    }
}