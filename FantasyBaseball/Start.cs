using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FantasyBaseball
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            var f = new TeamSelection();
            f.Show();
        }
    }
}
