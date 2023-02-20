using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sentence.Builder.Application.Commands;
using Sentence.Builder.Application.DTOs;
using Sentence.Builder.Application.Queries;

namespace Sentence.Builder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SentenceController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SentenceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets a list of words give a part of speech.
        /// </summary>
        /// <param name="pos">The part of speech</param>
        /// <returns>List of words.</returns>
        [HttpGet("words")]
        public async Task<IEnumerable<WordDTO>> GetWords(string pos, string type)
        {
            return await _mediator.Send(new GetWordsQuery(pos, type));
        }

        [HttpGet("partsofspeech")]
        public async Task<IEnumerable<PartOfSpeechDTO>> GetPartsOfSpeech()
        {
            return await _mediator.Send(new GetPartsOfSpeechQuery());
        }

        /// <summary>
        ///  Gets a list of saved sentences.
        /// </summary>
        /// <returns>The list of phrases that are saved.</returns>
        [HttpGet("saved")]
        public async Task<IEnumerable<SentenceDTO>> GetSavedSentences()
        {
            return await _mediator.Send(new GetSentencesQuery());
        }

        /// <summary>
        /// Saves the given sentence.
        /// </summary>
        /// <returns>200 Ok.</returns>
        [HttpPost]
        public async Task<SentenceDTO> Sentence([FromBody] SentenceDTO sentenceDTO)
        {
            return await _mediator.Send(new CreateSentenceCommand(sentenceDTO)); 
        }
    }
}
