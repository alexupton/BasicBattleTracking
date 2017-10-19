using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicBattleTracking
{
    public partial class DPercentLine : UserControl
    {
        public DPercentDesigner sendingForm { get; set; }
        public int LineID { get; set; }
        public DPercentLine()
        {
            InitializeComponent();
        }

        private void DPercentLine_Load(object sender, EventArgs e)
        {

        }

        public string GetEffect()
        {
            if (effectBox.Text == "")
            {
                return "No effect";
            }
            else
            {
                return effectBox.Text;
            }
        }

        public int GetMin()
        {
            int result = -1;

            try
            {
                result = Int32.Parse(minBox.Text);
                if (result > 0)
                {
                    return result;
                }
                else
                    return -1;
            }
            catch
            {
                return -1;
            }
        }

        public int GetMax()
        {
            int result = -1;

            try
            {
                result = Int32.Parse(maxBox.Text);
                if (result > 0)
                {
                    return result;
                }
                else
                    return -1;
            }
            catch
            {
                return -1;
            }

        }

        public void SetMin()
        {
            minBox.Text = "1";
            minBox.ReadOnly = true;
        }

        public void UnsetMin()
        {
            minBox.ReadOnly = false;
        }

        public void SetMinToValue(int value)
        {
            minBox.Text = value.ToString();
        }
        public void SetMaxToValue(int value)
        {
            maxBox.Text = value.ToString();
        }

        private void xBox_Click(object sender, EventArgs e)
        {
            sendingForm.RemoveLine(this.LineID);
        }

        private void maxBox_TextChanged(object sender, EventArgs e)
        {
            if (GetMax() >= 0 && sendingForm != null)
            {
                sendingForm.UpdateMax();
            }
        }

        private void effectBox_TextChanged(object sender, EventArgs e)
        {

        }

        public void addEffect(string newEffect)
        {
            effectBox.Text = newEffect;
        }
    }
}
