using System.Windows.Forms;
using Pong.Interfaces;

namespace Pong.Classes
{
    class UserInput: IUserInput
    {
        private Control ListenObject { get; set; }

        private bool IsListening { get; set; }

        public UserInput(
            Control listenObj
        )
        {
            this.ListenObject = listenObj;
            ((Form)this.ListenObject).KeyDown += UserInput_KeyDown;
        }

        public void StartListening()
        {
            this.IsListening = true;
        }

        public void StopListening()
        {
            this.IsListening = false;
        }

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
    }
}
