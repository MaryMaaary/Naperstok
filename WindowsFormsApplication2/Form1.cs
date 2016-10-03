using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class MainForm : Form
    {
        public delegate void Helper();
        public Helper HelperDelegate1, HelperDelegate2, HelperDelegate3;
        MyGlass glass1, glass2, glass3;

       

        public MainForm()
        {
            InitializeComponent();

            glass1 = new MyGlass(1);
            glass2 = new MyGlass(2);
            glass3 = new MyGlass(3);

            glass1.Size = new Size(150, 180);
            glass2.Size = new Size(150, 180);
            glass3.Size = new Size(150, 180);

            glass1.SizeMode = PictureBoxSizeMode.StretchImage;
            glass2.SizeMode = PictureBoxSizeMode.StretchImage;
            glass3.SizeMode = PictureBoxSizeMode.StretchImage;

            glass1.Location = new Point(90, 50);
            glass2.Location = new Point(190, 50);
            glass3.Location = new Point(290, 50);
            

            glass1.BackColor = Color.Transparent;
            glass2.BackColor = Color.Transparent;
            glass3.BackColor = Color.Transparent;

            Random rnd = new Random();
            int num = rnd.Next(1, 4);
            if (glass1.Id == num) glass1.IsHasBall = true;
            if (glass2.Id == num) glass2.IsHasBall = true;
            if (glass3.Id == num) glass3.IsHasBall = true;
            glass1.OpenGlass();
            glass2.OpenGlass();
            glass3.OpenGlass();
            Controls.Add(glass1);
            Controls.Add(glass2);
            Controls.Add(glass3);
        }
        private void goButton_Click(object sender, EventArgs e)
        {
            glass1.CloseGlass();
            glass2.CloseGlass();
            glass3.CloseGlass();
        }
    }
}
