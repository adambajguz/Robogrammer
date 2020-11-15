namespace Robogrammer.Core.Models
{

    public sealed class CodeSettings
    {
        public string? Name { get; set; }

        public Ports LeftEnginePort { get; set; }
        public Ports RightEnginePort { get; set; }
    }
}
