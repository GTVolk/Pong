using System.Drawing;
using Pong.Interfaces;

namespace Pong.Classes
{
    /// <summary>
    /// Class representing on-screen static text object
    /// </summary>
    class StaticText: StaticObject, IScreenText
    {
        #region Fields

        /// <summary>
        /// Text font
        /// </summary>
        public Font Font { get; set; }
        /// <summary>
        /// Text string
        /// </summary>
        public string Text { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Static text class constructor
        /// </summary>
        /// <param name="position">Object initial position</param>
        /// <param name="font">Text font</param>
        /// <param name="text">Text string</param>
        public StaticText(
            IPoint position = null,
            Font font = default,
            string text = ""
        ) : base(
            0,
            0,
            position,
            Color.White
        )
        {
            this.Font = font;
            this.Text = text;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get text's size in pixels
        /// </summary>
        /// <param name="graphics">Graphics object</param>
        /// <returns>Text size in pixels</returns>
        public SizeF GetTextSize(
            Graphics graphics
        )
        {
            return graphics.MeasureString(this.Text, this.Font);
        }

        /// <summary>
        /// Draw text string
        /// </summary>
        /// <param name="graphics">Graphics object</param>
        private void DrawStaticText(
            Graphics graphics
        )
        {
            using (Brush drawBrush = new SolidBrush(this.BackgroundColor))
            {
                Utils utils = Utils.GetInstance();
                utils.DrawString(graphics, this.Text, this.Font, drawBrush, this.Position.X, this.Position.Y);
            }
        }

        /// <summary>
        /// Draw method for self-drawing of object
        /// </summary>
        /// <param name="graphics">Graphics object</param>
        public override void Draw(
            Graphics graphics
        )
        {
            this.DrawStaticText(graphics);
        }

        #endregion
    }
}
