namespace Robogrammer.Core.Models
{
    using System;

    public abstract class RobotAction
    {
        public Guid OperationId { get; } = Guid.NewGuid();
        public abstract ActionType Type { get; }
    }
}
