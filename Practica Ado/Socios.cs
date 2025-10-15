using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_Ado
{
   public class Socios
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string DNI { get; set; }    
        public DateTime fecha_nacimiento { get; set; }
        public int NumeroSocio { get; set; }
        public bool cuota_al_dia { get; set; }

        public int edad 
        { 
            get 
            {
                var today = DateTime.Today;
                var age = today.Year - fecha_nacimiento.Year;
                if (fecha_nacimiento.Date > today.AddYears(-age)) age--;
                return age;
            }
        }
    }
}
