using System;
using System.Windows.Forms;
using Pong.Interfaces;
using Pong.Classes;

namespace Pong
{
    public partial class MainForm : Form
    {
        ICanvas canvas;
        IPongGame game;

        public MainForm()
        {
            InitializeComponent();

            canvas = new Canvas(gameBox);
            game = new PongGame(canvas);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.game.StartGame();
        }

        ~MainForm()
        {
            game.StopGame();
            game = null;
            canvas = null;
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
