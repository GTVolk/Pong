namespace Pong.Classes
{
    /// <summary>
    /// Class for global constants
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Default background top and bottom border padding 
        /// </summary>
        public const double DEFAULT_BORDER_PADDING = 10;
        /// <summary>
        /// Default background top and bottom border width
        /// </summary>
        public const double DEFAULT_BORDER_WIDTH = 10;
        /// <summary>
        /// Default ball radius
        /// </summary>
        public const double DEFAULT_BALL_RADIUS = 12;
        /// <summary>
        /// Default ball movement speed
        /// </summary>
        public const double DEFAULT_BALL_SPEED = 5;
        /// <summary>
        /// Default paddle movement speed
        /// </summary>
        public const double DEFAULT_PADDLE_SPEED = 3;
        /// <summary>
        /// Default paddle width
        /// </summary>
        public const double DEFAULT_PAD_WIDTH = 10;
        /// <summary>
        /// Default paddle height
        /// </summary>
        public const double DEFAULT_PAD_HEIGHT = 75;
        /// <summary>
        /// Default player's score counters text font name
        /// </summary>
        public const string DEFAULT_COUNTER_FONT = "Impact";
        /// <summary>
        /// Default player's score counters text size
        /// </summary>
        public const int DEFAULT_COUNTER_FONT_SIZE = 48;
        /// <summary>
        /// Desired game speed in frames per second
        /// </summary>
        public const int FPS = 60;
        /// <summary>
        /// Render period 1 second to number of frames per second
        /// </summary>
        public const int RENDER_PERIOD = 1000 / FPS;
        /// <summary>
        /// Ball bounce on border speed multiplayer
        /// </summary>
        public const double BALL_BOUNCE_BORDER_SPEED_MULT = 1.01f;
        /// <summary>
        /// Ball bounce on paddle speed multiplayer
        /// </summary>
        public const double BALL_BOUNCE_PADDLE_SPEED_MULT = 1.05f;
    }
}
