using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Area
    {
        public static ML.Result GetAllArea()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EmpleadoDbContext context = new DL.EmpleadoDbContext())
                {
                    var query = (from Areas in context.Areas
                                 select Areas).ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var item in query)
                        {
                            ML.Area area = new ML.Area();
                            area.IdArea = item.IdArea;
                            area.NombreArea = item.NombreArea;

                            result.Objects.Add(area);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Lista vacia";
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
        public static ML.Result GetByIdArea(int IdArea)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EmpleadoDbContext context = new DL.EmpleadoDbContext())
                {
                    var query = (from Areas in context.Areas
                                 where Areas.IdArea == IdArea
                                 select new
                                 {
                                     Areas.IdArea,
                                     Areas.NombreArea
                                 }).SingleOrDefault();

                    if (query != null)
                    {
                        ML.Area area = new ML.Area();
                        area.IdArea = query.IdArea;
                        area.NombreArea = query.NombreArea;

                        result.Object = area;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Lista vacia";
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
        public static ML.Result AddArea(ML.Area area)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EmpleadoDbContext context = new DL.EmpleadoDbContext())
                {
                    var query = context.Areas.Add(new DL.Area
                    {
                        IdArea = area.IdArea,
                        NombreArea = area.NombreArea
                    });
                    int rowAffected = context.SaveChanges();
                    if (rowAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al crear el area";
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
        public static ML.Result UpdateArea(ML.Area area)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EmpleadoDbContext context = new DL.EmpleadoDbContext())
                {
                    var query = (from Areas in context.Areas
                                 where Areas.IdArea == area.IdArea
                                 select Areas).SingleOrDefault();

                    if (query != null)
                    {
                        query.IdArea = area.IdArea;
                        query.NombreArea = area.NombreArea;

                        int rowAffected = context.SaveChanges();
                        if (rowAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Error al Actualizar el Area";
                        }
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
        public static ML.Result DeleteArea(int id)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EmpleadoDbContext context = new DL.EmpleadoDbContext())
                {
                    var query = (from Areas in context.Areas
                                 where Areas.IdArea == id
                                 select Areas).SingleOrDefault();
                    context.Areas.Remove(query);
                    context.SaveChanges();
                    if (query != null)
                    {
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al Borrar el Area";
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
        
    }
}
