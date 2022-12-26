using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAHMUT_ULUDAĞ
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        RichTextBox rtbInstance = null;
        public RichTextBox RtbInstance
        {
            set { rtbInstance = value; }
            get { return rtbInstance; }
        }

        public string InitialText
        {
            set { textBox1.Text = value; }
            get { return textBox1.Text; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string ad = rtbInstance.Text;
            if (rtbInstance.SelectedText != "")
            {
                rtbInstance.SelectedText = "";
                rtbInstance.Text = ad;
            }
            if (checkBox1.Checked)
            {
                rtbInstance.Find(textBox1.Text, 0, RichTextBoxFinds.MatchCase);
            }
            else
            {
                rtbInstance.Find(textBox1.Text, 0, RichTextBoxFinds.None);
            }
            rtbInstance.Select();

            if (rtbInstance.SelectedText == "")
            {

                MessageBox.Show(textBox1.Text + " BULUNAMADI");

            }
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
