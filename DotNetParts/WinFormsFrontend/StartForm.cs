using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsFrontend
{
    /// <summary>
    /// StartForm is used to test the logout/re-login behavior.
    /// </summary>
    public partial class StartForm : Form
    {
        private OldAppForm _oldAppForm;

        public StartForm()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (_oldAppForm == null)
            {
                _oldAppForm = new OldAppForm();
                _oldAppForm.Show();
                _oldAppForm.FormClosed += new FormClosedEventHandler(OldAppForm_FormClosed);
            }
            else
            {
                MessageBox.Show("App already startet.", "Start", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void OldAppForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this._oldAppForm.Dispose();
            this._oldAppForm = null;
        }
    }
}
