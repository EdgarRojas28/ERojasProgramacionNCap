using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Rol
    {
        /*
        private readonly DL.ErojasProgramacionNcapasContext _context;

        public Rol(DL.ErojasProgramacionNcapasContext context)
        {
            _context = context;
        }*/
        public static ML.Result GetAll() //Lista Rol
        {
            ML.Result result = new ML.Result();
            try
            {
                {
                    using (DL.ErojasProgramacionNcapasContext context = new DL.ErojasProgramacionNcapasContext())
                    {
                        var listRoles = (from RolDB in context.Rols select RolDB).ToList();

                        if (listRoles.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (var item in listRoles)
                            {
                                ML.Rol rol = new ML.Rol();
                                rol.IdRol = item.IdRol;
                                rol.Nombre = item.Nombre;

                                result.Objects.Add(rol);
                            }

                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se encontraron registro";
                        }
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
