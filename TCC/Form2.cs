using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;



namespace TCC
{
    public partial class Form2 : Form
    {

        MySqlConnection conexao;


        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 F1 = new Form1();
            F1.Show();
            Hide();
        }

        private void btnADD_Click_1(object sender, EventArgs e)
        {
            Limpar1();
        }
        private void Limpar1()
        {
            txtRG.Clear();
            txtNome.Clear();
            txtEndereco.Clear();
            txtTelefone.Clear();
            txtRG.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string strConexao = "server=localhost; database=TCC; uid=root; password=;";
            conexao = new MySqlConnection(strConexao);

            try
            {
                conexao.Open();
                MySqlDataAdapter adpCliente = new MySqlDataAdapter();
                DataTable tbClientes = new DataTable();
                int RG_Cliente;
                String Nome_Cliente, Endereco, Telefone;
                RG_Cliente = Convert.ToInt32(txtRG.Text);
                Nome_Cliente = txtNome.Text;
                Endereco = txtEndereco.Text;
                Telefone = txtTelefone.Text;
                String sql = "insert into clientes (RG_Cliente, Nome_Cliente, Endereco, Telefone) values (" + RG_Cliente + ",'" + Nome_Cliente + "','" + Endereco + "','" + Telefone + "')";
                MySqlCommand adiciona = new MySqlCommand(sql, conexao);
                adpCliente.SelectCommand = adiciona;
                adpCliente.Fill(tbClientes);
                MessageBox.Show("Registro Salvo com sucesso", "SALVANDO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MySqlCommand cmdCliente = new MySqlCommand("SELECT * FROM clientes ORDER BY RG_Cliente", conexao);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmdCliente;
                da.Fill(tbClientes);
                dataGridView1.DataSource = tbClientes;
            }
            catch (Exception E)
            { MessageBox.Show(E.Message); }
            finally
            {
                conexao.Close();
            }
        }

        private void btnExcluir_Click_1(object sender, EventArgs e)
        {
            string strConexao = "server=localhost; database=TCC; uid=root; password=;";
            conexao = new MySqlConnection(strConexao);
            if (MessageBox.Show("Tem certezaque deseja excluir esse registro?", "Cuidado",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                MessageBox.Show("Operação Cancelada");
            }
            else
            {
                try
                {
                    conexao.Open();
                    MySqlDataAdapter adpCliente = new MySqlDataAdapter();
                    DataTable tbClientes = new DataTable();
                    MySqlCommand exclui = new MySqlCommand("delete from clientes where RG_Cliente =" +
                        Convert.ToInt16(txtRG.Text), conexao);
                    adpCliente.SelectCommand = exclui;
                    adpCliente.Fill(tbClientes);
                    MessageBox.Show("Registro Excluido com sucesso!", "Excluindo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MySqlCommand cmdCliente = new MySqlCommand("SELECT * FROM clientes ORDER BY RG_Cliente", conexao);
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmdCliente;
                    da.Fill(tbClientes);
                    dataGridView1.DataSource = tbClientes;
                }
                catch (Exception E)
                { MessageBox.Show(E.Message); }
                finally
                { conexao.Close(); }
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Limpar();
        }
        private void Limpar()
        {
            txtRG.Clear();
            txtNome.Clear();
            txtEndereco.Clear();
            txtTelefone.Clear();
            txtRG.Focus();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string strConexao = "server=localhost; database=TCC; uid=root; password=;";
            conexao = new MySqlConnection(strConexao);

            try
            {
                conexao.Open();
                MySqlDataAdapter adpCliente = new MySqlDataAdapter();
                DataTable tbClientes = new DataTable();
                int RG_Cliente;
                String Nome_Cliente, Endereco, Telefone;
                RG_Cliente = Convert.ToInt32(txtRG.Text);
                Nome_Cliente = txtNome.Text;
                Endereco = txtEndereco.Text;
                Telefone = txtTelefone.Text;
                String sql = "insert into clientes (RG_Cliente, Nome_Cliente, Endereco, Telefone) values (" + RG_Cliente + ",'" + Nome_Cliente + "','" + Endereco + "','" + Telefone + "')";
                MySqlCommand adiciona = new MySqlCommand(sql, conexao);
                adpCliente.SelectCommand = adiciona;
                adpCliente.Fill(tbClientes);
                MessageBox.Show("Registro Salvo com sucesso", "SALVANDO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MySqlCommand cmdCliente = new MySqlCommand("SELECT * FROM clientes ORDER BY RG_Cliente", conexao);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmdCliente;
                da.Fill(tbClientes);
                dataGridView1.DataSource = tbClientes;
            }
            catch (Exception E)
            { MessageBox.Show(E.Message); }
            finally
            {
                conexao.Close();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            string strConexao = "server=localhost; database=TCC; uid=root; password=;";
            conexao = new MySqlConnection(strConexao);
            if (MessageBox.Show("Tem certezaque deseja excluir esse registro?", "Cuidado",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                MessageBox.Show("Operação Cancelada");
            }
            else
            {
                try
                {
                    conexao.Open();
                    MySqlDataAdapter adpCliente = new MySqlDataAdapter();
                    DataTable tbClientes = new DataTable();
                    MySqlCommand exclui = new MySqlCommand("delete from clientes where RG_Cliente =" +
                        Convert.ToInt16(txtRG.Text), conexao);
                    adpCliente.SelectCommand = exclui;
                    adpCliente.Fill(tbClientes);
                    MessageBox.Show("Registro Excluido com sucesso!", "Excluindo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MySqlCommand cmdCliente = new MySqlCommand("SELECT * FROM clientes ORDER BY RG_Cliente", conexao);
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmdCliente;
                    da.Fill(tbClientes);
                    dataGridView1.DataSource = tbClientes;
                }
                catch (Exception E)
                { MessageBox.Show(E.Message); }
                finally
                { conexao.Close(); }
            }
        }
    }
}

