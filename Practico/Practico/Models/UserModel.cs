using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practico.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String NombreUsuario { get; set; }
        public String ClaveAcceso { get; set; }
        public String Email { get; set; }
        public RolEnum RolUsuario { get; set; }

    }
}