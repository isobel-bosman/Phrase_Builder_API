using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentence.Builder.Application.Commands
{
    public class InitializeDatasetCommand: IRequest
    {
        public InitializeDatasetCommand(string fileName)
        {
            FileName = fileName;
        }
        public string FileName { get; set; }
    }
}
