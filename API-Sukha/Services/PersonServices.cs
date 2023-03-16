using Entities.Entities;
using Logic.ILogic;
using API_Sukha.IServices;
using Logic.Logic;

namespace API_Sukha.Services
{
    public class PersonServices : IPersonServices
    {
        private readonly IPersonLogic _personLogic;
        public PersonServices(IPersonLogic personLogic)
        {
            _personLogic = personLogic;
        }


        public int InsertPerson(PersonItem personItem)
        {
            _personLogic.InsertPerson(personItem);
            return personItem.Id;
        }


        public void UpdatePerson(PersonItem personItem)
        {
            _personLogic.UpdatePerson(personItem);
        }

        public void DeletePerson(int id)
        {
            _personLogic.DeletePerson(id);
        }

        public List<PersonItem> GetAllPersons()
        {
            return _personLogic.GetAllPersons();
        }



    }
}
