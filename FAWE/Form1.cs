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


        private void button1_Click_1(object sender, EventArgs e)
        {
            
            dataGridView1.Rows.Clear();
            addCharmToView(FireCharm.getInstance());
            addCharmToView(AirCharm.getInstance());
            addCharmToView(WaterCharm.getInstance());
            addCharmToView(EarthCharm.getInstance());
        }

        private void addCharmToView(Charm charm)
        {
            dataGridView1.Rows.Add();
            int index = dataGridView1.Rows.Count - 1;
            dataGridView1[0, index].Value = charm.ToString();
            dataGridView1[1, index].Value = "Level: " + charm.getLevel().ToString();
            String elemString = "";
            elemString += "Elements:" + "\n";
            foreach(ElementType elementType in Enum.GetValues(typeof(ElementType)))
            {
                elemString += "    " + elementType.ToString() + ": " + charm.getElements().getElement(elementType).ToString() + "\n";
            }
            dataGridView1[2, index].Value = elemString;
            String effString = "";
            effString += "Effects:" + "\n";
            foreach (EffectType effectType in Enum.GetValues(typeof(EffectType)))
            {
                effString += "    " + effectType.ToString() + ": " + charm.getEffectProbabilities()[(int)effectType] + "\n";
            }
            dataGridView1[3, index].Value = effString;
            dataGridView1[4, index].Value = charm;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                Charm a = (Charm)dataGridView1.SelectedRows[0].Cells[4].Value;
                addCharmToView(Combainer.combineCharms(a, a));
            } else
            if(dataGridView1.SelectedRows.Count == 2)
            {
                Charm a = (Charm)dataGridView1.SelectedRows[0].Cells[4].Value;
                Charm b = (Charm)dataGridView1.SelectedRows[1].Cells[4].Value;
                addCharmToView(Combainer.combineCharms(a, b));
            }
        }
    }
}
