using System;
using System.Windows.Forms;
using Pong.Interfaces;
using Pong.Classes;

namespace Pong
{
    public partial class MainForm : Form
    {
        #region Fields

        /// <summary>
        /// Canvas object
        /// </summary>
        readonly ICanvas canvas;
        /// <summary>
        /// Game object
        /// </summary>
        readonly IPongGame game;

        #endregion

        #region Constructor

        /// <summary>
        /// Main form constructor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            canvas = new Canvas(gameBox);
            game = new PongGame(canvas);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Form load handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.game.StartGame();
        }

        #endregion
    }
}
