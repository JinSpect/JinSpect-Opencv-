using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JinSpect.Property
{
    public partial class PyramidProp : UserControl
    {
        public PyramidProp()
        {
            InitializeComponent();
        }
        public string SelectedDirection { get; private set; } = "Down";

        private void btnUP_CheckedChanged(object sender, EventArgs e)
        {
            SelectedDirection = "Up";
        }

        private void btnDown_CheckedChanged(object sender, EventArgs e)
        {
            SelectedDirection = "Down";
        }


    }
}
