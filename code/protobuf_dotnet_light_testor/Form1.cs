using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace protobuf_dotnet_light_testor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] files=           System.IO.Directory.GetFiles("..\\..\\data", "*.proto");
            foreach(var f in files)
            {
                listBox1.Items.Add(f);
            }

            string[] files2 = System.IO.Directory.GetFiles("..\\..\\data", "*.bin");
            foreach (var f in files2)
            {
                listBox2.Items.Add(f);
            }
        }
    }
}
