using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class PersonItem
    {
        public PersonItem() { }
        public int Id { get; set; }
        public Guid IdWeb { get; set; }
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Dirección { get; set; }
        public string Población { get; set; }
        public string Provincia { get; set; }
        public int CódigoPostal { get; set; }
        public int Teléfono { get; set; }
        public string Email { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsActive { get; set; }
    }
}
