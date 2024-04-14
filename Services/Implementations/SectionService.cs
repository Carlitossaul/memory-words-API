using memory_words.Models;
using memory_words_api.Data.Implementations;
using memory_words_api.Data.Interfaces;
using memory_words_api.Services.Interfaces;

namespace memory_words_api.Services.Implementations
{
    public class SectionService : ISectionService
    {
        private readonly ISectionRepository _sectionRepository;

        public SectionService(ISectionRepository sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }

        public List<Section> AddSection(Section section)
        {
            return _sectionRepository.AddSection(section);
        }


        public object DeleteSection(int sectionId)
        {
            throw new System.NotImplementedException();
        }

        public List<Section> GetSections(int loginId)
        {
            return _sectionRepository.GetSections(loginId);
        }
    }
}
