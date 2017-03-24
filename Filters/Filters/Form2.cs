using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Filters
{
    public partial class Form2 : Form
    {
       static public float[,] kernel;
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int n = (int)numericUpDown1.Value;
            int k = (int)numericUpDown2.Value;
            kernel = new float[n, k];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    if (dataGridView1[i, j].Style.BackColor == Color.Coral)
                    {
                        kernel[i, j] = 1;
                    }
                    else
                    {
                        kernel[i, j] = 0;
                    }
                }
            }
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = (int)numericUpDown1.Value;
            int k = (int)numericUpDown2.Value;
            dataGridView1.RowCount = n;
            dataGridView1.ColumnCount = k;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentCell.Style.BackColor = Color.Coral;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentCell.Style.BackColor = Color.Coral;
        }
    }
}
