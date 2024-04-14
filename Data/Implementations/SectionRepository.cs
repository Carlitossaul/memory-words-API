using memory_words.Models;
using memory_words_api.Data.Interfaces;
using memory_words_api.Services.Implementations;

namespace memory_words_api.Data.Implementations
{
    public class SectionRepository : ISectionRepository
    {
        private readonly MemoryContext _memoryContext;

        public SectionRepository(MemoryContext memoryContext)
        {
            _memoryContext = memoryContext;
        }
        public List<Section> AddSection(Section section)
        {
            var user = _memoryContext.Logins.FirstOrDefault(u => u.LoginId == section.LoginId);
            if (user != null)
            {
                var exist = GetSectionByName(section.Name, section.LoginId);

                if(exist)
                {
                    return null;
                }

                Section newSection = new Section
                {
                    LoginId = section.LoginId,
                    Name = section.Name
                };
                _memoryContext.Sections.Add(newSection);
                _memoryContext.SaveChanges();

                var userSections = _memoryContext.Sections.Where(s => s.LoginId == section.LoginId).ToList();
                return userSections;
            }
            else
            {
                // Devuelve una lista vacía en lugar de null
                return new List<Section>();
            }
        }

        public bool GetSectionByName(string name, int loginId)
        {
            var section = _memoryContext.Sections.FirstOrDefault(s => s.Name == name && s.LoginId == loginId);
            return section != null;
        }

        public object DeleteSection(int sectionId)
        {
            throw new System.NotImplementedException();
        }

        public List<Section> GetSections(int loginId)
        {
            var sections = _memoryContext.Sections.Where(s => s.LoginId == loginId).ToList();
            return sections;
        }
    }
}
