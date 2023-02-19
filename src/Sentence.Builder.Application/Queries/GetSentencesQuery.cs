﻿using MediatR;
using Sentence.Builder.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentence.Builder.Application.Queries
{
    public class GetSentencesQuery: IRequest<IEnumerable<SentenceDTO>>
    {
        public GetSentencesQuery()
        {

        }
    }
}
