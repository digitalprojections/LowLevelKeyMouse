using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly KeyboardListener keyboardListener;
        private readonly MouseListener mouseListener;

        public Form1()
        {
            InitializeComponent();

            keyboardListener = new KeyboardListener();
            mouseListener = new MouseListener();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            keyboardListener.HookedKeys.Add(Keys.A);
            keyboardListener.HookedKeys.Add(Keys.B);
            keyboardListener.KeyDown += new KeyEventHandler(KeyDownEventHandler);
            keyboardListener.KeyDownAll += new KeyEventHandler(KeyDownAllEventHandler);

            mouseListener.MouseLeftDown += MouseListener_MouseLeftDown;
            mouseListener.MouseLeftUp += MouseListener_MouseLeftUp;
            mouseListener.MouseRightDown += MouseListener_MouseRightDown;
            mouseListener.MouseRightUp += MouseListener_MouseRightUp;
            mouseListener.MouseMove += MouseListener_MouseMove;
        }

        private void MouseListener_MouseRightUp(object sender, MouseEventArgs e)
        {
            this.label2.Visible = false;
            this.textBox3.Text = $"{e.X},{e.Y}";
        }

        private void MouseListener_MouseRightDown(object sender, MouseEventArgs e)
        {
            this.label2.Visible = true;
            this.textBox3.Text = $"{e.X},{e.Y}";
        }

        private void MouseListener_MouseLeftUp(object sender, MouseEventArgs e)
        {
            this.label1.Visible = false;
            this.textBox3.Text = $"{e.X},{e.Y}";
        }

        private void MouseListener_MouseLeftDown(object sender, MouseEventArgs e)
        {
            this.label1.Visible = true;
            this.textBox3.Text = $"{e.X},{e.Y}";
        }
        private void MouseListener_MouseMove(object sender, MouseEventArgs e)
        {
            this.label1.Visible = true;
            this.textBox3.Text = $"{e.X},{e.Y}";
        }

        private void KeyDownEventHandler(object sender, KeyEventArgs e)
        {
            textBox1.Text += e.KeyCode.ToString();
            e.Handled = true;
        }

        private void KeyDownAllEventHandler(object sender, KeyEventArgs e)
        {
            textBox2.Text += e.KeyCode.ToString();
            e.Handled = true;
        }
    }
}
