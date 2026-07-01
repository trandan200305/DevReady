namespace DevReady.Core.Models.Compatibility
{
    public class CompatibilityResult
    {
        public bool IsCompatible { get; set; }

        public int Score { get; set; }

        public List<string> PassedRequirements { get; set; } = new();

        public List<string> FailedRequirements { get; set; } = new();

        public List<string> Recommendations { get; set; } = new();
    }
}
