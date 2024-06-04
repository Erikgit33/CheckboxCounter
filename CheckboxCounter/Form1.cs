using CheckboxCounter.Properties;
using System.Runtime.Versioning;
using System.Xml.Linq;

namespace CheckboxCounter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int x = 40;
        int y = 40;
        int index = 0;
        int column = 0;

        int amounttotal = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Location = new Point(35, 350);

            string[] lines = Resources.checkboxes.Split('\n');

            for (int i = 0; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(':');
                if (index == 9 || lines.Length % 10 == 0)
                {
                    x = 50 + 280 * (lines.Length / 10);
                    column++;
                }

                if (column == 0)
                {
                    y = 40 * index;
                }
                else if (column != 0)
                {
                    y = 40 * (index - (column*9));
                }

                CheckBox box = new CheckBox();
                box.Size = new Size(280, 40);
                box.Text = lines[index];
                box.Location = new Point(x, y);
                box.CheckedChanged += CheckBox_CheckChanged;
                Controls.Add(box);
                index++;

                if (box.Bounds.IntersectsWith(ClientRectangle))
                {
                    ClientSize = new Size(300 + box.Bounds.Width + 50, 390);
                }
            }
        }

        private void CheckBox_CheckChanged(object sender, EventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            string[] data = box.Text.Split(':');

            for (int i = 0; i < data.Length; i++)
            {
                int.TryParse(data[i], out int amount);

                if (box.Checked)
                {
                    amounttotal += amount;
                }
                if (box.Checked == false)
                {
                    amounttotal -= amount;
                }
            }
            label1.Text = "Amount: " + amounttotal;
        }
    }
}
