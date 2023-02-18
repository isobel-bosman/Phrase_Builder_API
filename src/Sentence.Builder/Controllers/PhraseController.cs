using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Sentence.Builder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhraseController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PhraseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets a list of words give a part of speech.
        /// </summary>
        /// <param name="pos">The part of speech</param>
        /// <returns>List of words.</returns>
        [HttpGet]
        public IActionResult GetWords(string pos)
        {
            return Ok();
        }

        /// <summary>
        ///  Gets a list of saved phrases.
        /// </summary>
        /// <returns>The list of phrases that are saved.</returns>
        [HttpGet("saved")]
        public IActionResult GetSavedPhrases()
        {
            return Ok();
        }

        /// <summary>
        /// Saves the given phrase.
        /// </summary>
        /// <returns>200 Ok.</returns>
        [HttpPost]
        public IActionResult SavePhrase([FromBody] PhraseDTO phraseDTO)
        {
            return Ok();
        }
    }
}
