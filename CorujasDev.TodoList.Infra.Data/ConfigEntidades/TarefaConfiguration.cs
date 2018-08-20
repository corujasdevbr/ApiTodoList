using CorujasDev.TodoList.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CorujasDev.TodoList.Infra.Data.ConfigEntidades
{
    /// <summary>
    /// Classe de configuração dos campos da tabela tarefa do Banco de dados
    /// </summary>
    public class TarefaConfiguration : IEntityTypeConfiguration<TarefaDomain>
    {
        public void Configure(EntityTypeBuilder<TarefaDomain> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(t => t.Titulo)
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.Descricao)
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(t => t.Status)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(t => t.Tempo)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(t => t.DataConcluido)
                .HasColumnType("datetime");

            builder.HasOne<UsuarioDomain>(s => s.Usuario)
                .WithMany(g => g.Tarefas)
                .HasForeignKey(s => s.IdUsuario);

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
