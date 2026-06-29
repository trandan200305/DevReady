namespace DevReady.Core.Models.Hardware
{
    public class NetworkInfo
    {
        public string AdapterName { get; set; } = string.Empty;
        public string MacAddress { get; set; } = string.Empty;
        public double LinkSpeedMbps { get; set; }
        public bool IsConnected { get; set; }
    }
}
