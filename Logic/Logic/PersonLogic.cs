using Data;
using Entities.Entities;
using Logic.ILogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class PersonLogic : IPersonLogic
    {
        private readonly ServiceContext _serviceContext;
        public PersonLogic(ServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }
        public int InsertPerson(PersonItem personItem)
        {
            _serviceContext.Persons.Add(personItem);
            _serviceContext.SaveChanges();
            return personItem.Id;
        }

        public void UpdatePerson(PersonItem personItem)
        {
            _serviceContext.Persons.Update(personItem);

            _serviceContext.SaveChanges();
        }
   
        public void DeletePerson(int id)
        {
            var personaToDelete = _serviceContext.Set<PersonItem>()
                .Where(u => u.Id == id).First();

            personaToDelete.IsActive = false;

            _serviceContext.SaveChanges();

        }


        public List<PersonItem> GetAllPersons()
        {
            return _serviceContext.Set<PersonItem>().ToList();
        }
    }
    
}

