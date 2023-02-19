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
            CreateMap<SentenceEntity, SentenceDTO>()
                .ForPath(dest => dest.Words, opt => opt.MapFrom(src => src.Words));
            CreateMap<SentenceDTO, SentenceEntity>()
                .ForPath(dest => dest.Words, opt => opt.MapFrom(src => src.Words));
            CreateMap<WordDTO, WordEntity>()
                .ForMember(dest => dest.PartOfSpeechEntity, opt => opt.MapFrom(src => src.PartOfSpeech));
            CreateMap<WordEntity, WordDTO>()
                .ForMember(dest => dest.PartOfSpeech, opt => opt.MapFrom(src => src.PartOfSpeechEntity));
            CreateMap<PartOfSpeechEntity, PartOfSpeechDTO>();
            CreateMap<PartOfSpeechDTO, PartOfSpeechEntity>();
        }
    }
}
