using Microsoft.EntityFrameworkCore;
using Sentence.Builder.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentence.Builder.Persistence.Configurations
{
    public partial class SentenceConfiguration : IEntityTypeConfiguration<SentencesEnitity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<SentencesEnitity> builder)
        {
            builder.ToTable("Sentences", "dbo");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.Sentence)
                .IsRequired()
                .HasColumnName("Sentence")
                .HasColumnType("varchar(500)")
                .HasMaxLength(500);

            builder.Property(t => t.CreatedOn)
                .IsRequired()
                .HasColumnName("DateCreated")
                .HasColumnType("datetimeoffset")
                .HasDefaultValueSql("(SYSDATETIMEOFFSET())");
        }
    }
}
