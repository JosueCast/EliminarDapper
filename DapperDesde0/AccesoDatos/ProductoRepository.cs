using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public  class ProductoRepository
    {

        public List<Productos> ObtenerTodo()
        {
            using (var conexion = DataBase.GetSqlConnection())
            {
                string Query = @"SELECT [idProducto]
                                          ,[Nombre]
                                          ,[Precio]
                                          ,[Stock]
                                          ,[Descripcion]
                                          ,[Marca]
                                          ,[Proveedor]
                                      FROM [dbo].[Productos]";

                var cliente = conexion.Query<Productos>(Query).ToList();
                return cliente;
            }
        }

        public Productos GetById(string id)
        {

            using (var conexion = DataBase.GetSqlConnection())
            {

                string Query_Select_for_Id = @"
                                                SELECT [idProducto]
                                                      ,[Nombre]
                                                      ,[Precio]
                                                      ,[Stock]
                                                      ,[Descripcion]
                                                      ,[Marca]
                                                      ,[Proveedor]
                                                  FROM [dbo].[Productos] WHERE idProducto = @idProducto";

                var productos = conexion.QueryFirstOrDefault<Productos>(Query_Select_for_Id, new { idProducto = id });
                return productos;
            }

        }

        public int DeleteProducts(string Id)
        {

            using (var conexion = DataBase.GetSqlConnection())
            {

                String Delete = "";
                Delete = Delete + "DELETE FROM [dbo].[Productos] " + "\n";
                Delete = Delete + "      WHERE idProducto = @IdProductos";

                var eliminadas = conexion.Execute(Delete, new
                {
                    IdProductos = int.Parse(Id) 
                }) ;
                return eliminadas;
            }
        }




    }
}
