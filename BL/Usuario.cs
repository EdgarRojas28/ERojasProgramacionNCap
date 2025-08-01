using Microsoft.EntityFrameworkCore;

namespace BL
{
   public class Usuario
    {
        public static ML.Result GetAll()
        {
          ML.Result result = new ML.Result();
            try
            {
                using (DL.ErojasProgramacionNcapasContext context = new DL.ErojasProgramacionNcapasContext())
               {
                    var listaUsuario = (from usuarioDB in context.Usuarios
                                        join rolDB in context.Rols
                                        on usuarioDB.IdRol equals rolDB.IdRol
                                        select new
                                        {
                                            usuarioDB.IdUsuario,
                                            usuarioDB.UserName,
                                            usuarioDB.Nombre,
                                            usuarioDB.ApellidoPaterno,
                                            usuarioDB.ApellidoMaterno,
                                            usuarioDB.Email,
                                            usuarioDB.Password,
                                            usuarioDB.Sexo,
                                            usuarioDB.Telefono,
                                            usuarioDB.Celular,
                                            usuarioDB.FechaNacimiento,
                                            usuarioDB.Curp,
                                            rolDB.IdRol,
                                            NombreRol = rolDB.Nombre
                                        }).ToList();
                    result.Objects = new List<object>();
                    foreach (var usuarioObj in listaUsuario)
                    {
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario = usuarioObj.IdUsuario;
                        usuario.UserName = usuarioObj.UserName;
                        usuario.Nombre = usuarioObj.Nombre;
                        usuario.ApellidoPaterno = usuarioObj.ApellidoPaterno;
                        usuario.ApellidoMaterno = usuarioObj.ApellidoMaterno;
                        usuario.Email = usuarioObj.Email;
                        usuario.Password = usuarioObj.Password;
                        usuario.Sexo = usuarioObj.Sexo;
                        usuario.Telefono = usuarioObj.Telefono;
                        usuario.Celular = usuarioObj.Celular;
                        //usuario.FechaNacimiento = usuarioObj.FechaNacimiento;
                        usuario.CURP = usuarioObj.Curp;
                        usuario.Rol = new ML.Rol
                        {
                            IdRol = usuarioObj.IdRol,
                            Nombre = usuarioObj.NombreRol
                        };
                        result.Objects.Add(usuario);
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;

            }

            return result;

        }

        /*

        private readonly DL.ErojasProgramacionNcapasContext _context;

        public Usuario(DL.ErojasProgramacionNcapasContext context)
        {
            _context = context;
        }
        */
        /*
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ErojasProgramacionNcapasContext context = new DL.ErojasProgramacionNcapasContext())
                {
                    // conexion, en donde voy a guardar la informacion , ejecutar el SP4

                    var query = context.UsuarioGetAllDTO.FromSqlRaw("MateriaGetAll").ToList(); // lista con 2 materias  

                    // FromSqlRaw - SELECT

                    // ExecuteSqlRaw   -INSERT UPDATE Y DELETE 

                    if (query.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var usuarioDB in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.Rol = new ML.Rol();

                            usuario.IdUsuario = usuarioDB.IdUsuario;
                            usuario.UserName = usuarioDB.UserName;
                            usuario.Nombre = usuarioDB.Nombre;

                            usuario.ApellidoPaterno = usuarioDB.ApellidoPaterno;
                            usuario.ApellidoMaterno = usuarioDB.ApellidoMaterno;

                            usuario.Email = usuarioDB.Email;
                            usuario.Password = usuarioDB.Password;

                            usuario.Sexo = usuarioDB.Sexo;
                            usuario.Telefono = usuarioDB.Telefono;

                            usuario.Celular = usuarioDB.Celular;
                            usuario.FechaNacimiento = usuarioDB.FechaNacimiento;

                            usuario.CURP = usuarioDB.CURP;

                            usuario.Rol.IdRol = usuarioDB.IdRol;
                            usuario.Rol.Nombre = usuarioDB.NombreRol;


                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }


                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        

          public ML.Result GetAll()
          {
              ML.Result result = new ML.Result();
              try
              {
                  var listaUsuarios = (from usuarioDb in _context.Usuarios
                                       join rolDb in _context.Rols on usuarioDb.IdRol equals rolDb.IdRol
                                       select new
                                       {
                                           usuarioDb.IdUsuario,
                                           usuarioDb.UserName,
                                           nombreUsuario = usuarioDb.Nombre,
                                           usuarioDb.ApellidoPaterno,
                                           usuarioDb.ApellidoMaterno,
                                           usuarioDb.Email,
                                           usuarioDb.Sexo,
                                           usuarioDb.Telefono,
                                           usuarioDb.Celular,
                                           usuarioDb.FechaNacimiento,
                                           usuarioDb.Curp,
                                           rolDb.IdRol,
                                           nombreRol = rolDb.Nombre,
                                       }).ToList();

                  if (listaUsuarios.Count > 0)
                  {
                      result.Objects = new List<object>();

                      foreach (var usuarioObj in listaUsuarios)
                      {
                          ML.Usuario usuario = new ML.Usuario();
                          usuario.IdUsuario = usuarioObj.IdUsuario;
                          usuario.UserName = usuarioObj.UserName;
                          usuario.Nombre = usuarioObj.nombreUsuario;
                          usuario.ApellidoPaterno = usuarioObj.ApellidoPaterno;
                          usuario.ApellidoMaterno = usuarioObj.ApellidoMaterno;
                          usuario.Email = usuarioObj.Email;
                          usuario.Sexo = usuarioObj.Sexo;
                          usuario.Telefono = usuarioObj.Telefono;
                          usuario.Celular = usuarioObj.Celular;
                          usuario.CURP = usuarioObj.Curp;

                          usuario.Rol = new ML.Rol();
                          usuario.Rol.IdRol = usuarioObj.IdRol;
                          usuario.Rol.Nombre = usuarioObj.nombreRol;

                          result.Objects.Add(usuario);
                      }

                      result.Correct = true;
                  }
                  else
                  {
                      result.Correct = false;
                      result.ErrorMessage = "No se encontraron registros.";
                  }
              }
              catch (Exception ex)
              {
                  result.Correct = false;
                  result.ErrorMessage = ex.Message;
                  result.Ex = ex;
              }

              return result;
          }

          */

        public static ML.Result GetByIdLINQ(int idUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {//No estoy seguro porque a rol le puso IdRolNavigation pero OK?
                using (DL.ErojasProgramacionNcapasContext context = new DL.ErojasProgramacionNcapasContext())
                {
                    var query = context.Usuarios
                                    .Include(u => u.IdRolNavigation)
                                    .FirstOrDefault(u => u.IdUsuario == idUsuario);

                    if (query != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario = query.IdUsuario;
                        usuario.UserName = query.UserName;
                        usuario.Nombre = query.Nombre;
                        usuario.ApellidoPaterno = query.ApellidoPaterno;
                        usuario.ApellidoMaterno = query.ApellidoMaterno;
                        usuario.Email = query.Email;
                        usuario.Password = query.Password;
                        usuario.Sexo = query.Sexo;
                        usuario.Telefono = query.Telefono;
                        usuario.Celular = query.Celular;
                        //usuario.FechaNacimiento = query.FechaNacimiento;
                        usuario.CURP = query.Curp;

                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = query.IdRol;
                        usuario.Rol.Nombre = query.IdRolNavigation?.Nombre;

                        result.Object = usuario;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontró el usuario";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }




        public static ML.Result AddLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.ErojasProgramacionNcapasContext context = new DL.ErojasProgramacionNcapasContext())
                {
                    DL.Usuario usuarioEF = new DL.Usuario
                    {
                        UserName = usuario.UserName,
                        Nombre = usuario.Nombre,
                        ApellidoPaterno = usuario.ApellidoPaterno,
                        ApellidoMaterno = usuario.ApellidoMaterno,
                        Email = usuario.Email,
                        Password = usuario.Password,
                        Sexo = usuario.Sexo,
                        Telefono = usuario.Telefono,
                        Celular = usuario.Celular,
                        FechaNacimiento = usuario.FechaNacimiento.HasValue
                        ? DateOnly.FromDateTime(usuario.FechaNacimiento.Value)
                        : null,
                        Curp = usuario.CURP,
                        IdRol = usuario.Rol.IdRol
                    };

                    context.Usuarios.Add(usuarioEF);
                    context.SaveChanges();

                    int idUsuario = usuarioEF.IdUsuario;
                    result.Object = idUsuario;
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static ML.Result UpdateLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.ErojasProgramacionNcapasContext context = new DL.ErojasProgramacionNcapasContext())
                {
                    var usuarioExistente = context.Usuarios
                    .FirstOrDefault(u => u.IdUsuario == usuario.IdUsuario);

                    if (usuarioExistente != null)
                    {
                        usuarioExistente.UserName = usuario.UserName;
                        usuarioExistente.Nombre = usuario.Nombre;
                        usuarioExistente.ApellidoPaterno = usuario.ApellidoPaterno;
                        usuarioExistente.ApellidoMaterno = usuario.ApellidoMaterno;
                        usuarioExistente.Email = usuario.Email;
                        usuarioExistente.Password = usuario.Password;
                        usuarioExistente.Sexo = usuario.Sexo;
                        usuarioExistente.Telefono = usuario.Telefono;
                        usuarioExistente.Celular = usuario.Celular;
                        usuarioExistente.FechaNacimiento = usuario.FechaNacimiento.HasValue
                            ? DateOnly.FromDateTime(usuario.FechaNacimiento.Value)
                            : null;
                        usuarioExistente.Curp = usuario.CURP;
                        usuarioExistente.IdRol = usuario.Rol.IdRol;

                        context.SaveChanges();
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Usuario no encontrado";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static ML.Result DeleteLINQ(int idUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.ErojasProgramacionNcapasContext context = new DL.ErojasProgramacionNcapasContext())
                {
                    var usuario = context.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);

                    if (usuario != null)
                    {
                        context.Usuarios.Remove(usuario);
                        context.SaveChanges();
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Usuario no encontrado";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

       
    }

}

    //Adding an abstract auto-property or overrinding an inherited auto-property requieress restarting aplication
    ////The call is ambiguos between the following methods
    //Type Usuario already defines a member called GetAll with the same parameter types
    //Updating the modifiers of method requiress restarting the aplication