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
using CapaNegocios;

namespace Front
{
    public partial class StockAuriculares : Form
    {
        //Intanciamos un objeto de la clase Auricular

        Auricular nuevoAuricular;
        Auricular AuriExistente;
        NegAuricular objNegAuricular = new NegAuricular();
        //DataTable dtStock = new DataTable() { TableName = "Stock" };
        //const string DIRECCION_XML = @"C:\Users\Ramiro\source\repos\Auriculares\";

        public StockAuriculares()
        {
            InitializeComponent();
            CrearDGV();
            LlenarDGV();

            //Creamos las columnas del data table
            //dtStock.Columns.Add("Marca");
            //dtStock.Columns.Add("Caracteristicas");
            //dtStock.Columns.Add("Codigo");
            //dtStock.Columns.Add("Fecha de Fabricacion");
            //dtStock.Columns.Add("Precio Individual");
            //dtStock.Columns.Add("Cantidad");

            //Leer_DT();
            //dgvStock.DataSource = dtStock;  


        }
        private void LlenarDGV()
        {
            dgvStock.Rows.Clear();
            DataSet ds = new DataSet();
            ds = objNegAuricular.listadoAuriculares("Todos");
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dgvStock.Rows.Add(dr[0].ToString(), dr[1], dr[2], dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
                }
            }
            else
                MessageBox.Show("No hay Auriculares cargados en el sistema");
        }
        private void CrearDGV()
        {
            dgvStock.Columns.Add("0", "Codigo");
            dgvStock.Columns.Add("1", "Marca");
            dgvStock.Columns.Add("2", "Caracteristicas");
            dgvStock.Columns.Add("3", "Cantidad");
            dgvStock.Columns.Add("4", "Precio");
            dgvStock.Columns.Add("5", "FechaFabricacion");

        }
        private void Vaciar_Todo()
        {
            txtCaract.Clear();
            txtCodigo.Clear();
            txtMarca.Clear();
            txtPrecio.Clear();
            nudCantIng.Value = 0;
        }
        private void btnCargar_Click(object sender, EventArgs e)
        {
            epvValidar.Clear();

            if (!Validar(0))
            {
                int nGrabados = -1;

                nuevoAuricular = new Auricular(txtMarca.Text, txtCaract.Text, int.Parse(txtCodigo.Text), (int)nudCantIng.Value, decimal.Parse(txtPrecio.Text), dtpFF.Value);

                nGrabados = objNegAuricular.abmAuriculares("Alta", nuevoAuricular);

                if (nGrabados == -1)
                {
                    MessageBox.Show("No se pudo cargar el producto en el sistema");
                }

                //nGrabados = objNegAuricular.abmAuriculares("Alta");


                //dtStock.Rows.Add(new object[] { auricular.Marca, auricular.Caracteristicas, auricular.Codigo, auricular.FechaFabricacion, auricular.Precio, auricular.CantIngresar });
                //dtStock.WriteXml(DIRECCION_XML + "auricular.xml");

                Vaciar_Todo();

                LlenarDGV();
            }
        }
        //Metodo para leer el archivo xml
        //private void Leer_DT()
        //{
        //    if (System.IO.File.Exists(DIRECCION_XML + "auricular.xml"))
        //    {
        //        dtStock.ReadXml(DIRECCION_XML + "auricular.xml");
        //    }
        //}
        //Metodo para verificar que todos los campos esten llenos
        private bool Validar(int boton)
        {
            bool validar = false;
            if (boton == 0)
            {
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
            }
            if (boton == 1)
            {
                if (txtBorrar.Text == "")
                {
                    epvValidar.SetError(txtBorrar, "Llenar campo");
                    validar = true;
                }
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
            if (!Validar(1))
            {
                DialogResult resultado = MessageBox.Show("¿Está seguro que desea eliminar el celular de codigo " + txtCodigo.Text + "?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    int nGrabados = -1;
                    nuevoAuricular = new Auricular(int.Parse(txtBorrar.Text));
                    nGrabados = objNegAuricular.abmAuriculares("Baja", nuevoAuricular);
                    LlenarDGV();


                }
            }
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            epvValidar.Clear();

            if (!Validar(0))
            {
                int nResultado = -1;
                nuevoAuricular = new Auricular(txtMarca.Text, txtCaract.Text, int.Parse(txtCodigo.Text), (int)nudCantIng.Value, decimal.Parse(txtPrecio.Text), dtpFF.Value);

                nResultado = objNegAuricular.abmAuriculares("Modificar", nuevoAuricular); //invoco a la capa de negocio

                if (nResultado != -1)
                {
                    MessageBox.Show("El celular fue Modificado con éxito", "Aviso");
                    Vaciar_Todo();
                    LlenarDGV();

                    txtCodigo.Enabled = true;

                }
                else
                    MessageBox.Show("Se produjo un error al intentar modificar el celular", "Error");
            }
               
        }
    }
}