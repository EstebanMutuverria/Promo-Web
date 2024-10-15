using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Utils;

namespace Services
{
    public class ImagenServices
    {
        private DataBaseAccess DB = new DataBaseAccess();

        public List<Imagen> listar(int IdArticulo)
        {
            List<Imagen> list = new List<Imagen>();

            try
            {
                DB.setQuery("SELECT Id, IdArticulo, ImagenUrl as URL from IMAGENES Where IdArticulo = @IdArticulo");
                DB.setParameter("@IdArticulo", IdArticulo);
                DB.excecuteQuery();
                while (DB.Reader.Read())
                {
                    Imagen imagen = new Imagen();
                    imagen.Id = (int)DB.Reader["Id"];
                    imagen.IdArticulo = (int)DB.Reader["IdArticulo"];
                    imagen.ImagenUrl = (string)DB.Reader["URL"];

                    list.Add(imagen);
                }

                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                DB.CloseConnection();
            }
        }

        public void add(Imagen NewImagen)
        {
            try
            {
                DB.clearParameters();
                DB.setQuery("Insert into IMAGENES (IdArticulo, ImagenUrl) values (@IdArticulo, @ImagenUrl)");
                DB.setParameter("@IdArticulo", NewImagen.IdArticulo);
                DB.setParameter("@ImagenUrl", NewImagen.ImagenUrl);

                DB.excecuteAction();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                DB.CloseConnection();
            }
        }

        public void delete(Imagen imagen)
        {
            try
            {
                DB.clearParameters();
                DB.setQuery("DELETE from IMAGENES where id = @Id");
                DB.setParameter("@Id", imagen.Id);

                DB.excecuteAction();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                DB.CloseConnection();
            }
        }
    }
}
