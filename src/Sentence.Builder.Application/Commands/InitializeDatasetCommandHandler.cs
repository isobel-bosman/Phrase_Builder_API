using MediatR;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using Sentence.Builder.Application.Interfaces;
using Sentence.Builder.Domain.Entities;
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
        private const string punctuation = ".";
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
                        if (values[1] != punctuation)
                        {
                            AddWord(values, type, partOfSpeech);
                        }
                        else if (values[0].Length == punctuation.Length)
                        {
                            AddWord(values, type, partOfSpeech);
                        }
                    }
                }
            }

            await _context.SaveChangesAsync(cancellationToken);
        }

        private void AddWord(string[] values, string type, PartOfSpeechEntity partOfSpeech)
        {
            _context.Words.Add(new WordEntity()
            {
                Word = values[0],
                Type = type,
                PartOfSpeechEntityId = partOfSpeech.Id,
                PartOfSpeechEntity = partOfSpeech
            });
        }
    }
}
