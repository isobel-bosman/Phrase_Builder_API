using Microsoft.EntityFrameworkCore;
using Sentence.Builder.Application.Interfaces;
using Sentence.Builder.Domain.Entities;
using Sentence.Builder.Persistence.Configurations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentence.Builder.Persistence
{
    public class SentenceContext : DbContext, ISentenceContext
    {
        public SentenceContext()
        {
        }

        public SentenceContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<SentenceEntity> Sentences { get; set; }
        public virtual DbSet<PartOfSpeechEntity> PartOfSpeeches { get; set; }
        public virtual DbSet<WordEntity> Words { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SentenceConfiguration());
            modelBuilder.ApplyConfiguration(new WordConfiguration());
            modelBuilder.ApplyConfiguration(new PartOfSpeechConfiguration());
        }

        async Task ISentenceContext.SaveChangesAsync(CancellationToken cancellationToken)
        {
            await base.SaveChangesAsync(cancellationToken);
        }
    }
}
