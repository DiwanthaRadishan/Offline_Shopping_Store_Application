using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shopping_Store_Mangement_System
{
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
        }


        int startPosition;

        private void timer1_Tick(object sender, EventArgs e)
        {
            startPosition += 1;

            progressBar.Value = startPosition;
            if(progressBar.Value == 100 )
            {
                progressBar.Value = 0;
                timer1.Stop();
                login login = new login();
                this.Hide();
                login.Show();
            }
        }

        private void SplashForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
