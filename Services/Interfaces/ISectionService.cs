using memory_words.Models;

namespace memory_words_api.Services.Interfaces
{
    public interface ISectionService
    {
        List<Section> AddSection(Section section);
        List<Section> GetSections(int loginId);
        public object DeleteSection(int sectionId); 
    
    }
}
