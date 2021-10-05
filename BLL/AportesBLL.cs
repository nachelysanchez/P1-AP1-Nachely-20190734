using Microsoft.EntityFrameworkCore;
using P1_AP1_Nachely_20190734.DAL;
using P1_AP1_Nachely_20190734.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace P1_AP1_Nachely_20190734.BLL
{
    public class AportesBLL
    {
        /// <summary>
        /// Permite insertar o modificar una entidad en la base de datos
        /// </summary>
        /// <param name="aporte">La entidad que se desea guardar</param>
        public static bool Guardar(Aportes aporte)
        {
            if (Existe(aporte.AporteId))
            {
                return Insertar(aporte);
            }
            else
            {
                return Modificar(aporte);
            }
        }
        /// <summary>
        /// Permite insertar una entidad en la base de datos
        /// </summary>
        /// <param name="aporte">La entidad que se desea insertar</param>
        public static bool Insertar(Aportes aporte)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                //Agregar la entidad que se desea insertar al contexto
                contexto.Aportes.Add(aporte);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        /// <summary>
        /// Permite modificar una entidad en la base de datos
        /// </summary>
        /// <param name="aporte">La entidad que se desea modificar</param>
        public static bool Modificar(Aportes aporte)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(aporte).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        /// <summary>
        /// Permite eliminar una entidad en la base de datos
        /// </summary>
        /// <param name="id">El id de la entidad que se desea buscar</param>
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var aportes = contexto.Aportes.Find(id);
                if (aportes != null)
                {
                    contexto.Aportes.Remove(aportes);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static Aportes Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Aportes aporte;
            try
            {
                aporte = contexto.Aportes.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return aporte;
        }
        /// <summary>
        /// Permite obtener una lista filtrada por un criterio de busqueda
        /// </summary>
        /// <param name="criterio">La expresión que define el criterio de busqueda</param>
        /// <returns></returns>
        public static List<Aportes> GetList(Expression<Func<Aportes, bool>> criterio)
        {
            List<Aportes> lista = new List<Aportes>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Aportes.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Aportes.Any(r => r.AporteId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }
        public static List<Aportes> GetAportes()
        {
            List<Aportes> lista = new List<Aportes>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Aportes.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}
