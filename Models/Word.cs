using System.ComponentModel.DataAnnotations.Schema;

namespace memory_words.Models
{
    public class Word
    {
        public int WordId {  get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Color { get; set; }
        public int SectionId { get; set; }

        [ForeignKey("SectionId")]
        public virtual Section Section { get; set; }

    }
}
