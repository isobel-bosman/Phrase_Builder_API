using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentence.Builder.Domain.Entities
{
#nullable disable
    public class PartOfSpeechEntity
    {
        public Guid Id { get; set; }
        public string PartOfSpeech { get; set; }
        public string Description { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}
