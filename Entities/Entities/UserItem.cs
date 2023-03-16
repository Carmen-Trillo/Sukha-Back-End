using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class UserItem
    {

        public int Id { get; set; }
        public int IdPerson { get; set; }
        public int IdRol { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsActive { get; set; }


    }
}
