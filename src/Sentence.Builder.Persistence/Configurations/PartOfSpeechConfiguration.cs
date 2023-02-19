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
    public partial class PartOfSpeechConfiguration : IEntityTypeConfiguration<PartOfSpeechEntity>
    {
        public void Configure(EntityTypeBuilder<PartOfSpeechEntity> builder)
        {
            builder.ToTable("PartOfSpeech", "dbo");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.PartOfSpeech)
                .IsRequired()
                .HasColumnName("PartOfSpeech")
                .HasColumnType("varchar(5)")
                .HasMaxLength(5); 
            
            builder.Property(t => t.Description)
                .IsRequired()
                .HasColumnName("Description")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);


            builder.Property(t => t.CreatedOn)
                .IsRequired()
                .HasColumnName("DateCreated")
                .HasColumnType("datetimeoffset")
                .HasDefaultValueSql("(SYSDATETIMEOFFSET())");

            builder.HasMany<WordEntity>()
                .WithOne(t=> t.PartOfSpeechEntity)
                .HasForeignKey(t => t.PartOfSpeechEntityId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            SeedTable(builder);
        }

        private static void SeedTable(EntityTypeBuilder<PartOfSpeechEntity> builder)
        {
            builder.HasData(new PartOfSpeechEntity
            {
                Id = Guid.Parse("11c261a1-c620-49ad-8239-18fd1b7edcb9"),
                CreatedOn = DateTimeOffset.Parse("2023/02/19 12:13:50 PM +02:00"),
                Description = "Adjective",
                PartOfSpeech = "ADJ"
            });
            builder.HasData(new PartOfSpeechEntity
            {
                Id = Guid.Parse("263b6887-e033-467f-a431-d08bfe68143c"),
                CreatedOn = DateTimeOffset.Parse("2023/02/19 12:13:50 PM +02:00"),
                Description = "Preposition",
                PartOfSpeech = "ADP"
            });
            builder.HasData(new PartOfSpeechEntity
            {
                Id = Guid.Parse("2890e295-9d27-4d6f-a49d-225cf6b0d806"),
                CreatedOn = DateTimeOffset.Parse("2023/02/19 12:13:50 PM +02:00"),
                Description = "Adverb",
                PartOfSpeech = "ADV"
            });
            builder.HasData(new PartOfSpeechEntity
            {
                Id = Guid.Parse("2e501489-e32b-41c0-b550-159e72e64a3f"),
                CreatedOn = DateTimeOffset.Parse("2023/02/19 12:13:50 PM +02:00"),
                Description = "Conjunction",
                PartOfSpeech = "CONJ"
            });
            builder.HasData(new PartOfSpeechEntity
            {
                Id = Guid.Parse("0e92fd95-9627-4b2c-9b37-9c8a68866d94"),
                CreatedOn = DateTimeOffset.Parse("2023/02/19 12:13:50 PM +02:00"),
                Description = "Determiner",
                PartOfSpeech = "DET"
            });
            builder.HasData(new PartOfSpeechEntity
            {
                Id = Guid.Parse("f36bd21f-12fd-4072-bdcd-8b8b73ae0583"),
                CreatedOn = DateTimeOffset.Parse("2023/02/19 12:13:50 PM +02:00"),
                Description = "Noun",
                PartOfSpeech = "NOUN"
            });
            builder.HasData(new PartOfSpeechEntity
            {
                Id = Guid.Parse("9b074e51-5657-4955-8194-7c6b6b2aa531"),
                CreatedOn = DateTimeOffset.Parse("2023/02/19 12:13:50 PM +02:00"),
                Description = "Numeral",
                PartOfSpeech = "NUM"
            });
            builder.HasData(new PartOfSpeechEntity
            {
                Id = Guid.Parse("46c69f36-3c6f-4554-b172-99b1cb01c893"),
                CreatedOn = DateTimeOffset.Parse("2023/02/19 12:13:50 PM +02:00"),
                Description = "Particle",
                PartOfSpeech = "PRT"
            });
            builder.HasData(new PartOfSpeechEntity
            {
                Id = Guid.Parse("558bb598-c38f-493c-89c4-76db7860f466"),
                CreatedOn = DateTimeOffset.Parse("2023/02/19 12:13:50 PM +02:00"),
                Description = "Pronoun",
                PartOfSpeech = "PRON"
            });
            builder.HasData(new PartOfSpeechEntity
            {
                Id = Guid.Parse("f72f86bf-149b-4114-94a0-4bdc1ec4fc47"),
                CreatedOn = DateTimeOffset.Parse("2023/02/19 12:13:50 PM +02:00"),
                Description = "Verb",
                PartOfSpeech = "VERB"
            });
            builder.HasData(new PartOfSpeechEntity
            {
                Id = Guid.Parse("eec0e07d-88e6-4a7c-8a3d-07bd369ff1d2"),
                CreatedOn = DateTimeOffset.Parse("2023/02/19 12:13:50 PM +02:00"),
                Description = "Exclamation",
                PartOfSpeech = "EXC"
            });
            builder.HasData(new PartOfSpeechEntity
            {
                Id = Guid.Parse("7d2f7dd3-cf94-4357-8a66-9f9b84bdbe5b"),
                CreatedOn = DateTimeOffset.Parse("2023/02/19 12:13:50 PM +02:00"),
                Description = "Punctuation Mark",
                PartOfSpeech = "."
            });
            builder.HasData(new PartOfSpeechEntity
            {
                Id = Guid.Parse("5e48e8d4-c7a5-4bae-8e0a-fa0bf0558909"),
                CreatedOn = DateTimeOffset.Parse("2023/02/19 12:13:50 PM +02:00"),
                Description = "Other",
                PartOfSpeech = "X"
            });
        }
    }
}
