using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class SharpAutoCenter : Form

    {
        public Form previousForm;
        public SharpAutoCenter()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        private void SharpAutoCenter_FormClosing(object sender, FormClosingEventArgs e)
        {


            DialogResult result = MessageBox.Show("Are You Sure?", "Confirm",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.OK)
            {
                this.previousForm.Close();
            }
            else
            {
                e.Cancel = true;
            }



        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {

        }

        private void SalesTaxLabel_Click(object sender, EventArgs e)
        {

        }

        private void TotalLabel_Click(object sender, EventArgs e)
        {

        }

        private void AmmountDueLabel_Click(object sender, EventArgs e)
        {

        }

        private void SubTotalLabel_Click(object sender, EventArgs e)
        {

        }

        private void AdditionalOptionsLabel_Click(object sender, EventArgs e)
        {

        }

        private void BasePriceLabel_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutForm = new AboutBox1();
            aboutForm.ShowDialog();
        }
    }
}
