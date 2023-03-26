using Datos;
using Entidades;
using System;
using System.Windows.Forms;

namespace Examen2
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Activated(object sender, EventArgs e)
        {
            CodigoUsuarioTextBox.Focus();
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            if (CodigoUsuarioTextBox.Text == string.Empty)
            {
                errorProvider1.SetError(CodigoUsuarioTextBox, "Ingrese un usuario");
                return;
            }
            errorProvider1.Clear();
            if (ContraseñaTextBox.Text == "")
            {
                errorProvider1.SetError(CodigoUsuarioTextBox, "Ingrese una contraseña");
                return;
            }
            errorProvider1.Clear();

            //Validar en la base de datos
            Login login = new Login(CodigoUsuarioTextBox.Text, ContraseñaTextBox.Text);

            LoginDB usuarioDB = new LoginDB();
            Usuario usuario = new Usuario();

            usuario = usuarioDB.Autenticar(login);

            if (usuario != null)
            {

                if (usuario.EstaActivo)
                {
                    //Crea la Sesión
                    System.Security.Principal.GenericIdentity identidad = new System.Security.Principal.GenericIdentity(usuario.CodigoUsuario);
                    System.Security.Principal.GenericPrincipal principal = new System.Security.Principal.GenericPrincipal(identidad, new string[] { usuario.Rol });
                    System.Threading.Thread.CurrentPrincipal = principal;

                    //Mandarlo al menu

                    MenuForm menuFormulario = new MenuForm();
                    this.Hide();
                    menuFormulario.Show();


                }
                else
                {
                    MessageBox.Show("Error", "el usuario esta inactivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }


            }
            else
            {
                MessageBox.Show("Datos de usuario incorrectos");
            }
        }

        private void MostrarButton_Click(object sender, EventArgs e)
        {
            if (ContraseñaTextBox.PasswordChar == '*')
            {
                ContraseñaTextBox.PasswordChar = '\0';
            }
            else
            {
                ContraseñaTextBox.PasswordChar = '*';
            }
        }
    }
}
