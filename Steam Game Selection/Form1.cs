using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Steam_Game_Selection
{
    

    public partial class Form1 : Form
    {
        String[] game = new String[1000];
        float[] avg = new float[1000];
        float[] mdm = new float[1000];
        String[] appid = new String[1000];

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }
    }
}
