using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentence.Builder.Domain.Entities
{
#nullable disable
    public class SentenceEntity
    {
        public Guid Id { get; set; }
        public List<WordEntity> Words { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}
