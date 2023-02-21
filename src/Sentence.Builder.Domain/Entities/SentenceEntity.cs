using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentence.Builder.Domain.Entities
{
    public class SentenceEntity
    {
        public Guid Id { get; set; }
        public string WordIdOrder { get; set; } = "";
        public List<WordEntity> Words { get; set; } = new List<WordEntity>();
        public DateTimeOffset CreatedOn { get; set; }
    }
}
