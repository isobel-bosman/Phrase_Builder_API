using MediatR;
using Sentence.Builder.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentence.Builder.Application.Queries
{
    public class GetWordsQuery: IRequest<IEnumerable<string>>
    {
        public GetWordsQuery(string partOfSpeechDTO)
        {
            PartOfSpeech = partOfSpeechDTO;
        }
        public string PartOfSpeech { get; set; }
    }
}
