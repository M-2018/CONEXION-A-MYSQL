using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD.FormConexion
{
    public partial class frmConexion : Form
    {
        public frmConexion()
        {
            InitializeComponent();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {

            //Ejemplo para conectarse  a una db mysql mediante un formulario

            String servidor = txtServidor.Text;
            String puerto = txtPuerto.Text;
            String usuario = txtUsuario.Text;
            String password = txtContrasena.Text;
            String bd = txtBd.Text;

            string cadenaConexion = "Server =" + servidor + "; Database =" + bd + "; Uid = " + usuario + "; Pwd =" + password;

            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion); //Se crea una nueva instancia de MySqlConnection
            MySqlDataReader reader = null; //Variable que nos ayuda a leer el resultado de nuestra consulta
            String data = null;

            try
            {
                String consulta = "SHOW DATABASES";
                MySqlCommand comando = new MySqlCommand(consulta);//MySqlCommand Representa una instrucción SQL para ejecutar en una base de datos MySQL.
                comando.Connection = conexionBD;
                conexionBD.Open();
                reader = comando.ExecuteReader();//ExecuteReader() Sends the CommandText to the Connection and builds a SqlDataReader.

                while (reader.Read())
                {
                    data += reader.GetString(0) + "\n";// GetString Returns the Recordset as a string, la posicion inicial es cero
                }
                MessageBox.Show(data);
                frmProductos productos = new frmProductos();
                productos.Show();
                this.Hide();


            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
        }
    }
}
