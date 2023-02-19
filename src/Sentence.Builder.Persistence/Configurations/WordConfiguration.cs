using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sentence.Builder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentence.Builder.Persistence.Configurations
{
    public partial class WordConfiguration : IEntityTypeConfiguration<WordEntity>
    {
        public void Configure(EntityTypeBuilder<WordEntity> builder)
        {
            builder.ToTable("Words", "dbo");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.Word)
                .IsRequired()
                .HasColumnName("Word")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.HasOne<PartOfSpeechEntity>()
                .WithMany()
                .HasForeignKey(x => x.PartOfSpeechId);

            builder.Property(t => t.CreatedOn)
                .IsRequired()
                .HasColumnName("DateCreated")
                .HasColumnType("datetimeoffset")
                .HasDefaultValueSql("(SYSDATETIMEOFFSET())");
        }
    }
}
