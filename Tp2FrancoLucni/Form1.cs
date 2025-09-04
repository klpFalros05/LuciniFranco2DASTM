using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tp2FrancoLucni
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bntVerificar_Click(object sender, EventArgs e)
        {
            Verificador verificador = new Verificador();
            if (verificador.ok())
            {
                MessageBox.Show("Conexión exitosa");
            }
            else
            {
                MessageBox.Show("Error de conexión");
            }
        }
    }
}
