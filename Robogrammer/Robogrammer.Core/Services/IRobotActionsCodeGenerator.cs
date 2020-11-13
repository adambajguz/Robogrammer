namespace Robogrammer.Core.Services
{
    using System.Collections.Generic;
    using Robogrammer.Core.Models;

    public interface IRobotActionsCodeGenerator
    {
        string Generate(IReadOnlyList<RobotAction> robotActions);
    }
}