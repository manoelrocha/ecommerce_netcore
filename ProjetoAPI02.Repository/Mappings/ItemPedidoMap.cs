using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoAPI02.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoAPI02.Repository.Mappings
{
    public class ItemPedidoMap : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            builder.ToTable("ITEMPEDIDO");

            builder.HasKey(i => i.IdItemPedido);

            builder.Property(i => i.IdItemPedido)
                .HasColumnName("IDITEMPEDIDO");

            builder.Property(i => i.IdPedido)
                .HasColumnName("IDPEDIDO")
                .IsRequired();

            builder.Property(i => i.IdProduto)
                .HasColumnName("IDPRODUTO")
                .IsRequired();

            builder.Property(i => i.Quantidade)
                .HasColumnName("QUANTIDADE")
                .HasMaxLength(10)
                .IsRequired();

            builder.HasOne(i => i.Pedido)
                .WithMany(p => p.ItensPedido)
                .HasForeignKey(i => i.IdPedido);

            builder.HasOne(i => i.Produto)
                .WithMany(p => p.ItensPedido)
                .HasForeignKey(i => i.IdProduto);
        }
    }
}
