using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoAPI02.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoAPI02.Repository.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("PRODUTO");

            builder.HasKey(p => p.IdProduto);

            builder.Property(p => p.IdProduto)
                .HasColumnName("IDPRODUTO");

            builder.Property(p => p.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(p => p.Preco)
                .HasColumnName("PRECO")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasColumnName("DESCRICAO")
                .HasMaxLength(1000)
                .IsRequired();
            
            builder.Property(p => p.Foto)
                .HasColumnName("FOTO")
                .HasMaxLength(150);
        }
    }
}
