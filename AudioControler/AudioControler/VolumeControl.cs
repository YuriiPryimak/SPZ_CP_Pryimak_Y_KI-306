using System;
using System.Drawing;
using System.Windows.Forms;

namespace AudioControler
{
    public partial class VolumeControl : UserControl
    {
        public event EventHandler ValueChanged;

        public VolumeControl()
        {
            InitializeComponent();
            this.Size = new Size(350, 30);
            this.BackColor = Color.Black;
            DoubleBuffered = true;
        }

        int default_value = 40;
        int minVolume = 0, maxVolume = 100;

        public int Max { get { return maxVolume; } set { maxVolume = value; Invalidate(); } }
        public int Min { get { return minVolume; } set { minVolume = value; Invalidate(); } }
        public int Value
        {
            get { return default_value; }
            set
            {
                if (default_value != value)
                {
                    default_value = value;
                    Invalidate();
                    OnValueChanged(EventArgs.Empty);
                }
            }
        }
        public int gap = 10;

        Color b_color = Color.Aqua;
        public Color Bar_color { get { return b_color; } set { b_color = value; Invalidate(); } }

        private void VolumeControl_Paint(object sender, PaintEventArgs e)
        {
            int start_point = 40;
            SolidBrush sb = new SolidBrush(Color.DimGray);
            for (int j = 0; j < (Max * ClientSize.Width / Max - 75) / gap; j++)
            {
                e.Graphics.FillRectangle(sb, new Rectangle(start_point, 0, gap - 5, ClientSize.Height));
                start_point += gap;
            }

            int buffer_point = 40;
            SolidBrush br = new SolidBrush(b_color);

            for (int i = 0; i < (default_value * ClientSize.Width / Max - default_value) / gap; i++)
            {
                e.Graphics.FillRectangle(br, new Rectangle(buffer_point, 0, gap - 2, ClientSize.Height));
                buffer_point += gap;
            }

            int thumb_size = 25;
            SolidBrush thumb = new SolidBrush(Color.White);
            e.Graphics.FillRectangle(thumb, new Rectangle(buffer_point, 0, thumb_size, ClientSize.Height));

            if (default_value >= Min)
            {
                Image left_img = Properties.Resources.down_img;
                e.Graphics.DrawImage(left_img, 5, 0, ClientSize.Height, ClientSize.Height);
            }
            if (default_value <= 50)
            {
                Image right_img = Properties.Resources.mid_img;
                e.Graphics.DrawImage(right_img, ClientSize.Width - 35, 0, ClientSize.Height, ClientSize.Height);
            }
            if (default_value <= Min)
            {
                Image left_img = Properties.Resources.mute_img;
                e.Graphics.DrawImage(left_img, 5, 0, ClientSize.Height, ClientSize.Height);
            }
            if (default_value >= 50)
            {
                Image right_img = Properties.Resources.high_img;
                e.Graphics.DrawImage(right_img, ClientSize.Width - 35, 0, ClientSize.Height, ClientSize.Height);
            }
        }

        private void Bar_value(float value)
        {
            if (value < Min) value = Min;
            if (value > Max) value = Max;
            if (default_value == value) return;
            default_value = (int)value;
            this.Refresh();
            OnValueChanged(EventArgs.Empty);
        }
        private float thumb_value(int x)
        {
            return Min + (Max - Min) * x / (float)(ClientSize.Width);
        }

        bool mouse = false;

        private void VolumeControl_MouseDown(object sender, MouseEventArgs e)
        {
            mouse = true;
            Bar_value(thumb_value(e.X));
        }

        private void VolumeControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mouse) return;
            Bar_value(thumb_value(e.X));
        }

        private void VolumeControl_MouseUp(object sender, MouseEventArgs e)
        {
            mouse = false;
            OnValueChanged(EventArgs.Empty);
        }

        protected virtual void OnValueChanged(EventArgs e)
        {
            ValueChanged?.Invoke(this, e);
        }
    }
}
