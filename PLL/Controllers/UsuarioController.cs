using DL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PLL.Controllers
{
    public class UsuarioController : Controller
    {        
        [HttpPost]
        public IActionResult GetAll(ML.Usuario usuario, string accion)
        {
            if (accion == "Cancelar Busqueda")
            {
                return RedirectToAction("GetAll");
            }
            //usuario.Nombre = usuario.Nombre == null ? "" : usuario.Nombre;
            // operador nulleable
            usuario.Nombre = usuario.Nombre ?? "";
            usuario.ApellidoPaterno = usuario.ApellidoPaterno ?? "";
            usuario.ApellidoMaterno = usuario.ApellidoMaterno ?? "";
            ML.Result result = BL.Usuario.GetAll(usuario);
            if (result.Correct)
            {
                usuario.Usuarios = result.Objects.Cast<ML.Usuario>().ToList();
            }
            else
            {
                usuario.Usuarios = new List<ML.Usuario>();
            }            
            var resultRoles = BL.Rol.GetAll();
            usuario.Rol = new ML.Rol();
            usuario.Rol.Roles = resultRoles.Correct ? resultRoles.Objects : new List<object>();
            return View("GetAll", usuario); 
        }
        [HttpGet]
        public IActionResult GetAll(int? IdUsuario, bool? BorrarSesion)
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol();            
            usuario.Nombre = "";
            usuario.ApellidoPaterno = "";
            usuario.ApellidoMaterno = "";          
            ML.Result result = BL.Usuario.GetAll(usuario);            
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
                /*
                if (IdRol.HasValue && IdRol.Value > 0)
                {
                    usuarios = usuarios.Where(u => u.Rol.IdRol == IdRol.Value).ToList();
                }                
                if (!string.IsNullOrEmpty(Nombre))//Filtra por Nombre
                {
                    usuarios = usuarios.Where(u =>
                        !string.IsNullOrEmpty(u.Nombre) &&
                        u.Nombre.ToLower().Contains(Nombre.ToLower())
                    ).ToList();
                }                
                if (!string.IsNullOrEmpty(ApellidoPaterno))//Filtra por Apellido Paterno
                {
                    usuarios = usuarios.Where(u =>
                        !string.IsNullOrEmpty(u.ApellidoPaterno) &&
                        u.ApellidoPaterno.ToLower().Contains(ApellidoPaterno.ToLower())
                    ).ToList();
                }               
                if (!string.IsNullOrEmpty(ApellidoMaterno))//Filtra por Apellido Materno
                {
                    usuarios = usuarios.Where(u =>
                        !string.IsNullOrEmpty(u.ApellidoMaterno) &&
                        u.ApellidoMaterno.ToLower().Contains(ApellidoMaterno.ToLower())
                    ).ToList();
                }*/
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
        public IActionResult Form(ML.Usuario usuario, string accion)//QUITAR EL ACCION 
        {
            if (usuario.Rol == null)
            {
                usuario.Rol = new ML.Rol();
            }
            var resultRoles = BL.Rol.GetAll();
            if (resultRoles.Correct)
            {                
                usuario.Rol.Roles = resultRoles.Objects;
            }
            if (!ModelState.IsValid)
            {                
                usuario.Rol.Roles = resultRoles.Objects;
                return View(usuario);
            }
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
                /*
                if (!ModelState.IsValid)
                {
                    // Si hay errores de validación, devolver la vista con los errores
                    // (La vista los mostrará con ayuda de Razor)
                    model.Rol.Roles = ObtenerRoles(); // Vuelve a cargar combos si es necesario
                    return View(model);
                }*/
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