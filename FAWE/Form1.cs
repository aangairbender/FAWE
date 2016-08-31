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
            Charm charm = FireCharm.getInstance();
            charm = Combainer.combineCharms(charm, FireCharm.getInstance());
            charm = Combainer.combineCharms(charm, FireCharm.getInstance());
            charm = Combainer.combineCharms(charm, FireCharm.getInstance());
            //for (int i = 0; i < 4; ++i) charm = Combainer.combineCharms(charm, FireCharm.getInstance());


            richTextBox1.Clear();
            richTextBox1.AppendText(charm.getLevel().ToString() + "\n");
            richTextBox1.AppendText(String.Join(" ", charm.getEffectProbabibilities()) + "\n");
            richTextBox1.AppendText(String.Join(" ", charm.getElements().getArray()) + "\n");

            /*int success = 0;

            for (int i = 0; i < 100; ++i)
            {
                Spell spell = Combainer.createSpell(charm, CarcaseType.Sphere);
                if (spell.getEffects().Count > 0) success++;
            }
            richTextBox1.AppendText(success.ToString() + " / " + "100");*/

        }
    }
}
