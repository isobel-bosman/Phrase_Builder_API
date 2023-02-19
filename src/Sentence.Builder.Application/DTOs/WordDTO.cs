namespace Sentence.Builder.Application.DTOs
{
#nullable disable
    public class WordDTO
    {
        public Guid Id { get; set; }
        public string Word { get; set; }
        public string Type { get; set; }
        public PartOfSpeechDTO PartOfSpeech { get; set; }
    }
}
