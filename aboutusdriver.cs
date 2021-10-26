using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConductorAssistantSystem
{
    public partial class aboutusdriver : Form
    {
        public aboutusdriver()
        {
            InitializeComponent();
            lblname.Text = Form1.name;
        }

        private void panel5_MouseEnter(object sender, EventArgs e)
        {
            panel5.Focus();
        }

        private void lblhome_Click(object sender, EventArgs e)
        {
            driverbase dri = new driverbase();
            this.Visible = false;
            dri.Show();
        }

        private void lblconinfo_Click(object sender, EventArgs e)
        {
            conductorinfodriver cid = new conductorinfodriver();
            this.Visible = false;
            cid.Show();
        }

        private void lblresign_Click(object sender, EventArgs e)
        {
            resignpagedriver res = new resignpagedriver();
            this.Visible = false;
            res.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            editpagedriver ed = new editpagedriver();
            this.Visible = false;
            ed.Show();
        }

        private void lbllogout_Click(object sender, EventArgs e)
        {
            var val = MessageBox.Show("Are you sure?", "SeroSete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (val == DialogResult.Yes)
            {
                Form1 frm = new Form1();
                this.Visible = false;
                frm.Show();
            }
            else
            {
                //do nothing.
            }
        }
    }
}
