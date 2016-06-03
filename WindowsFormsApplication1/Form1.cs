using Declarations;
using Declarations.Players;
using GISendApp;
using Implementation;
using System;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MainSend s = new MainSend(this);

        }
    }
}
