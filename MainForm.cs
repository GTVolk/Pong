using System;
using System.Windows.Forms;
using Pong.Interfaces;
using Pong.Classes;

namespace Pong
{
    public partial class MainForm : Form
    {
        GameType game;

        public MainForm()
        {
            InitializeComponent();

            game = new DemoGame(gameBox);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(1000);
            this.game.Start();
        }

        ~MainForm()
        {
            game.Stop();
            game = null;
        }
    }
}
