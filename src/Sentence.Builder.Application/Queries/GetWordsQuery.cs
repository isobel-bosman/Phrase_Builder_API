using MediatR;
using Sentence.Builder.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentence.Builder.Application.Queries
{
    public class GetWordsQuery: IRequest<IEnumerable<WordDTO>>
    {
        public GetWordsQuery(string partOfSpeechDTO, string type)
        {
            WordType = type;
            PartOfSpeech = partOfSpeechDTO;
        }

        public string WordType { get; set; }
        public string PartOfSpeech { get; set; }
    }
}
