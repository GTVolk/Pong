using System;
using System.Windows.Forms;
using Pong.Interfaces;
using Pong.Classes;

namespace Pong
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        ICanvas canvas;
        /// <summary>
        /// 
        /// </summary>
        IPongGame game;

        /// <summary>
        /// Main form constructor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            canvas = new Canvas(gameBox);
            game = new PongGame(canvas);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.game.StartGame();
        }

        /// <summary>
        /// 
        /// </summary>
        ~MainForm()
        {
            game.StopGame();
            game = null;
            canvas = null;
        }
    }
}
