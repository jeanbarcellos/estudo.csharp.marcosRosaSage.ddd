using System.Reflection;
using Api.Data.Mapping;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public MyContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Forma 1 - Mapear entidade para tabela
            // modelBuilder.Entity<UserEntity>(new UserMap().Configure); // Professor
            // new UserMap().Configure(modelBuilder.Entity<UserEntity>()); //  Doc Microsoft

            // Forma 2 - Exemplo BALTA
            modelBuilder.ApplyConfiguration(new UserMap());

            // Forma 3 - Varre um determinado assembly para todos os tipos que o implementam IEntityTypeConfiguratione registra cada um automaticamente.
            // Observação: A ordem na qual as configurações serão aplicadas é indefinida,portanto, esse método só deve ser usado quando a ordem não importa.
            // modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }

}