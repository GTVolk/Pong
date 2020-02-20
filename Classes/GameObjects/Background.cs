using System.Windows.Forms;
using System.Drawing;
using Pong.Interfaces;

namespace Pong.Classes
{
    /// <summary>
    /// 
    /// </summary>
    class Background: StaticObject, IBackground
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="position"></param>
        public Background(double width, double height, IPoint position) : base(width, height, position) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="graphics"></param>
        private void FillBackground(Graphics graphics)
        {
            using (Brush drawBrush = new SolidBrush(this.BackgroundColor))
            {
                Utils utils = Utils.GetInstance();
                utils.FillRectangle(graphics, drawBrush, this.Position.X, this.Position.Y, this.Width, this.Height);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="pen"></param>
        private void DrawBorders(Graphics graphics, Pen pen)
        {
            Utils utils = Utils.GetInstance();
            utils.DrawLine(graphics, pen, this.Position.X, Constants.DEFAULT_BORDER_PADDING, this.Width, Constants.DEFAULT_BORDER_PADDING);
            utils.DrawLine(graphics, pen, this.Position.X, (this.Height - (Constants.DEFAULT_BORDER_PADDING + Constants.DEFAULT_BORDER_WIDTH)), this.Width, (this.Height - (Constants.DEFAULT_BORDER_PADDING + Constants.DEFAULT_BORDER_WIDTH)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="pen"></param>
        private void DrawSplitter(Graphics graphics, Pen pen)
        {
            Utils utils = Utils.GetInstance();
            utils.DrawLine(graphics, pen, this.Width / 2, Constants.DEFAULT_BORDER_PADDING, this.Width / 2, this.Height - (Constants.DEFAULT_BORDER_PADDING + Constants.DEFAULT_BORDER_WIDTH));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="graphics"></param>
        public override void Draw(Graphics graphics)
        {
            this.FillBackground(graphics);
            using (Pen drawPen = new Pen(Color.White, (int)Constants.DEFAULT_BORDER_WIDTH))
            {
                this.DrawBorders(graphics, drawPen);

                drawPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                this.DrawSplitter(graphics, drawPen);
            }
        }
    }
}
