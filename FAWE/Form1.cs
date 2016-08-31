using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FAWE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Charm charm1 = FireCharm.getInstance();
            Charm charm2 = FireCharm.getInstance();

            Charm charm = Combainer.combineCharms(charm1, charm2);
            richTextBox1.Clear();
            richTextBox1.AppendText(charm.getLevel().ToString() + "\n");
            richTextBox1.AppendText(String.Join(" ", charm.getEffectProbabibilities()) + "\n");
            richTextBox1.AppendText(String.Join(" ", charm.getElements().getArray()) + "\n");


        }
    }
}
