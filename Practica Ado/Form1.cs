namespace Practica_Ado
{
    public partial class Form1 : Form
    {
        RepositorioSocios repositorio = new RepositorioSocios();
        public Form1()
        {
            InitializeComponent();
            Forms();
        }

        private void Forms()
        {
            dataGridView1.DataSource = repositorio.Listar();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
