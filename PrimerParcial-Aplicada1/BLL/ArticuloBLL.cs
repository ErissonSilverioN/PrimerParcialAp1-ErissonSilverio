using Microsoft.EntityFrameworkCore;
using PrimerParcial_Aplicada1.DAL;
using PrimerParcial_Aplicada1.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrimerParcial_Aplicada1.BLL
{
    public class ArticuloBLL
    {

        public static bool Guardar(Articulos articulos)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {

                if (db.articulos.Add(articulos) != null)
                    paso = db.SaveChanges() > 0;


            }
            catch (Exception)
            {
                throw;
            }
            finally {


                db.Dispose();
            }

            return paso;
        }

        public static bool Modificar(Articulos articulos)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {

                db.Entry(articulos).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;


            }
            catch (Exception)
            {
                throw;
            }
            finally
            {


                db.Dispose();
            }

            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            

            try
            {

               var eliminar = db.articulos.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;
                paso = db.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {


                db.Dispose();
            }

            return paso;
        }


        public static Articulos Buscar(int id)
        {
            
            Contexto db = new Contexto();
            Articulos articulos = new Articulos();

            try
            {

                articulos = db.articulos.Find(id);


            }
            catch (Exception)
            {
                throw;
            }
            finally
            {


                db.Dispose();
            }

            return articulos;
        }

    }
}
