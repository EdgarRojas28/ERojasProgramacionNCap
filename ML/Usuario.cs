using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        
        [MinLength(3, ErrorMessage = "Pocos valores") ]
        [MaxLength(40, ErrorMessage = "Muchos valores")]
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Solo LETRAS y NUMEROS .")]
        [Required(ErrorMessage = "Prueba")]
        public string? UserName { get; set; }


        [Required(ErrorMessage = "Se requiere un Nombre")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Solo LETRAS.")]
        [MinLength(3, ErrorMessage = "Pocos valores")]
        [MaxLength(40, ErrorMessage = "Muchos valores")]
        public string? Nombre { get; set; }



        [Required(ErrorMessage = "Se requiere un Apellido Paterno")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Solo LETRAS.")]
        [MinLength(3, ErrorMessage = "Pocas Letras")]
        [MaxLength(40, ErrorMessage = "Muchos valores")]
        public string? ApellidoPaterno { get; set; }




        [Required(ErrorMessage = "Se requiere un Materno")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Solo LETRAS.")]
        [MinLength(3, ErrorMessage = "Pocas Letras")]
        [MaxLength(40, ErrorMessage = "Muchos valores")]
        public string? ApellidoMaterno { get; set; }



        [Required(ErrorMessage = "Se requiere un Email")]
        [MinLength(3, ErrorMessage = "Pocas Letras")]
        [MaxLength(40, ErrorMessage = "Muchos valores")]
        [EmailAddress]

        public string? Email { get; set; }



        [Required(ErrorMessage = "Se requiere un Password")]
        [MinLength(3, ErrorMessage = "Pocos caracteres")]
        [MaxLength(40, ErrorMessage = "Muchos valores")]       
        public string? Password { get; set; }



        [Required(ErrorMessage = "Se requiere un Sexo")]
        [MinLength(1, ErrorMessage = "Selecciona un valor")]
        
        public string? Sexo { get; set; }




        [Required(ErrorMessage = "El campo Celular es obligatorio.")]
        [RegularExpression(@"^\d{9,10}$", ErrorMessage = "Debe tener 9 o 10 dígitos numéricos.")]
        [MinLength(9)]
        [MaxLength(10)]
        [Phone]
        public string? Telefono { get; set; }


        [Required(ErrorMessage = "El campo Celular es obligatorio.")]
        [RegularExpression(@"^\d{9,10}$", ErrorMessage = "Debe tener 9 o 10 dígitos numéricos.")]
        [MinLength(9)]
        [MaxLength(10)]
        [Phone]             
        public string? Celular { get; set; }



        
        public DateTime? FechaNacimiento { get; set; }


        [Required(ErrorMessage = "Se requiere una Curp ")]
        [MinLength(17, ErrorMessage = "Se requiere una Curp Valida ")]
        [MaxLength(20, ErrorMessage = "Se requiere una Curp ")]
        public string? CURP { get; set; }
            
            /*public List<ImagenUsuario> ImagenesUsuario { get; set; } = new List<ImagenUsuario>();
            public ML.ImagenUsuario ImagenUsuario { get; set; }

            //public ML.Municipio Municipio { get; set; }
            //public ML.Colonia Colonia { get; set; }

            public ML.Direccion Direccion { get; set; }*/



        }

    }


