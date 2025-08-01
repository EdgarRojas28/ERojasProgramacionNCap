using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Usuario
    {
        public List<Usuario>? Usuarios { get; set; }
        //public List<object>? Usuarios { get; set; }
            public ML.Rol? Roles { get; set; }
            public ML.Rol? Rol { get; set; }
            public int IdUsuario { get; set; }
            public string? UserName { get; set; }
            public string? Nombre { get; set; }
            public string? ApellidoPaterno { get; set; }
            public string? ApellidoMaterno { get; set; }
            public string? Email { get; set; }
            public string? Password { get; set; }
            public string? Sexo { get; set; }
            public string? Telefono { get; set; }
            public string? Celular { get; set; }
            public DateTime? FechaNacimiento { get; set; }
            public string? CURP { get; set; }
            
            /*public List<ImagenUsuario> ImagenesUsuario { get; set; } = new List<ImagenUsuario>();
            public ML.ImagenUsuario ImagenUsuario { get; set; }

            //public ML.Municipio Municipio { get; set; }
            //public ML.Colonia Colonia { get; set; }

            public ML.Direccion Direccion { get; set; }*/



        }

    }


