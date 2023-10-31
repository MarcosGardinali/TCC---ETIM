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
    public partial class Form4 : Form
    {

        MySqlConnection conexao;


        public Form4()
        {
            InitializeComponent();
        }

        private void btnADD_Click(object sender, EventArgs e)
        {

            Limpar();
        }
        private void Limpar()
        {
            txtCP.Clear();
            txtNomeP.Clear();
            txtTipo.Clear();
            txtPreco.Clear();
            txtCP. Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string strConexao = "server=localhost; database=TCC; uid=root; password=;";
            conexao = new MySqlConnection(strConexao);

            try
            {
                conexao.Open();
                MySqlDataAdapter adpProduto = new MySqlDataAdapter();
                DataTable tbProduto = new DataTable();
                int Cod_Produto;
                String Nome_Produto, Tipo, Preco;
                Cod_Produto = Convert.ToInt32(txtCP.Text);
                Nome_Produto = txtNomeP.Text;
                Tipo = txtTipo.Text;
                Preco = txtPreco.Text;
                String sql = "insert into Produtos (Cod_Produto, Nome_Produto, Tipo, Preco) values (" + Cod_Produto + ",'" + Nome_Produto + "','" + Tipo + "','" + Preco + "')";
                MySqlCommand adiciona = new MySqlCommand(sql, conexao);
                adpProduto.SelectCommand = adiciona;
                adpProduto.Fill(tbProduto);
                MessageBox.Show("Registro Salvo com sucesso", "SALVANDO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MySqlCommand cmdProduto = new MySqlCommand("SELECT * FROM Produtos ORDER BY Cod_Produto", conexao);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmdProduto;
                da.Fill(tbProduto);
                dataGridView1.DataSource = tbProduto;
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
                    MySqlDataAdapter adpProduto = new MySqlDataAdapter();
                    DataTable tbProduto = new DataTable();
                    MySqlCommand exclui = new MySqlCommand("delete from Produtos where Cod_Produto =" +
                        Convert.ToInt16(txtCP.Text), conexao);
                    adpProduto.SelectCommand = exclui;
                    adpProduto.Fill(tbProduto);
                    MessageBox.Show("Registro Excluido com sucesso!", "Excluindo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MySqlCommand cmdProduto = new MySqlCommand("SELECT * FROM Produtos ORDER BY Cod_Produto", conexao);
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmdProduto;
                    da.Fill(tbProduto);
                    dataGridView1.DataSource = tbProduto;
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

