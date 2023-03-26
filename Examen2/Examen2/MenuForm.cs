using System;
using System.Windows.Forms;

namespace Examen2
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            UsuariosForm usuarioForm = new UsuariosForm();
            usuarioForm.MdiParent = this;
            usuarioForm.Show();
        }

        private void ClientesToolStripButton_Click(object sender, EventArgs e)
        {
            TicketForm clienteForm = new TicketForm();
            clienteForm.MdiParent = this;
            clienteForm.Show();
        }
    }
}
