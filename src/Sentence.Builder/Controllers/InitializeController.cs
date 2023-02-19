using Microsoft.AspNetCore.Mvc;
using Sentence.Builder.Application.Interfaces;

namespace Sentence.Builder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitializeController: ControllerBase
    {
        private readonly ISentenceContext _context;
        public InitializeController(ISentenceContext sentenceContext) 
        {
            _context = sentenceContext;
        }


        [HttpGet]
        public async Task<IActionResult> Initialize(string fileName, CancellationToken cancellationToken)
        {
            using var reader = new StreamReader(@"C:\GIT\Sentence_Builder_API\" + fileName);
            var line = reader.ReadLine();
            var type = fileName.Split(".")[0];
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                var values = line?.Split(',');
                var partOfSpeech = _context.PartOfSpeeches.FirstOrDefault(x => x.PartOfSpeech == values[1]);
                if(partOfSpeech is not null)
                {
                    var word = _context.Words.FirstOrDefault(x => x.Word == values[0] 
                                                              && x.PartOfSpeechEntityId == partOfSpeech.Id 
                                                              &&  x.Type == type);
                    if (word is null)
                    {
                        _context.Words.Add(new Domain.Entities.WordEntity()
                        {
                            Word = values[0],
                            Type = type,
                            PartOfSpeechEntityId = partOfSpeech.Id,
                            PartOfSpeechEntity = partOfSpeech
                        });
                    }
                }
            }

            await _context.SaveChangesAsync(cancellationToken);

            return Ok();
        }
    }
}
