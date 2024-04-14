using memory_words.Models;

namespace memory_words_api.Data.Interfaces
{
    public interface ISectionRepository
    {
        List<Section> AddSection(Section section);
        List<Section> GetSections(int loginId);
        object DeleteSection(int sectionId);
    }
}
