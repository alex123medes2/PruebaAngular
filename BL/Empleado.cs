using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empleado
    {
        public static ML.Result GetAllEmpleado()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EmpleadoDbContext context = new DL.EmpleadoDbContext())
                {
                    var query = (from Empleado in context.Empleados select Empleado).ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var item in query)
                        {
                            ML.Empleado empleado = new ML.Empleado();
                            empleado.IdEmpleado = item.IdEmpleado;
                            empleado.NombreEmpleado = item.NombreEmpleado;
                            empleado.Edad = item.Edad;
                            empleado.CorreoElectronico = item.CorreoElectronico;
                            empleado.Area = new ML.Area();
                            empleado.Area.IdArea = item.IdArea;

                            result.Objects.Add(empleado);
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
        public static ML.Result GetByIdEmpleado(int IdEmpleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EmpleadoDbContext context = new DL.EmpleadoDbContext())
                {
                    var query = (from Empleado in context.Empleados
                                 where Empleado.IdArea == IdEmpleado
                                 select new
                                 {
                                     Empleado.IdEmpleado,
                                     Empleado.NombreEmpleado,
                                     Empleado.Edad,
                                     Empleado.CorreoElectronico,
                                     Empleado.IdArea
                                 }).SingleOrDefault();

                    if (query != null)
                    {
                        ML.Empleado empleado = new ML.Empleado();

                        empleado.IdEmpleado = query.IdEmpleado;
                        empleado.NombreEmpleado = query.NombreEmpleado;
                        empleado.Edad = query.Edad;
                        empleado.CorreoElectronico = query.CorreoElectronico;
                        empleado.Area = new ML.Area();
                        empleado.Area.IdArea = query.IdArea;

                        result.Object = empleado;
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
        public static ML.Result AddEmpleado(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EmpleadoDbContext context = new DL.EmpleadoDbContext())
                {
                    var query = context.Empleados.Add(new DL.Empleado
                    {
                        IdEmpleado = empleado.IdEmpleado,
                        NombreEmpleado = empleado.NombreEmpleado,
                        Edad = empleado.Edad.Value,
                        CorreoElectronico = empleado.CorreoElectronico,
                        IdArea = empleado.Area.IdArea
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
        public static ML.Result UpdateEmpleado(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EmpleadoDbContext context = new DL.EmpleadoDbContext())
                {
                    var query = (from Empleado in context.Empleados
                                 where Empleado.IdArea == empleado.IdEmpleado
                                 select Empleado).SingleOrDefault();

                    if (query != null)
                    {
                        query.IdEmpleado = empleado.IdEmpleado;
                        query.NombreEmpleado = empleado.NombreEmpleado;
                        query.Edad = empleado.Edad.Value;
                        query.CorreoElectronico = empleado.CorreoElectronico;
                        query.IdArea = empleado.Area.IdArea;

                        int rowAffected = context.SaveChanges();
                        if (rowAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Error al Actualizar el empleado";
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
        public static ML.Result DeleteEmpleado(int id)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EmpleadoDbContext context = new DL.EmpleadoDbContext())
                {
                    var query = (from Empleados in context.Empleados
                                 where Empleados.IdEmpleado == id
                                 select Empleados).SingleOrDefault();
                    context.Empleados.Remove(query);
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
