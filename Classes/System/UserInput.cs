using System.Windows.Forms;
using Pong.Interfaces;

namespace Pong.Classes
{
    /// <summary>
    /// Class represents user input controller object
    /// </summary>
    class UserInput: IUserInput
    {
        #region Fields

        /// <summary>
        /// Object to listen key events on
        /// </summary>
        private Control ListenObject { get; set; }

        /// <summary>
        /// Is listening started
        /// </summary>
        private bool IsListening { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// User input class constuctor
        /// </summary>
        /// <param name="listenObj"></param>
        public UserInput(
            Control listenObj
        )
        {
            this.ListenObject = listenObj;
            ((Form)this.ListenObject).KeyDown += UserInput_KeyDown;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Starts key events listener
        /// </summary>
        public void StartListening()
        {
            this.IsListening = true;
        }

        /// <summary>
        /// Stops key events listener
        /// </summary>
        public void StopListening()
        {
            this.IsListening = false;
        }

        /// <summary>
        /// Key event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.IsListening)
            {

                switch (e.KeyCode)
                {
                    case Keys.W:
                        MessageBox.Show("Moving player 1 up", "Player move");
                        return;
                    case Keys.S:
                        MessageBox.Show("Moving player 1 down", "Player move");
                        return;
                    case Keys.Up:
                        MessageBox.Show("Moving player 2 up", "Player move");
                        return;
                    case Keys.Down:
                        MessageBox.Show("Moving player 1 down", "Player move");
                        return;
                    case Keys.R:
                        MessageBox.Show("Resetting game", "Game control");
                        return;
                    case Keys.N:
                        MessageBox.Show("New game", "Game control");
                        return;
                    case Keys.Escape:
                        MessageBox.Show("Exiting game...", "Game exit");
                        return;
                }
            }
        }

        #endregion
    }
}
