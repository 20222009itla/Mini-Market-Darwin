using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prueba_de_crud
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private const string CorrectUsername = "usuario";
        private const string CorrectPassword = "12345";

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;


            if (username == CorrectUsername && password == CorrectPassword)
            {
                // Si el login es exitoso, cerrar el LoginForm y abrir el MainForm
                this.Hide(); // Oculta el formulario de login
                Form mainForm = new Form(); // Crea una instancia del formulario principal
                mainForm.Show(); // Muestra el formulario principal
            }
            else
            {
                MessageBox.Show("Nombre de usuario o contraseña incorrectos", "Error de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
 




