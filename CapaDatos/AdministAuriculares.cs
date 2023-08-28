using Back;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class AdministAuriculares : DatosConexion
    {
        public int abmAuriculares(string accion,Auricular objAuricular)
        {
            int resultado = -1;
            string orden = string.Empty;

            if (accion == "Alta")
              
                orden = $"insert into Auriculares (Marca,Caracteristicas,Codigo,Cantidad,Precio,FechaFabricacion) values ('{objAuricular.Marca}', '{objAuricular.Caracteristicas}', {objAuricular.Codigo}, {objAuricular.CantIngresar}, {objAuricular.Precio} , '{objAuricular.FechaFabricacion}' );";
            
            if (accion == "Modificar")
              
                orden = $"update Auriculares set Marca='{objAuricular.Marca}', Caracteristicas='{objAuricular.Caracteristicas}', Cantidad={objAuricular.CantIngresar}, Precio={objAuricular.Precio}, FechaFabricacion='{objAuricular.FechaFabricacion}' WHERE Codigo Like '%{objAuricular.Codigo}%';";
         
            if (accion == "Baja")
            
                orden = "delete from Auriculares  where Codigo=" + objAuricular.Codigo + ";";
          
           OleDbCommand cmd = new OleDbCommand(orden, conexion);

            try
            {
                Abrirconexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Errror al tratar de guardar,borrar o modificar algun auricular", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return resultado;
        }
        public DataSet listadoAuriculares(string cual)
        {
            string orden = string.Empty;
            if (cual != "Todos")
                orden = "select * from Auriculares where Codigo = " + int.Parse(cual) + ";";
            else
                orden = "select * from Auriculares;";

            OleDbCommand cmd = new OleDbCommand(orden, conexion);
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter();

            try
            {
                Abrirconexion();
                cmd.ExecuteNonQuery();
                da.SelectCommand = cmd;
                da.Fill(ds);
            }
            catch (Exception e)
            {
                throw new Exception("Error al listar Auricular", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return ds;
        }
    }
} 


    

