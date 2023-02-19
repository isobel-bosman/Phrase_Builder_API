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
    public class GetPartsOfSpeechQueryHandler : IRequestHandler<GetPartsOfSpeechQuery, IEnumerable<PartOfSpeechDTO>>
    {

        private readonly ISentenceContext _context;
        private readonly IMapper _mapper;
        public GetPartsOfSpeechQueryHandler(ISentenceContext sentenceContext, IMapper mapper)
        {
            _context= sentenceContext;
            _mapper= mapper;
        }
        public async Task<IEnumerable<PartOfSpeechDTO>> Handle(GetPartsOfSpeechQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<PartOfSpeechDTO>>(await _context.PartOfSpeeches.ToListAsync(cancellationToken));
        }
    }
}
