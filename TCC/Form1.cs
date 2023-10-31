using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

      

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cLIENTESToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form2 F1 = new Form2();
            F1.Show();
            Hide();
        }

        private void fORNECEDORESToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form3 F3 = new Form3();
            F3.Show();
            Hide();
        }

        private void pRODUTOSToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form4 F4 = new Form4();
            F4.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void eNTRADAToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form6 F6 = new Form6();
            F6.Show();
            Hide();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void cadastroToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
