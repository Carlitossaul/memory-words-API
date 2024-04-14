using System.ComponentModel.DataAnnotations.Schema;

namespace memory_words.Models
{
    public class Section
    {
        public int SectionId { get; set; }
        public string Name { get; set; }
        public int LoginId { get; set; }

        [ForeignKey("LoginId")]
        public virtual Login? Login { get; set; }


    }
}
