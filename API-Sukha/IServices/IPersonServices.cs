using Entities.Entities;
using Entities.SearchFilters;

namespace API_Sukha.IServices
{
    public interface IPersonServices
    {
        int InsertPerson(PersonItem personItem);
        void UpdatePerson(PersonItem personItem);
        void DeletePerson(int id);
        List<PersonItem> GetAllPersons();

        //List<PersonItem> GetPersonByCriteria(PersonFilter personFilter);
    }
}
