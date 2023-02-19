using MediatR;
using Sentence.Builder.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentence.Builder.Application.Commands
{
    public class CreateSentenceCommand: IRequest<SentenceDTO>
    {
        public CreateSentenceCommand(SentenceDTO sentenceDTO)
        {
            Sentence = sentenceDTO;
        }
        public SentenceDTO Sentence { get; set; }
    }
}
