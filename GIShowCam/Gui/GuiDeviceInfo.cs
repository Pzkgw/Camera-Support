using GIShowCam.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GIShowCam.Gui
{
    class GuiDeviceInfo : GuiBase
    {

        TextBox txtDevAddress, txtDevUser, txtDevPass;

        public GuiDeviceInfo(GuiBase mainB, TextBox txtDevAddress, TextBox txtDevUser, TextBox txtDevPass) : base(mainB)
        {
            txtDevAddress.Text = SessionInfo.host;
            txtDevUser.Text = SessionInfo.user;
            txtDevPass.Text = SessionInfo.pass;

            this.txtDevAddress = txtDevAddress;
            this.txtDevUser = txtDevUser;
            this.txtDevPass = txtDevPass;

            AddEvents();

        }

        #region Device Info



        #endregion Device Info

        private void AddEvents()
        {
            txtDevAddress.TextChanged += TxtDevAddress_TextChanged;
            txtDevUser.TextChanged += TxtDevUser_TextChanged;
            txtDevPass.TextChanged += TxtDevPass_TextChanged;
        }

        private void TxtDevPass_TextChanged(object sender, EventArgs e)
        {
            SessionInfo.pass = txtDevPass.Text;
        }

        private void TxtDevUser_TextChanged(object sender, EventArgs e)
        {
            SessionInfo.user = txtDevUser.Text;
        }

        private void TxtDevAddress_TextChanged(object sender, EventArgs e)
        {
            SessionInfo.host = txtDevAddress.Text;
        }



    }
}
