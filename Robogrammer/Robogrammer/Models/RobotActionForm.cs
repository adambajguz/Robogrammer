namespace Robogrammer.Models
{
    using Robogrammer.Core.Models;

    public class RobotActionForm
    {
        public ActionType Type { get; set; }
        public double Distance { get; set; }
        public int Duration { get; set; }
        public double Angle { get; set; }
    }
}
