﻿using Sentence.Builder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentence.Builder.Application.DTOs
{
    public class SentenceDTO
    {
        public List<WordDTO>? Words { get; set; }
    }
}
