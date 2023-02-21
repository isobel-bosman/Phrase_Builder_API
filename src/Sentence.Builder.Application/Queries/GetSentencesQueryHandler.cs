using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sentence.Builder.Application.DTOs;
using Sentence.Builder.Application.Interfaces;
using Sentence.Builder.Domain.Entities;
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
            var sentences = await _context.Sentences.Include(x => x.Words)
                                                   .ThenInclude(y => y.PartOfSpeechEntity)
                                                   .ToListAsync(cancellationToken);
            foreach(var sentence in sentences)
            {
                var order = sentence.WordIdOrder.Split(',');
                var words = sentence.Words;
                var sortedWords = new List<WordEntity>();
                for(int i = 0; i < order.Length; i++)
                {
                    sortedWords.Add(sentence.Words.Find(x => x.Id == Guid.Parse(order[i]))!);
                }
                sentence.Words = sortedWords;
            }
            return _mapper.Map<List<SentenceDTO>>(sentences);
        }
    }
}
