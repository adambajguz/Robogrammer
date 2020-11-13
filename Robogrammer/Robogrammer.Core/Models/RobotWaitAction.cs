namespace Robogrammer.Core.Models
{
    public class RobotWaitAction : RobotAction
    {
        public override ActionType Type => ActionType.Wait;

        public int Duration { get; set; }
    }
}
