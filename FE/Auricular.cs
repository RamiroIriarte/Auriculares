using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back
{
    public class Auricular
    {
        //Atributos
        private string marca;
        private string caracteristicas;
        private int codigo;
        private int cantIngresar;
        private decimal precio;
        private DateTime fechaFabricacion;

        //Contructores
        public Auricular()
        {

        }
        public Auricular(int codigo)
        {
            this.codigo = codigo;
        }
        public Auricular (string marca,string caracteristicas,int codigo,int cantIngresar,decimal precio,DateTime fechaFabricacion)
        {
            this.marca = marca;
            this.caracteristicas = caracteristicas;
            this.codigo = codigo;
            this.cantIngresar = cantIngresar;
            this.precio = precio;
            this.fechaFabricacion = fechaFabricacion;
        }       
        //Getters y Setters
        public string Marca { get { return marca; } set { marca = value; } }
        public string Caracteristicas { get { return caracteristicas; } set { caracteristicas = value; } }
        public int Codigo { get { return codigo; } set { codigo = value; } }
        public int CantIngresar { get { return cantIngresar; } set { cantIngresar = value; } }
        public decimal Precio { get { return precio; } set { precio = value; } }
        public DateTime FechaFabricacion { get { return fechaFabricacion; } set { fechaFabricacion = value; } }
    }
}
