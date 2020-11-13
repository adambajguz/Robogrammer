namespace Robogrammer.Core.Models
{
    public class RobotTurnAction : RobotAction
    {
        public override ActionType Type => Angle < 0 ? ActionType.TurnLeft : ActionType.TurnRight;

        public double Angle { get; init; }
    }
}
