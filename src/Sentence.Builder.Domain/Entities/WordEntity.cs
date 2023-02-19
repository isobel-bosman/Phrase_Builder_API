using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentence.Builder.Domain.Entities
{
    public class WordEntity
    {
        public Guid Id { get; set; }
        public string Word { get; set; }
        public Guid PartOfSpeechId { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}
