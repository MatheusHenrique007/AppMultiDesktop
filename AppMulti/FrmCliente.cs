using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppMulti
{
    public partial class FrmCliente : Form
    {
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = new Cliente();
                if (cliente.RegistroRepetido(txtNome.Text,txtCelular.Text)==true)
                {
                    MessageBox.Show("Cliente já existe em nossa base de dados!", "Repetido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtNome.Text = "";
                    txtCelular.Text= "";
                    return;
                }
                else
                {
                    cliente.Inserir(txtNome.Text, txtCelular.Text);
                    MessageBox.Show("Cliente inserido com sucesso!", "Inserção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    List<Cliente> clientes = cliente.listacliente();
                    dgvClientes.DataSource = clientes;
                    txtNome.Text = "";
                    txtCelular.Text = "";
                    this.txtNome.Focus();
                }
            }
            catch (Exception er)
            {

                MessageBox.Show(er.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            List<Cliente> clientes = cliente.listacliente();
            dgvClientes.DataSource = clientes;
            btnEditar.ForeColor = System.Drawing.Color.Gray;
            btnEditar.Enabled = false;
            btnExcluir.ForeColor = System.Drawing.Color.Gray;
            btnExcluir.Enabled = false;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {

                int id = Convert.ToInt32(txtID.Text);
                Cliente cliente = new Cliente();
                cliente.Excluir(id);
                MessageBox.Show("Cliente excluido com sucesso", "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                List<Cliente> clientes = cliente.listacliente();
                dgvClientes.DataSource = clientes;
                txtNome.Text = "";
                txtCelular.Text = "";
                this.txtNome.Focus();
            }
            catch (Exception er)
            {

                MessageBox.Show(er.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            btnEditar.Enabled = true;
            btnEditar.BackColor = System.Drawing.Color.Green;
            btnExcluir.Enabled = true;
            btnExcluir.BackColor = System.Drawing.Color.Brown;
            try
            {
                int id = Convert.ToInt32(txtID.Text);
                Cliente cliente = new Cliente();
                cliente.Localizar(id);
                txtNome.Text = cliente.nome;
                txtCelular.Text = cliente.celular;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {

                int id = Convert.ToInt32(txtID.Text);
                Cliente cliente = new Cliente();
                cliente.Atualizar(id, txtNome.Text, txtCelular.Text);
                MessageBox.Show("Cliente atualizado com sucesso", "Atualização",MessageBoxButtons.OK, MessageBoxIcon.Information);
                List<Cliente> clientes = cliente.listacliente();
                dgvClientes.DataSource = clientes;
                txtNome.Text = "";
                txtCelular.Text = "";
                this.txtNome.Focus();
            }
            catch (Exception er)
            {

                MessageBox.Show(er.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                DataGridViewRow row = this.dgvClientes.Rows[e.RowIndex];
                this.dgvClientes.Rows[e.RowIndex].Selected = true;
                txtID.Text = row.Cells[0].Value.ToString();
                txtNome.Text = row.Cells[1].Value.ToString();
                txtCelular.Text = row.Cells[2].Value.ToString();

            }
            btnEditar.Enabled = true;
            btnEditar.BackColor = System.Drawing.Color.Green;
            btnExcluir.Enabled = true;
            btnExcluir.BackColor = System.Drawing.Color.Brown;
        }
    }
}
