using Microsoft.VisualBasic.Logging;

namespace Paint
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        Graphics graphic;
        bool paint = false;
        Point px, py;
        Pen pen = new Pen(Color.Black, 1);
        Pen erase = new Pen(Color.White, 30);
        int index;
        int start_X, start_Y, end_X, end_Y, length_X, length_Y;

        ColorDialog colorDialog = new ColorDialog();
        Color new_color;
       

        public Form1()
        {
            InitializeComponent();

            bitmap = new Bitmap(pic.Width,pic.Height);
            graphic = Graphics.FromImage(bitmap);
            //graphic.Clear(Color.White);            
            pic.Image = bitmap;
        }

      

        private void pic_MouseDown(object sender, MouseEventArgs e)
        {
            paint = true;
            py = e.Location;

            start_X = e.X;
            start_Y = e.Y;
        }      

        private void pic_MouseMove(object sender, MouseEventArgs e)
        {         
            if (paint)
            {
                if (index == 1)
                {
                    px = e.Location;
                    graphic.DrawLine(pen, px, py);
                    py = px;
                }
                if (index == 2)
                {
                    px = e.Location;
                    graphic.DrawLine(erase, px, py);
                    py = px;
                }
            }           

            end_X = e.X;
            end_Y = e.Y;
            length_X = e.X - start_X;
            length_Y = e.Y - start_Y;

            pic.Refresh();
        }

       

        private void pic_MouseUp(object sender, MouseEventArgs e)
        {
            paint = false;

            length_X = end_X - start_X;
            length_Y = end_Y - start_Y;

            if(index == 3)
            {
                graphic.DrawEllipse(pen, start_X, start_Y, length_X, length_Y);
            }

            if (index == 4)
            {
                graphic.DrawRectangle(pen, start_X, start_Y, length_X, length_Y);
            }

            if(index == 5)
            {
                graphic.DrawLine(pen, start_X, start_Y, end_X, end_Y);
            }

        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            graphic.Clear(Color.White);
            pic.Image = bitmap;
            index = 0;
        }

        private void btn_color_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            new_color = colorDialog.Color;
            pic_color.BackColor = colorDialog.Color;
            pen.Color = colorDialog.Color;
        }

        private void btn_pencil_Click(object sender, EventArgs e)
        {
            index = 1;
        }
        private void btn_eraser_Click(object sender, EventArgs e)
        {
            index = 2;
        }

        private void btn_ellipse_Click(object sender, EventArgs e)
        {
            index = 3;
        }
        private void btn_retangle_Click(object sender, EventArgs e)
        {
            index = 4;
        }

        private void btn_line_Click(object sender, EventArgs e)
        {
            index = 5;
        }

        private void pic_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (paint)
            {
                if (index == 3)
                {
                    g.DrawEllipse(pen, start_X, start_Y, length_X, length_Y);
                }

                if (index == 4)
                {
                    g.DrawRectangle(pen, start_X, start_Y, length_X, length_Y);
                }

                if (index == 5)
                {
                    g.DrawLine(pen, start_X, start_Y, end_X, end_Y);
                }
            }
            
        }
    }
}