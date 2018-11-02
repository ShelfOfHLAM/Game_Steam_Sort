using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace Steam_Game_Selection
{
    

    public partial class Form1 : Form
    {
        string[] mass = new string[140000];
        String[] game = new String[50000];
        String[] avg = new String[50000];
        String[] mdm = new String[50000];
        String[] appid = new String[50000];

        private void OpenUri(string uri)
        {
            webBrowser1.Navigate(uri);

            while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            webBrowser1.Navigate("https://steamdb.info/calculator/"+ textBox1.Text +"/");

        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            string htmlCod = "";

            richTextBox1.Clear();
            Array.Clear(mass, 0, 140000);
            Array.Clear(game, 0, 50000);
            Array.Clear(avg, 0, 50000);
            Array.Clear(mdm, 0, 50000);
            Array.Clear(appid, 0, 50000);

            int j = 0;

            htmlCod = webBrowser1.DocumentText;

            for (int i = 0; mass[j] != "</html>"; i++)
            {
                if (htmlCod[i] != '\n')
                {
                    mass[j] = mass[j] + htmlCod[i];

                }
                else j++;

            }

            for (int i = 0; i <= j; i++)
            {
                if (mass[i] == null) mass[i] = " ";

            }

            int z = 0;

            Regex regex = new Regex(@"<tr class=""app"" data-appid=""([0-9]+)");

            for (int i = 493; i <= j; i++)
            {
                MatchCollection matches = regex.Matches(mass[i]);

                foreach (Match match in matches)
                {
                    appid[z] = match.Groups[1].Value;
                    z++;

                }

            }

            for (int y = 0; y < z; y++)
            {
                OpenUri("https://steamdb.info/app/" + appid[y] + "/");

                htmlCod = webBrowser1.DocumentText;
                Array.Clear(mass,0,140000);

                j = 0;

                for (int i = 0; mass[j] != "</html>"; i++)
                {
                    if (htmlCod[i] != '\n')
                    {
                        mass[j] = mass[j] + htmlCod[i];

                    }
                    else j++;

                }

                for (int i = 0; i <= j; i++)
                {
                    if (mass[i] == null) mass[i] = " ";

                }

                regex = new Regex(@"<meta property=""og:title"" content=""([A-Z,0-9,:,', ,a-z,-]+)");

                MatchCollection matches = regex.Matches(mass[17]);
                
                foreach (Match match in matches)
                {
                    game[y] = match.Groups[1].Value;

                }

                int k = 0;

                regex = new Regex(@"<strong class=""steamspy-stats-ml"">([0-9,.]+)");

                for(int i = 0; i <= j; i++)
                {
                    if(mass[i].IndexOf("<strong class=\"steamspy-stats-ml\">") >= 0)
                    {
                        k = i;
                        break;
                    }

                }

                matches = regex.Matches(mass[k]);

                foreach (Match match in matches)
                {
                    mdm[y] = match.Groups[1].Value;

                } 

                matches = regex.Matches(mass[k + 4]);

                foreach (Match match in matches)
                {
                    avg[y] = match.Groups[1].Value;

                }

                richTextBox1.Text += (y+1) + " " + game[y] + " " + " " + avg[y] + " " + mdm[y] + "\n";

            }

         }

        private void button3_MouseClick(object sender, MouseEventArgs e)
        {


        }
    }
}
