namespace Sentence.Builder.Domain.Entities
{
    public class WordEntity
    {
        public Guid Id { get; set; }
        public string Word { get; set; }
        public PartOfSpeechEntity PartOfSpeechEntity { get; set; }
        public Guid PartOfSpeechEntityId { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}
