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
            CreateMap<SentencesEnitity, SentenceDTO>();
            CreateMap<SentenceDTO, SentencesEnitity>();
            CreateMap<WordDTO, WordDTO>()
                .ForMember(dest => dest.PartOfSpeechId, opt => opt.MapFrom(src => src.PartOfSpeechId));
            CreateMap<WordEntity, WordDTO>()
                .ForMember(dest => dest.PartOfSpeechId, opt => opt.MapFrom(src => src.PartOfSpeechId));
            CreateMap<PartOfSpeechEntity, PartOfSpeechDTO>();
            CreateMap<PartOfSpeechDTO, PartOfSpeechEntity>();
        }
    }
}
