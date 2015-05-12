using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    public partial class clockForm : Form
    {
        private Bitmap bitmap;
        private Graphics graphics;

        private Color color = Color.Black;

        public clockForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Рисуем часы.
        /// </summary>
        private void Draw(object sender, EventArgs e)
        {
            Init();
            DrawDial();
            timer.Start();
        }

        /// <summary>
        /// Создаем "холст"
        /// </summary>
        private void Init()
        {
            bitmap = new Bitmap(clockPictureBox.Width, clockPictureBox.Height);
            clockPictureBox.Image = bitmap;
            graphics = Graphics.FromImage(bitmap);
        }

        /// <summary>
        /// Ртсуем циферблат.
        /// </summary>
        private void DrawDial()
        {
            int size = Math.Min(clockPictureBox.Width, clockPictureBox.Height) / 2;
            DrawCircle(size);
            DrawMarking(size);
            DateTime time = DateTime.Now;
            double hourArgument = (time.Hour % 12) * Math.PI / 6 + time.Minute * Math.PI / 360 - Math.PI / 2;
            double minuteArgument =  time.Minute * Math.PI / 30 - Math.PI / 2;
            double secondArgument =  time.Second * Math.PI / 30 - Math.PI / 2;
            int hourRadius = size - 60;
            int minuteRadius = size - 30;
            int secondRadius = size - 20;
            DrawHand(new Pen(color, 3), hourRadius, hourArgument);
            DrawHand(new Pen(color, 3), minuteRadius, minuteArgument);
            DrawHand(new Pen(color, 1), secondRadius, secondArgument);
        }

        /// <summary>
        /// Рисуем окружность нужного размера
        /// </summary>
        private void DrawCircle(int size)
        {
            int x = clockPictureBox.Width / 2 - size + 10;
            int y = clockPictureBox.Height / 2 - size + 10;
            int temp = (size - 10) * 2;
            graphics.DrawEllipse(new Pen(color, 2), new Rectangle(x, y, temp, temp));
        }

        /// <summary>
        /// Разметка на циферблате.
        /// </summary>
        private void DrawMarking(int size)
        {
            int smallRadius, bigRadius;
            Pen pen;
            for (int i = 0; i < 60; ++i)
            {
                if (i % 5 == 0)
                {
                    smallRadius = size - 18;
                    bigRadius = size - 2;
                    pen = new Pen(color, 2);
                }
                else
                {
                    smallRadius = size - 15;
                    bigRadius = size - 5;
                    pen = new Pen(color, 1);
                }
                double argument = i * Math.PI / 30;
                float x1 = clockPictureBox.Width / 2 + Convert.ToSingle(smallRadius * Math.Cos(argument));
                float y1 = clockPictureBox.Height / 2 + Convert.ToSingle(smallRadius * Math.Sin(argument));
                float x2 = clockPictureBox.Width / 2 + Convert.ToSingle(bigRadius * Math.Cos(argument));
                float y2 = clockPictureBox.Height / 2 + Convert.ToSingle(bigRadius * Math.Sin(argument));
                graphics.DrawLine(pen, x1, y1, x2, y2);
            }
        }

        /// <summary>
        /// Стрелка (часовая, минутная, секундная).
        /// </summary>
        private void DrawHand(Pen pen, int size, double angle)
        {
            float x = clockPictureBox.Width / 2 + Convert.ToSingle(size * Math.Cos(angle));
            float y = clockPictureBox.Height / 2 + Convert.ToSingle(size * Math.Sin(angle));
            graphics.DrawLine(pen, clockPictureBox.Width / 2, clockPictureBox.Height / 2, x, y);
        }
    }
}
