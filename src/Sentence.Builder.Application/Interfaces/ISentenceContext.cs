using Microsoft.EntityFrameworkCore;
using Sentence.Builder.Domain.Entities;
using System.Collections.Generic;

namespace Sentence.Builder.Application.Interfaces
{
    public interface ISentenceContext
    {
        public DbSet<SentencesEnitity> Sentences { get; set; }
        public DbSet<PartOfSpeechEntity> PartOfSpeeches { get; set; }
        public DbSet<WordEntity> Words { get; set; }
        public Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
