using System.Drawing;
using System.Drawing.Drawing2D;
using Pong.Interfaces;

namespace Pong.Classes
{
    /// <summary>
    /// Class representing static background object
    /// </summary>
    class Background: StaticObject, IBackground
    {
        #region Constructor

        /// <summary>
        /// Background class constructor
        /// </summary>
        /// <param name="width">Object width</param>
        /// <param name="height">Object height</param>
        /// <param name="position">Object initial position</param>
        public Background(
            double width = 0,
            double height = 0,
            IPoint position = null
        ) : base(
            width,
            height,
            position,
            Color.Black
        ) {}

        #endregion

        #region Methods

        /// <summary>
        /// Fill background with color
        /// </summary>
        /// <param name="graphics">Graphics object</param>
        private void FillBackground(
            Graphics graphics
        )
        {
            using (Brush drawBrush = new SolidBrush(this.BackgroundColor))
            {
                Utils utils = Utils.GetInstance();
                utils.FillRectangle(graphics, drawBrush, this.Position.X, this.Position.Y, this.Width, this.Height);
            }
        }

        /// <summary>
        /// Draw top and bottom borders
        /// </summary>
        /// <param name="graphics">Graphics object</param>
        /// <param name="pen">Pen object</param>
        private void DrawBorders(
            Graphics graphics,
            Pen pen
        )
        {
            Utils utils = Utils.GetInstance();
            utils.DrawLine(graphics, pen, this.Position.X, Constants.DEFAULT_BORDER_PADDING, this.Width, Constants.DEFAULT_BORDER_PADDING);
            utils.DrawLine(graphics, pen, this.Position.X, (this.Height - (Constants.DEFAULT_BORDER_PADDING + Constants.DEFAULT_BORDER_WIDTH)), this.Width, (this.Height - (Constants.DEFAULT_BORDER_PADDING + Constants.DEFAULT_BORDER_WIDTH)));
        }

        /// <summary>
        /// Draw midfield splitter line
        /// </summary>
        /// <param name="graphics">Graphics object</param>
        /// <param name="pen">Pen object</param>
        private void DrawSplitter(
            Graphics graphics,
            Pen pen
        )
        {
            Utils utils = Utils.GetInstance();
            utils.DrawLine(graphics, pen, this.Width / 2, Constants.DEFAULT_BORDER_PADDING, this.Width / 2, this.Height - (Constants.DEFAULT_BORDER_PADDING + Constants.DEFAULT_BORDER_WIDTH));
        }

        /// <summary>
        /// Draw background decorations (top and down borders, midfield splitter line)
        /// </summary>
        /// <param name="graphics">Graphics object</param>
        private void DrawDecorations(
            Graphics graphics
        )
        {
            using (Pen drawPen = new Pen(Color.White, (int)Constants.DEFAULT_BORDER_WIDTH))
            {
                this.DrawBorders(graphics, drawPen);

                drawPen.DashStyle = DashStyle.Dot;
                this.DrawSplitter(graphics, drawPen);
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
            this.FillBackground(graphics);
            this.DrawDecorations(graphics);
        }

        #endregion
    }
}
