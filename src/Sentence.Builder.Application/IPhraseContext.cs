using Sentence.Builder.Domain.Entities;

namespace Sentence.Builder.Application
{
    public interface IPhraseContext
    {
        Task<IEnumerable<PhraseEnitity>> GetSavedSentences();
    }
}
