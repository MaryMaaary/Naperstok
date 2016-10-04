using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    class MyGlass:PictureBox
    {
        bool isHasBall;
        Image closedImg, withBallImg, emptyImg;
        int id;
        public bool IsHasBall
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

        public Image ClosedImg
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

        public Image WithBallImg
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

        public Image EmptyImg
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

        public int Id
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

        
    }
}
