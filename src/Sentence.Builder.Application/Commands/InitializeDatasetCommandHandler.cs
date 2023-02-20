using MediatR;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using Sentence.Builder.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentence.Builder.Application.Commands
{
    public class InitializeDatasetCommandHandler : IRequestHandler<InitializeDatasetCommand>
    {
        private readonly ISentenceContext _context;
        public InitializeDatasetCommandHandler(ISentenceContext context)
        {
            _context = context;
        }

        public async Task Handle(InitializeDatasetCommand request, CancellationToken cancellationToken)
        {
            using var reader = new StreamReader($"{AppDomain.CurrentDomain.BaseDirectory}\\Datasets\\{request.FileName}");
            var line = reader.ReadLine();
            var type = request.FileName.Split(".")[0];
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                var values = line?.Split(',');
                var partOfSpeech = _context.PartOfSpeeches.FirstOrDefault(x => x.PartOfSpeech == values[1]);
                if (partOfSpeech is not null)
                {
                    var word = _context.Words.FirstOrDefault(x => x.Word == values[0]
                                                              && x.PartOfSpeechEntityId == partOfSpeech.Id
                                                              && x.Type == type);
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
        }
    }
}
