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
        ICanvas canvas;
        /// <summary>
        /// Game object
        /// </summary>
        IPongGame game;

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

        #region Destructor

        /// <summary>
        /// Form destructor
        /// </summary>
        ~MainForm()
        {
            game.StopGame();
            game = null;
            canvas = null;
        }

        #endregion
    }
}
