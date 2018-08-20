using CorujasDev.TodoList.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CorujasDev.TodoList.Infra.Data.ConfigEntidades
{
    /// <summary>
    /// Classe de configuração dos campos da tabela Usuario no Banco de dados
    /// </summary>
    public class UsuarioConfiguration : IEntityTypeConfiguration<UsuarioDomain>
    {
        public void Configure(EntityTypeBuilder<UsuarioDomain> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(t => t.Nome)
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.UserName)
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(t => t.Email)
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(20);

            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.Property(t => t.Senha)
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(t => t.Imagem)
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(t => t.TipoUsuario)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(t => t.Ativo)
                .HasColumnType("bit");

            builder.Property(t => t.DataCadastro)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(t => t.DataAlteracao)
                .HasColumnType("datetime");
        }
    }
}
