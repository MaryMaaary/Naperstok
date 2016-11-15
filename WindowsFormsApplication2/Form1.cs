﻿using System;
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
        Thread t1, t2, t3;
        string name;//


        public MainForm()
        {
            InitializeComponent();

            glass1 = new MyGlass(1);
            glass2 = new MyGlass(2);
            glass3 = new MyGlass(3); // добавила текст

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


            Random rnd = new Random(); // изменила название переменной
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
            Rotate();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
           
        }
        public void textBox1_KeyUp(object sender, KeyEventArgs e) // метод происходит, когда отпускается клавиша, если элемент управления имеет фокус
        {
           if (e.KeyCode==Keys.Enter) // если мы нажали и отпустили клавишу Enter система пишет "Привет, (имя пользователя)
           {
            name = textBox1.Text; // (имя пользователя) это текст, который пользователь вводит в поле "введите имя"
            MessageBox.Show("Привет," +name +"!"); // система выводит "Привет, (имя пользователя)!"
           }
        }
       bool go1, go2, go3;
        int[] mas1;
        void Rotate()
        {
            go1 = true;
            go2 = true;
            go3 = true;
            int[] mas0 = new int[] { 90, 190, 290 };
            Random rndom = new Random();
            mas1 = mas0.OrderBy(item => rndom.Next()).ToArray(); //конструкция позволяет перемешать массив рандомно из элементов mas0. результат записывается в новый массив
            t1 = new Thread(StartMovement1);
            t2 = new Thread(StartMovement2);
            t3 = new Thread(StartMovement3);
            t1.IsBackground = true;
            t2.IsBackground = true;
            t3.IsBackground = true;
            t1.Start();
            t2.Start();
            t3.Start();

        }
       void StartMovement1()// метод для потока 1
        {
            HelperDelegate1 = new Helper(MotionFirst);
            while (go1)
            {
                Thread.Sleep(300);
                Invoke(HelperDelegate1);
            }

        }
        void StartMovement2()
        {
            HelperDelegate2 = new Helper(MotionSecond);
            while (go2)
            {
                Thread.Sleep(200);
                Invoke(HelperDelegate2);
            }

        }
        void StartMovement3()
        {
            HelperDelegate3 = new Helper(MotionThird);
            while (go3)
            {
                Thread.Sleep(100);
                Invoke(HelperDelegate3);
            }
        }
        void MotionFirst()
        {
            if (glass1.Location.X > mas1[0])
            {


                glass1.Location = new Point(glass1.Location.X - 1, glass1.Location.Y);

            }
            else
                if (glass1.Location.X < mas1[0])
                {

                    glass1.Location = new Point(glass1.Location.X + 1, glass1.Location.Y);

                }
            if (glass1.Location.X == mas1[0]) go1 = false;
        }
        void MotionSecond()
        {
            if (glass2.Location.X > mas1[1])
            {


                glass2.Location = new Point(glass2.Location.X - 1, glass2.Location.Y);


            }
            else
                if (glass2.Location.X < mas1[1])
                {

                    glass2.Location = new Point(glass2.Location.X + 1, glass2.Location.Y);


                }
            if (glass2.Location.X == mas1[1]) go2 = false;
        }
        void MotionThird()
        {
            if (glass3.Location.X > mas1[2])
            {


                glass3.Location = new Point(glass3.Location.X - 1, glass3.Location.Y);

            }
            else
                if (glass3.Location.X < mas1[2])
                {


                    glass3.Location = new Point(glass3.Location.X + 1, glass3.Location.Y);

                }
            if (glass3.Location.X == mas1[2]) go3 = false;
        }
    }
}
