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
    public partial class Form3 : Form
    {

        MySqlConnection conexao;


        public Form3()
        {
            InitializeComponent();
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            Limpar();
        }
        private void Limpar()
        {
            txtCNPJ.Clear();
            txtNomeF.Clear();
            txtTelefone.Clear();
            txtCNPJ.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string strConexao = "server=localhost; database=TCC; uid=root; password=;";
            conexao = new MySqlConnection(strConexao);

            try
            {
                conexao.Open();
                MySqlDataAdapter adpFornecedores = new MySqlDataAdapter();
                DataTable tbFornecedores = new DataTable();
                int CNPJ_Fornecedor;
                String Nome_Fornecedor, Telefone;
                CNPJ_Fornecedor = Convert.ToInt32(txtCNPJ.Text);
                Nome_Fornecedor = txtNomeF.Text;
                Telefone = txtTelefone.Text;
                String sql = "insert into Fornecedores (CNPJ_Fornecedor, Nome_Fornecedor, Telefone) values (" + CNPJ_Fornecedor + ",'" + Nome_Fornecedor + "','"  + Telefone + "')";
                MySqlCommand adiciona = new MySqlCommand(sql, conexao);
                adpFornecedores.SelectCommand = adiciona;
                adpFornecedores.Fill(tbFornecedores);
                MessageBox.Show("Registro Salvo com sucesso", "SALVANDO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MySqlCommand cmdFornecedores = new MySqlCommand("SELECT * FROM Fornecedores ORDER BY CNPJ_Fornecedor", conexao);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmdFornecedores;
                da.Fill(tbFornecedores);
                dataGridView1.DataSource = tbFornecedores;
            }
            catch (Exception E)
            { MessageBox.Show(E.Message); }
            finally
            {
                conexao.Close();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
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
                    MySqlDataAdapter adpFornecedores = new MySqlDataAdapter();
                    DataTable tbFornecedores = new DataTable();
                    MySqlCommand exclui = new MySqlCommand("delete from Fornecedores where CNPJ_Fornecedor =" +
                        Convert.ToInt16(txtCNPJ.Text), conexao);
                    adpFornecedores.SelectCommand = exclui;
                    adpFornecedores.Fill(tbFornecedores);
                    MessageBox.Show("Registro Excluido com sucesso!", "Excluindo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MySqlCommand cmdFornecedores = new MySqlCommand("SELECT * FROM Fornecedores ORDER BY CNPJ_Fornecedor", conexao);
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmdFornecedores;
                    da.Fill(tbFornecedores);
                    dataGridView1.DataSource = tbFornecedores;
                }
                catch (Exception E)
                { MessageBox.Show(E.Message); }
                finally
                { conexao.Close(); }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 F1 = new Form1();
            F1.Show();
            Hide();
        }
    }
    }


