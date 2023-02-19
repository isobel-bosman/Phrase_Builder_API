using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sentence.Builder.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentence.Builder.Application.Queries
{
    public class GetWordsQueryHandler : IRequestHandler<GetWordsQuery, IEnumerable<string>>
    {
        private readonly ISentenceContext _context;
        private readonly IMapper _mapper;
        public GetWordsQueryHandler(ISentenceContext sentenceContext, IMapper mapper)
        {
            _context = sentenceContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<string>> Handle(GetWordsQuery request, CancellationToken cancellationToken)
        {
            var words = _context.Words.Where(x => x.PartOfSpeechId == (Guid.Parse(request.PartOfSpeech)))
                                        .Select(x => x.Word);

            return await words.ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
