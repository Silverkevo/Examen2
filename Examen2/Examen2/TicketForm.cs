using Datos;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Examen2
{
    public partial class TicketForm : Form
    {
        public TicketForm()
        {
            InitializeComponent();
        }
        string tipoOperacion = string.Empty;
        ClienteDB clienteDB = new ClienteDB();
        Cliente cliente = new Cliente();
        DataTable dt = new DataTable();
        decimal precio = 0;
        decimal subTotal = 0;
        decimal isv = 0;
        decimal totalAPagar = 0;
        decimal descuento = 0;
        private void NuevoButton_Click(object sender, EventArgs e)
        {
            HabilitarControles();
            PrecioTextBox.Clear();
            SubTotalTextBox.Clear();
            IsvTextBox.Clear();
            TotalTextBox.Clear();

            GuardarButton.Enabled = true;
            tipoOperacion = "Nuevo";
        }
        private void HabilitarControles()
        {
            IdentidadTextBox.Enabled = true;
            NombreTextBox.Enabled = true;
            TelefonoTextBox.Enabled = true;
            DireccionTextBox.Enabled = true;
            NacimientoDateTimePicker.Enabled = true;
            CancelarButton.Enabled = true;
            GuardarButton.Enabled = true;

        }

        private void DeshabilitarControles()
        {
            IdentidadTextBox.Enabled = false;
            NombreTextBox.Enabled = false;
            TelefonoTextBox.Enabled = false;
            DireccionTextBox.Enabled = false;
            NacimientoDateTimePicker.Enabled = false;
            CancelarButton.Enabled = false;
            GuardarButton.Enabled = false;
        }

        private void LimpiarControles()
        {
            IdentidadTextBox.Clear();
            NombreTextBox.Clear();
            TelefonoTextBox.Clear();
            DireccionTextBox.Text = "";
            NacimientoDateTimePicker.Text = null;


        }


        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (tipoOperacion == "Nuevo")
            {
                if (string.IsNullOrEmpty(IdentidadTextBox.Text))
                {
                    errorProvider1.SetError(IdentidadTextBox, "Ingrese la identidad");
                    IdentidadTextBox.Focus();
                    return;
                }
                errorProvider1.Clear();
                if (string.IsNullOrEmpty(NombreTextBox.Text))
                {
                    errorProvider1.SetError(NombreTextBox, "Ingrese el nombre");
                    NombreTextBox.Focus();
                    return;
                }
                errorProvider1.Clear();
                if (string.IsNullOrEmpty(TelefonoTextBox.Text))
                {
                    errorProvider1.SetError(TelefonoTextBox, "Ingrese un telefono");
                    TelefonoTextBox.Focus();
                    return;
                }
                errorProvider1.Clear();
                if (string.IsNullOrEmpty(DireccionTextBox.Text))
                {
                    errorProvider1.SetError(DireccionTextBox, "Ingrese una direccion");
                    DireccionTextBox.Focus();
                    return;
                }
                errorProvider1.Clear();


                cliente.Identidad = IdentidadTextBox.Text;
                cliente.Nombre = NombreTextBox.Text;
                cliente.Telefono = TelefonoTextBox.Text;
                cliente.Direccion = DireccionTextBox.Text;
                cliente.Fecha = Convert.ToDateTime(NacimientoDateTimePicker.Text);
                cliente.TipoSoporte = SoporteComboBox.Text;
                cliente.DescripcionSoporte = DescripcionTextBox.Text;

                precio = Convert.ToDecimal(PrecioTextBox.Text);
                descuento = Convert.ToDecimal(DescuentoTextBox.Text);
                isv = precio * 0.15M;
                subTotal = precio + isv;
                totalAPagar = subTotal - descuento;

                SubTotalTextBox.Text = subTotal.ToString();
                IsvTextBox.Text = isv.ToString();
                TotalTextBox.Text = totalAPagar.ToString();

                //Insertar en la base de datos

                bool inserto = clienteDB.Insertar(cliente);
                if (inserto)
                {
                    DeshabilitarControles();
                    LimpiarControles();
                    TraerClientes();
                    MessageBox.Show("Ticket guardado con exito");
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el ticket");
                }
            }

        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            if (ClientesDataGridView.SelectedRows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("¿Seguro de eliminar el registro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    bool elimino = clienteDB.Eliminar(ClientesDataGridView.CurrentRow.Cells["Identidad"].Value.ToString());
                    if (elimino)
                    {
                        MessageBox.Show("Registro eliminado correctamente");
                        TraerClientes();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el registro");
                    }
                }


            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro");
            }
        }
        private void TraerClientes()
        {
            DataTable dt = new DataTable();
            dt = clienteDB.DevolverClientes();
            ClientesDataGridView.DataSource = dt;
        }

        private void ClienteForm_Load(object sender, EventArgs e)
        {
            CodigoUsuarioTextBox.Text = System.Threading.Thread.CurrentPrincipal.Identity.Name;
            TraerClientes();
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {

            DeshabilitarControles();
            LimpiarControles();
            GuardarButton.Enabled = false;
            EliminarButton.Enabled = false;
            CancelarButton.Enabled = false;
        }

        private void TelefonoTextBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
                errorProvider1.Clear();
            }
            else
            {
                e.Handled = true;
                errorProvider1.SetError(TelefonoTextBox, "Ingrese solo valores numericos");
            }
        }

        private void IdentidadTextBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
                errorProvider1.Clear();
            }
            else
            {
                e.Handled = true;
                errorProvider1.SetError(IdentidadTextBox, "Ingrese solo valores numericos");
            }
        }

    }
}
