using System.Windows.Forms;
using System.Drawing;
using Pong.Interfaces;

namespace Pong.Classes
{
    /// <summary>
    /// 
    /// </summary>
    class StaticText: StaticObject, IScreenText
    {
        /// <summary>
        /// 
        /// </summary>
        public Font Font { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="font"></param>
        /// <param name="text"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="graphics"></param>
        /// <returns></returns>
        public SizeF GetTextSize(
            Graphics graphics
        )
        {
            return graphics.MeasureString(this.Text, this.Font);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="graphics"></param>
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
        /// 
        /// </summary>
        /// <param name="graphics"></param>
        public override void Draw(
            Graphics graphics
        )
        {
            this.DrawStaticText(graphics);
        }
    }
}
