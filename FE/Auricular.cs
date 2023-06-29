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

        //Contructor
        public Auricular()
        {

        }
        //Getters y Setters
        public string Marca { get; set; }
        public string Caracteristicas { get; set; }
        public int Codigo { get; set; }
        public int CantIngresar { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaFabricacion { get; set; }
    }
}
