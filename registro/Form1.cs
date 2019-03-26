using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace registro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //conexion con la base de datos
        SqlConnection conex = new SqlConnection("server=EMANUELMR-OMEN\\SQLEXPRESS;database=registro;integrated security = true");

        private void agregaralumno(int nocontrol, string nom, string appat, string apmat)
        {
            conex.Open();
            string cadena = "insert into alumnos(nocontrol,nombre,apepat,apemat) values("+nocontrol+",'"+nom+"','"+appat+"','"+apmat+"')";
            SqlCommand comando = new SqlCommand(cadena, conex);
            comando.ExecuteNonQuery();
            conex.Close();
        }

        private bool verificaralumno(int nocontrol)
        {
            bool bandera = false;
            conex.Open();
            string cadena = "select apepat,apemat from alumnos where nocontrol ="+nocontrol;
            SqlCommand comando = new SqlCommand(cadena, conex);
            SqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                bandera = true;
                textBox3.Text = registro["apepat"].ToString();
                textBox4.Text = registro["apemat"].ToString();
            }
            else
            {
                bandera = false;
            }
            conex.Close();
            return bandera;
        }

        private void registrardia(int nocontrol)
        {
            conex.Open();
            string cadena = "insert into registrodia (nocontrol,fecha) values (" + nocontrol + ",GETDATE())";
            SqlCommand comando = new SqlCommand(cadena, conex);
            comando.ExecuteNonQuery();
            conex.Close();
        }

        private void limpiar()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                //solo se agrega al dia
                bool encontrado = verificaralumno(Convert.ToInt32(textBox1.Text));
                if (encontrado == true)
                {
                    registrardia(Convert.ToInt32(textBox1.Text));
                    listBox1.Items.Add(textBox1.Text + " " + textBox3.Text + " " + textBox4.Text);
                    limpiar();
                }
                else
                {
                    MessageBox.Show("El alumno no fue encontrado");
                }

            }
            else if (radioButton1.Checked == true)
            {
                //se registra y agrega al dia
                bool encontrado = verificaralumno(Convert.ToInt32(textBox1.Text));
                if (encontrado == false)
                {
                    agregaralumno(Convert.ToInt32(textBox1.Text),textBox2.Text,textBox3.Text,textBox4.Text);
                    registrardia(Convert.ToInt32(textBox1.Text));
                    listBox1.Items.Add(textBox1.Text + " " + textBox3.Text + " " + textBox4.Text);
                    limpiar();
                }
                else
                {
                    MessageBox.Show("El alumno ya habia sido registrado");
                }
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked == true)
            {
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
            }
        }
    }
}
