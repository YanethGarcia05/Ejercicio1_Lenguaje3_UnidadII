using Datos;
namespace Tarea1_LP3
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void AceptarButton_Click(object sender, EventArgs e)
        {
            if (CodigoCorreoTextBox.Text == String.Empty)
            {
                errorProvider1.SetError(CodigoCorreoTextBox, "Ingrese un correo de usuario");
                CodigoCorreoTextBox.Focus();
                return;
            }
            errorProvider1.Clear();
            if (Contrase�aTextBox.Text == String.Empty)
            {
                errorProvider1.SetError(Contrase�aTextBox, "Ingrese una contrase�a");
                Contrase�aTextBox.Focus();
                return;
            }
            errorProvider1.Clear();
            UsuarioDatos userDatos = new UsuarioDatos(); 

            bool valido = await userDatos.LoginAsync(CodigoCorreoTextBox.Text, Contrase�aTextBox.Text);
            if (valido)
            {
               DatosCorrectos formulario = new DatosCorrectos();
               Hide();
               formulario.Show();
            }
            else
            {
                MessageBox.Show("Datos de usuario incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}