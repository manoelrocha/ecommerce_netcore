using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoAPI02.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoAPI02.Repository.Mappings
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("PEDIDO");

            builder.HasKey(p => p.IdPedido);

            builder.Property(p => p.IdPedido)
                .HasColumnName("IDPEDIDO");

            builder.Property(p => p.DataPedido)
                .HasColumnName("DATAPEDIDO")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(p => p.ValorTotal)
                .HasColumnName("VALORTOTAL")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.IdCliente)
                .HasColumnName("IDCLIENTE")
                .IsRequired();

            builder.HasOne(p => p.Cliente)
                .WithMany(c => c.Pedidos)
                .HasForeignKey(p => p.IdCliente);
        }
    }
}
