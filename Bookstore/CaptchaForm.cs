using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Bookstore
{
    public partial class CaptchaForm : Form
    {
        private string _captcha;

        public CaptchaForm()
        {
            InitializeComponent();
        }

        private string GenerateStringCaptcha(int length)
        {
            const int minChar = 32;
            const int maxChar = 127;
            char[] result = new char[length];
            Random r = new Random();
            for (int i = 0; i < length; i++)
            {
                result[i] = (char)r.Next(minChar, maxChar);
            }
            return new string(result);
        }

        private Bitmap GenerateBitmapCaptcha(string captcha, int width, int height)
        {
            Bitmap image = new Bitmap(width, height);
            Graphics graphics = Graphics.FromImage(image);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.Clear(Color.White);
            Font font = new Font(FontFamily.GenericSerif, 36, FontStyle.Bold, GraphicsUnit.Pixel);
            RectangleF rect = new RectangleF(10, 10, width - 20, height - 20);
            HatchBrush hatchBrush = new HatchBrush(HatchStyle.SmallConfetti, Color.LightGray, Color.DarkGray);
            graphics.FillRectangle(hatchBrush, rect);
            graphics.DrawString(captcha, font, Brushes.Black, 10, 10);
            Pen pen = new Pen(Color.Gray, 1);
            Random r = new Random();
            for (int i = 0; i < 50; i++)
            {
                int x1 = r.Next(width);
                int y1 = r.Next(height);
                int x2 = r.Next(width);
                int y2 = r.Next(height);
                graphics.DrawLine(pen, x1, y1, x2, y2);
            }
            return image;
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            if(textBoxCaptcha.Text == _captcha)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            LoadCaptcha();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void LoadCaptcha()
        {
            _captcha = GenerateStringCaptcha(8);
            pictureBoxCaptcha.Image = GenerateBitmapCaptcha(_captcha, pictureBoxCaptcha.Width, pictureBoxCaptcha.Height);
        }

        private void CaptchaForm_Load(object sender, EventArgs e)
        {
            LoadCaptcha();
        }
    }
}
