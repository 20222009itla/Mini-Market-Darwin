using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace prueba_de_crud
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void refressPantalla()
        {
            dataGridView2.DataSource = Almacenar.MostrarRegistro();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            refressPantalla();
            textBox11.Enabled = false; //Desactiva que se pueda acceder al ID, ya que es unico de cada item
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Crear un objeto Persona con los datos de los campos
                Personas1 persona1 = new Personas1();
                persona1.Nombre = textBox6.Text;
                persona1.Descripcion = textBox7.Text;
                persona1.Marca = textBox8.Text;
                persona1.Precio = Convert.ToInt32(textBox9.Text);
                persona1.Stock = Convert.ToInt32(textBox10.Text);



                //  if (dataGridView2.SelectedRows.Count > 1)

                // {

                // Comprobamos si hay un ID para determinar si es una inserción o una actualización
                int result = 0;
                if (string.IsNullOrEmpty(textBox11.Text)) // Si no tiene ID, se está agregando un nuevo registro
                {
                    result = Almacenar.AgregarDatos(persona1);
                    MessageBox.Show("Fue Agregado");

                }
                else // Si tiene un ID, se debe actualizar el registro existente
                {

                    persona1.id = Convert.ToInt32(textBox11.Text); // Set the ID to modify the existing record
                    result = Almacenar.ModificarData(persona1); // Método para actualizar los datos
                    MessageBox.Show("Fue Modificado");
                }

                // Comprobamos si el resultado fue exitoso y mostramos un mensaje
                if (result > 0)
                {
                    // MessageBox.Show("Exito guardado/actualizado");
                }
                //}
                else
                {
                    MessageBox.Show("No guardado Ni Actualizado");
                }

                refressPantalla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("no funciono" + ex.Message);
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            //if (dataGridView1.CurrentRow == null)
            {
                // Esto hace que se carguen los datos en los Textboxes
                textBox11.Text = Convert.ToString(dataGridView2.CurrentRow.Cells["Id"].Value);
                textBox6.Text = Convert.ToString(dataGridView2.CurrentRow.Cells["nombre"].Value);
                textBox7.Text = Convert.ToString(dataGridView2.CurrentRow.Cells["descripcion"].Value);
                textBox8.Text = Convert.ToString(dataGridView2.CurrentRow.Cells["marca"].Value);
                textBox9.Text = Convert.ToString(dataGridView2.CurrentRow.Cells["precio"].Value);
                textBox10.Text = Convert.ToString(dataGridView2.CurrentRow.Cells["stock"].Value);


            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            dataGridView2.CurrentCell = null;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentCell != null)
            {

                int id = Convert.ToInt32(textBox11.Text);
                int result = Almacenar.EliminarTodo(id);
                if (result > 0)
                {
                    MessageBox.Show("Eliminado");
                }
                else
                {
                    MessageBox.Show("No se elimino");
                }
                refressPantalla();
            }
        }

     
    }
}

