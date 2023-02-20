using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sentence.Builder.Application.Commands;
using Sentence.Builder.Application.Interfaces;

namespace Sentence.Builder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitializeController: ControllerBase
    {
        private readonly IMediator _mediator;

        public InitializeController(IMediator mediator) 
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> Initialize(string fileName, CancellationToken cancellationToken)
        {
            try
            {
                await _mediator.Send(new InitializeDatasetCommand(fileName), cancellationToken);
                return Ok();
            }
            catch(FileNotFoundException) 
            {
                return NotFound($"Failed find file '{fileName}', please ensure the filename is typed correctly.");
            }
        }
    }
}
