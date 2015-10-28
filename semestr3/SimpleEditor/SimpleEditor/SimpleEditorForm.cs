using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleEditor
{
    public partial class SimpleEditorForm : Form
    {
        private Core core;
        private Bitmap bitmap;
        private Graphics graphics;

        public SimpleEditorForm()
        {
            InitializeComponent();
            pictureBox.BackColor = Color.White;
            core = new Core();
        }

        private void Init()
        {
            bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            pictureBox.Image = bitmap;
            graphics = Graphics.FromImage(bitmap);
        }

        private void DrawAllLines()
        {
            Init();
            Pen pen = new Pen(Color.Black, 2);
            foreach (var x in core.Lines)
            {
                float x1 = x.Coordinates[0] * pictureBox.Width / 100;
                float y1 = x.Coordinates[1] * pictureBox.Height / 100;
                float x2 = x.Coordinates[2] * pictureBox.Width / 100;
                float y2 = x.Coordinates[3] * pictureBox.Height / 100;
                graphics.DrawLine(pen, x1, y1, x2, y2);
            }
        }

        private void addLineButton_Click(object sender, EventArgs e)
        {
            core.UpdadeState();
            core.AddLine();
            DrawAllLines();
        }

        private void SimpleEditorForm_Resize(object sender, EventArgs e)
        {
            DrawAllLines();
        }

        private void deleteLineButton_Click(object sender, EventArgs e)
        {
            if (core.ActiveLine != null)
            {
                core.UpdadeState();
                core.DeleteLine();
                DrawAllLines();
            }
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            float xCoordinate = e.X * 100 / pictureBox.Width;
            float yCoordinate = e.Y * 100 / pictureBox.Height;
            core.SetActiveLine(xCoordinate, yCoordinate);
            DrawAllLines();
            if (core.ActiveLine != null)
            {
                core.SetRemovingLine(xCoordinate, yCoordinate);
                if (core.IsLineRemoving)
                {
                    core.UpdadeState();
                }
                Line activeLine = core.ActiveLine;
                DrawActiveLine(activeLine);
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (core.IsLineRemoving)
            {
                ChangeEnd(e);
                core.ChangingComplete();
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (core.IsLineRemoving)
            {
                ChangeEnd(e);
            }
        }

        private void ChangeEnd(MouseEventArgs e)
        {
            float xCoordinate = e.X * 100 / pictureBox.Width;
            float yCoordinate = e.Y * 100 / pictureBox.Height;
            core.ChangeEnd(xCoordinate, yCoordinate);
            Line activeLine = core.ActiveLine;
            DrawAllLines();
            DrawActiveLine(activeLine);
        }

        private void DrawActiveLine(Line activeLine)
        {
            float x1 = activeLine.Coordinates[0] * pictureBox.Width / 100;
            float y1 = activeLine.Coordinates[1] * pictureBox.Height / 100;
            float x2 = activeLine.Coordinates[2] * pictureBox.Width / 100;
            float y2 = activeLine.Coordinates[3] * pictureBox.Height / 100;
            graphics.DrawLine(new Pen(Color.Red, 2), x1, y1, x2, y2);
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            core.Undo();
            DrawAllLines();
        }

        private void redoButton_Click(object sender, EventArgs e)
        {
            core.Redo();
            DrawAllLines();
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            Init();
            string help = "To create new line click \r\n" +
                          "'Add line'. To delete line \r\n" +
                          "       click on line (it is \r\n" +
                          "   repainted into red) and \r\n" +
                          "   press 'Delete line'. \r\n" +
                          "  Click here to continue. \r\n";
            graphics.DrawString(help, new Font(Font.FontFamily, pictureBox.Height / 20), new SolidBrush(Color.Black), pictureBox.Width / 10 , 10);
        }
    }
}