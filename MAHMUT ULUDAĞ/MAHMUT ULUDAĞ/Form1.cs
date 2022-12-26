using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAHMUT_ULUDAĞ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
       
        }

        #region load
        public RichTextBox rf;
        private void Form1_Load(object sender, EventArgs e)
        {

            foreach (FontFamily font in FontFamily.Families)
            {
                comboBox1.Items.Add(font.Name.ToString());
            }
            for (int a = 0; a < 120; a++) { }
        }
        #endregion
        #region open save
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text file - *.rtf | *.rtf";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (ofd.FileName != "" && ofd.FileName != null)
                {
                    StreamReader sr = new StreamReader(ofd.FileName);
                    richTextBox1.Text = sr.ReadToEnd();
                    sr.Close();
                }
                else
                {
                    MessageBox.Show("bos bırakma");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text file - *.rtf | *.rtf";
            if (sfd.ShowDialog() == DialogResult.OK)
            {

                if (sfd.FileName != null || sfd.FileName != "")
                {
                    StreamWriter sw = new StreamWriter(sfd.FileName);
                    sw.Write(richTextBox1.Text);
                    sw.Close();
                }
            }
            //SaveFileDialog sf = new SaveFileDialog();
            //sf.Filter = "Text file - *.rtf|*.rtf";

            //if (sf.ShowDialog() == DialogResult.OK)
            //{
            //    richTextBox1.SaveFile(sf.FileName);
            //}
        }
        #endregion
        #region undo redo
        private void button3_Click(object sender, EventArgs e)
        {
            if (richTextBox1.CanUndo)
            {
                richTextBox1.Undo();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (richTextBox1.CanRedo)
            {
                richTextBox1.Redo();
            }
        }
        #endregion
        #region combobx
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FontFamily newFamily = new FontFamily(comboBox1.SelectedItem.ToString());
            richTextBox1.SelectionFont = new Font(
               newFamily,
                richTextBox1.SelectionFont.Size
                );
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int a = int.Parse(comboBox2.SelectedItem.ToString());
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, a);
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem == "Bold")
            {
                richTextBox1.SelectionFont = new Font
                    (richTextBox1.SelectionFont.FontFamily,
                    richTextBox1.SelectionFont.Size,
                    richTextBox1.SelectionFont.Style ^ FontStyle.Bold
                    );
            }
            if (comboBox3.SelectedItem == "Italic")
            {
                richTextBox1.SelectionFont = new Font(
                    richTextBox1.SelectionFont.FontFamily,
                    richTextBox1.SelectionFont.Size,
                    richTextBox1.SelectionFont.Style ^ FontStyle.Italic
                    );
            }
            if (comboBox3.SelectedItem == "Underline")
            {
                richTextBox1.SelectionFont = new Font(
                    richTextBox1.SelectionFont.FontFamily,
                    richTextBox1.SelectionFont.Size,
                    richTextBox1.SelectionFont.Style ^ FontStyle.Underline
                    );
            }
            if (comboBox3.SelectedItem == "Regular")
            {
                richTextBox1.SelectionFont = new Font(
                    richTextBox1.SelectionFont.FontFamily,
                    richTextBox1.SelectionFont.Size,
                    richTextBox1.SelectionFont.Style ^ FontStyle.Regular
                    );
            }
        }
        #endregion
        #region colors
        private void button6_Click(object sender, EventArgs e)
        {
            ColorDialog cold = new ColorDialog();
            cold.ShowDialog();
            richTextBox1.SelectionColor = cold.Color;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ColorDialog cold = new ColorDialog();
            cold.ShowDialog();
            richTextBox1.SelectionBackColor = cold.Color;
        }
        #endregion
        #region ust alt karakter
        private void button9_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionCharOffset = 3;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionCharOffset = -3;
        }
        #endregion
        #region find
        private void button5_Click(object sender, EventArgs e)
        {
            Form2 findForm = new Form2();
            findForm.RtbInstance = this.richTextBox1;
            findForm.Show();
        }


        #endregion
        #region KAPATMA
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form3 frm = new Form3();
            e.Cancel = true;
            frm.Show();
        }
        #endregion    
    }
}
