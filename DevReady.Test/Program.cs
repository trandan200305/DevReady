using DevReady.Core.Models.Hardware;
using DevReady.Core.Scanners.Hardware;

namespace DevReady.Test
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            CpuScanner scanner = new CpuScanner();

            CpuInfo cpu = await scanner.ScanAsync();

            Console.WriteLine("===== CPU INFO =====");

            Console.WriteLine($"Name: {cpu.Name}");
            Console.WriteLine($"Manufacturer: {cpu.Manufacturer}");
            Console.WriteLine($"Core: {cpu.CoreCount}");
            Console.WriteLine($"Thread: {cpu.ThreadCount}");
            Console.WriteLine($"Base Clock: {cpu.BaseClockMHz} MHz");
            Console.WriteLine($"Max Clock: {cpu.MaxClockMHz} MHz");
            Console.WriteLine($"Architecture: {cpu.Architecture}");
            Console.WriteLine($"Processor ID: {cpu.ProcessorId}");
            Console.WriteLine($"Virtualization: {cpu.VirtualizationEnabled}");
        }
    }
}