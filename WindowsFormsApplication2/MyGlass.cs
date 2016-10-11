using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing; // Пространство имен для картинок
using System.Windows.Forms; // пространство имен содержит классы для создания приложений Windows

namespace WindowsFormsApplication2
{
    class MyGlass:PictureBox
    {
        bool isHasBall; // булевая переменная, которая говорит нам, есть ли в наперстке шарик
        Image closedImg, withBallImg, emptyImg; // название картинок : закрытый наперсток, открытый наперсток с шариком, открытый наперсток пустой
        int id; // номер наперстка
        public bool IsHasBall // свойство переменной "есть ли в наперстке шарик"
        {
            get
            {
                return isHasBall;
            }

            set
            {
                isHasBall = value;
            }
        }

        public Image ClosedImg // свойство картинки "закрытый наперсток"
        {
            get
            {
                return closedImg;
            }

            set
            {
                closedImg = value;
            }
        }

        public Image WithBallImg // свойство картинки "открытый наперсток с шариком"
        {
            get
            {
                return withBallImg;
            }

            set
            {
                withBallImg = value;
            }
        }

        public Image EmptyImg // свойство картинки " открытый пустой наперсток"
        {
            get
            {
                return emptyImg;
            }

            set
            {
                emptyImg = value;
            }
        }

        public int Id // свойство целочисленной переменной, обозначающей номер наперстка
        {
            get
            {
                return id;
            }

            private set
            {
                id = value;
            }
        }

        public MyGlass(int id) // конструктор, в котором прописываются в полях адреса картинок
        {
            IsHasBall = false; // изначально наперсток пуст
            ClosedImg = Properties.Resources.Close; // ссылка на картинку. Все картинки хранятся в ресурсах
            WithBallImg = Properties.Resources.OpenedFull; // ссылка на картинку. Все картинки хранятся в ресурсах
            EmptyImg = Properties.Resources.OpenedEmpty; // ссылка на картинку. Все картинки хранятся в ресурсах
            Id = id; // номер наперстка
            Image = ClosedImg; // изначально наперсток закрыт
            Click += GlassClick; //обработчик события клик
        }
        public void GlassClick(object sender, EventArgs e) // метод нажать на стакан
        {
            if (Image == ClosedImg)
            {
                OpenGlass();
            }
            else
            {
                CloseGlass();
            }
        }
        public void OpenGlass()
        {
            if (IsHasBall) Image = WithBallImg;
            else Image = EmptyImg;
            Size = new Size(100, 100);
        }
        public void CloseGlass()
        {
            Image = ClosedImg;
            Size = new Size(80, 100);
        }
    }
}
