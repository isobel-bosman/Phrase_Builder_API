using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sentence.Builder.Application.DTOs;
using Sentence.Builder.Application.Interfaces;

namespace Sentence.Builder.Application.Queries
{
    public class GetWordsQueryHandler : IRequestHandler<GetWordsQuery, IEnumerable<WordDTO>>
    {
        private readonly ISentenceContext _context;
        private readonly IMapper _mapper;
        public GetWordsQueryHandler(ISentenceContext sentenceContext, IMapper mapper)
        {
            _context = sentenceContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WordDTO>> Handle(GetWordsQuery request, CancellationToken cancellationToken)
        {
            var words = _context.Words.Include(x => x.PartOfSpeechEntity)
                                      .Where(x => x.PartOfSpeechEntity.PartOfSpeech == request.PartOfSpeech 
                                               && x.Type == request.WordType)
                                      .OrderBy(x => x.Word); 

            return _mapper.Map<List<WordDTO>>(await words.ToListAsync(cancellationToken: cancellationToken));
        }
    }
}
