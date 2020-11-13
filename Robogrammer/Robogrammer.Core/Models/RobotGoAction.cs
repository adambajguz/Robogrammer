namespace Robogrammer.Core.Models
{
    public class RobotGoAction : RobotAction
    {
        public override ActionType Type => Distance < 0 ? ActionType.GoBackward : ActionType.GoForward;

        public double Distance { get; init; }
    }
}
