using DL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PLL.Controllers
{
    public class UsuarioController : Controller
    {


        
        [HttpGet]
        public IActionResult GetAll(int? IdRol, string? Nombre, string? ApellidoPaterno, string? ApellidoMaterno)
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol();
            usuario.Usuarios = new List<ML.Usuario>();            
            ML.Result result = BL.Usuario.GetAll();            
            ML.Result resultRoles = BL.Rol.GetAll();
            if (resultRoles.Correct)
            {
                usuario.Rol.Roles = resultRoles.Objects;
            }
            else
            {
                usuario.Rol.Roles = new List<object>(); 
            }            
            if (result.Correct)
            {
              var usuarios = result.Objects.Cast<ML.Usuario>().ToList();

                if (IdRol.HasValue && IdRol.Value > 0)
                {
                    usuarios = usuarios.Where(u => u.Rol.IdRol == IdRol.Value).ToList();
                }                
                if (!string.IsNullOrEmpty(Nombre))
                {
                    usuarios = usuarios.Where(u =>
                        !string.IsNullOrEmpty(u.Nombre) &&
                        u.Nombre.ToLower().Contains(Nombre.ToLower())
                    ).ToList();
                }                
                if (!string.IsNullOrEmpty(ApellidoPaterno))
                {
                    usuarios = usuarios.Where(u =>
                        !string.IsNullOrEmpty(u.ApellidoPaterno) &&
                        u.ApellidoPaterno.ToLower().Contains(ApellidoPaterno.ToLower())
                    ).ToList();
                }               
                if (!string.IsNullOrEmpty(ApellidoMaterno))
                {
                    usuarios = usuarios.Where(u =>
                        !string.IsNullOrEmpty(u.ApellidoMaterno) &&
                        u.ApellidoMaterno.ToLower().Contains(ApellidoMaterno.ToLower())
                    ).ToList();
                }
                usuario.Usuarios = usuarios;
            }
            return View(usuario);
        }


        [HttpGet]
        public IActionResult Delete(int IdUsuario)
        {
            var blUsuario = new BL.Usuario();
            var result = BL.Usuario.DeleteLINQ(IdUsuario);
            if (result.Correct)
            {
                TempData["Mensaje"] = "Usuario eliminado correctamente";
            }
            else
            {
                TempData["Mensaje"] = result.ErrorMessage;
            }


            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public ActionResult Form(int? IdUsuario, bool? BorrarSesion)
        {
            ML.Usuario usuario = new ML.Usuario();


            var blRol = new BL.Rol();
            ML.Result resultRoles = BL.Rol.GetAll();

            if (resultRoles.Correct)
            {
                usuario.Rol = new ML.Rol();
                usuario.Rol.Roles = resultRoles.Objects;
            }

            if (IdUsuario > 0) // Update
            {

            }

            return View(usuario);
        }

        [HttpPost]
        public IActionResult GetAll(ML.Usuario usuario, string accion)
        {
            if (accion == "Cancelar Busqueda")
            {
                return RedirectToAction("GetAll"); // Limpia filtros
            }
            //Va en GetllDTO?
            return RedirectToAction("GetAll", new
            {
                IdRol = usuario.Rol?.IdRol ?? 0,
                Nombre = usuario.Nombre,
                ApellidoPaterno = usuario.ApellidoPaterno,
                ApellidoMaterno = usuario.ApellidoMaterno
            });
        }





        [HttpPost]
        public IActionResult Form(ML.Usuario usuario, string accion)
        {
            if (accion == "Regresar")
            {
                return RedirectToAction("GetAll");
            }

            if (accion == "Guardar")
            {
                if (accion == "Regresar")
                {
                    return RedirectToAction("GetAll");
                }

                var blUsuario = new BL.Usuario();

                if (accion == "Guardar")
                {
                    if (usuario.IdUsuario == 0) // Alta
                    {
                        var resultUsuario = BL.Usuario.AddLINQ(usuario);

                        if (resultUsuario.Correct && resultUsuario.Object != null)
                        {
                            TempData["Mensaje"] = "Usuario agregado correctamente";
                            return RedirectToAction("GetAll");
                        }
                        else
                        {
                            ViewBag.Mensaje = resultUsuario.ErrorMessage;
                        }
                    }
                    else // Actualización
                    {
                        var resultUpdate = BL.Usuario.UpdateLINQ(usuario);

                        if (resultUpdate.Correct)
                        {
                            TempData["Mensaje"] = "Usuario actualizado correctamente";
                            return RedirectToAction("GetAll");
                        }
                        else
                        {
                            ViewBag.Mensaje = resultUpdate.ErrorMessage;
                        }
                    }
                }
                var blRol = new BL.Rol();
                var resultRoles = BL.Rol.GetAll();
                if (resultRoles.Correct)
                {
                    usuario.Rol = new ML.Rol();
                    usuario.Rol.Roles = resultRoles.Objects;
                }
            }
            return View(usuario);
        }


    }
}


/* Anterior manera de traer a llamar los Bl 
private readonly DL.ErojasProgramacionNcapasContext _context;
public UsuarioController(DL.ErojasProgramacionNcapasContext context)
{
    _context = context;
}
*/