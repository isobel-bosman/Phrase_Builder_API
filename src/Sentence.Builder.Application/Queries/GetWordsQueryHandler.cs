using MediatR;
using Microsoft.EntityFrameworkCore;
using Sentence.Builder.Application.Interfaces;

namespace Sentence.Builder.Application.Queries
{
    public class GetWordsQueryHandler : IRequestHandler<GetWordsQuery, IEnumerable<string>>
    {
        private readonly ISentenceContext _context;
        public GetWordsQueryHandler(ISentenceContext sentenceContext)
        {
            _context = sentenceContext;
        }

        public async Task<IEnumerable<string>> Handle(GetWordsQuery request, CancellationToken cancellationToken)
        {
            var words = _context.Words.Where(x => x.PartOfSpeechEntity.PartOfSpeech == request.PartOfSpeech)
                                        .Select(x => x.Word);

            return await words.ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
