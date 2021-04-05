using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoAPI02.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoAPI02.Repository.Mappings
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("ENDERECO");

            builder.HasKey(e => e.IdEndereco);

            builder.Property(e => e.IdEndereco)
                .HasColumnName("IDENDERECO");

            builder.Property(e => e.Logradouro)
                .HasColumnName("LOGRADOURO")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(e => e.Numero)
                .HasColumnName("NUMERO")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(e => e.Complemento)
                .HasColumnName("COMPLEMENTO")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(e => e.Bairro)
                .HasColumnName("BAIRRO")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Cidade)
                .HasColumnName("CIDADE")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Estado)
                .HasColumnName("ESTADO")
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(e => e.Cep)
                .HasColumnName("CEP")
                .HasMaxLength(10)
                .IsRequired();

            builder.HasOne(e => e.Cliente)
                .WithMany(c => c.Enderecos)
                .HasForeignKey(e => e.IdCliente);
        }
    }
}
