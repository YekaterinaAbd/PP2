using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator2
{
    public partial class Form1 : Form
    {
        Brain brain;
        public Form1()
        {
            InitializeComponent();
            brain = new Brain(new MyDelegate(ShowMsg));
            textBox2.Text = " ";

        }

        private void ShowMsg(string msg)
        {
            textBox1.Text = msg;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            brain.Go(button.Text);
            
            if (button.Text == "=")
            {
                textBox2.Clear();
            }
            if (Rules.IsNonzeroDIgit(button.Text) || Rules.IsOperation(button.Text))
            {
                textBox2.Text += button.Text + " ";
            }
           /*else if (textBox2.Text == "")
            {
                textBox2.Text = textBox1.Text + " " + button.Text + " ";
            }*/
            else { }

        }


    }
}
