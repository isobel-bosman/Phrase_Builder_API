using AutoMapper;
using Sentence.Builder.Application.DTOs;
using Sentence.Builder.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentence.Builder.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PhraseEnitity, PhraseDTO>();
            CreateMap<PhraseDTO, PhraseEnitity>();
        }
    }
}
