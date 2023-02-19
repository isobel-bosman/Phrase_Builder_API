using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sentence.Builder.Application.DTOs;
using Sentence.Builder.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentence.Builder.Application.Queries
{
    public class GetSentencesQueryHandler : IRequestHandler<GetSentencesQuery, IEnumerable<SentenceDTO>>
    {

        private readonly ISentenceContext _context;
        private readonly IMapper _mapper;
        public GetSentencesQueryHandler(ISentenceContext sentenceContext, IMapper mapper)
        {
            _context = sentenceContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<SentenceDTO>> Handle(GetSentencesQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<SentenceDTO>>(await _context.Sentences.ToListAsync(cancellationToken));
        }
    }
}
