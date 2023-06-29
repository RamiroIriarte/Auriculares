using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Back;

namespace Front
{
    public partial class StockAuriculares : Form
    {
        //Intanciamos un objeto de la clase Auricular, creamos el data table y el archivo xml

        Auricular auricular = new Auricular();
        DataTable dtStock = new DataTable() { TableName = "Stock" };
        const string DIRECCION_XML = @"C:\Users\Ramiro\source\repos\Auriculares\";
        public StockAuriculares()
        {
            InitializeComponent();
            //Creamos las columnas del data table
            dtStock.Columns.Add("Marca");
            dtStock.Columns.Add("Caracteristicas");
            dtStock.Columns.Add("Codigo");
            dtStock.Columns.Add("Fecha de Fabricacion");
            dtStock.Columns.Add("Precio Individual");
            dtStock.Columns.Add("Cantidad");

            Leer_DT();
            dgvStock.DataSource = dtStock;  


        }
       private void btnCargar_Click(object sender, EventArgs e)
        {
            epvValidar.Clear();

            if (!Validar())
            {
                auricular.Marca = txtMarca.Text;
                auricular.Caracteristicas = txtCaract.Text;
                auricular.Codigo = Convert.ToInt32(txtCodigo.Text);
                auricular.FechaFabricacion = Convert.ToDateTime(dtpFF.Value); 
                auricular.Precio = Convert.ToDecimal(txtCodigo.Text);
                auricular.CantIngresar = Convert.ToInt32(nudCantIng.Value);
                

                dtStock.Rows.Add(new object[] { auricular.Marca, auricular.Caracteristicas, auricular.Codigo, auricular.FechaFabricacion, auricular.Precio, auricular.CantIngresar });
                dtStock.WriteXml(DIRECCION_XML + "auricular.xml");

                txtCaract.Clear();
                txtCodigo.Clear();
                txtMarca.Clear();
                txtPrecio.Clear();
                nudCantIng.Value = 0;
            }
        }
        //Metodo para leer el archivo xml
        private void Leer_DT()
        {
            if (System.IO.File.Exists(DIRECCION_XML + "auricular.xml"))
            {
                dtStock.ReadXml(DIRECCION_XML + "auricular.xml");
            }
        }
        //Metodo para verificar que todos los campos esten llenos
        private bool Validar()
        {
            bool validar = false;
            if (txtMarca.Text == "")
            {
                epvValidar.SetError(txtMarca, "Llenar campo");
                validar = true;
            }
            if (txtCaract.Text == "")
            {
                epvValidar.SetError(txtCaract, "Llenar campo");
                validar = true;
            }
            if (txtCodigo.Text == "")
            {
                epvValidar.SetError(txtCodigo, "Llenar campo");
                validar = true;
            }
            if (txtPrecio.Text == "")
            {
                epvValidar.SetError(txtPrecio, "Llenar campo");
                validar = true;
            }
            if (nudCantIng.Value == 0)
            {
                epvValidar.SetError(nudCantIng, "Llenar campo");
                validar = true;
            }
            return validar;

        }
        //Validacion para que no se puedan poner letras en los text box
        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvStock.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una fila");
            }
            else
            {
                int i = dgvStock.CurrentRow.Index;
                dtStock.Rows.RemoveAt(i);
            }

        }
    }
}