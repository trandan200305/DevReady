using System;
using System.Text.Json;
using System.Threading.Tasks;
using DevReady.Core.Scanners.Hardware;

namespace DevReady.Test
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Bắt đầu quét phần cứng...\n");

            var options = new JsonSerializerOptions { WriteIndented = true };

            try
            {
                Console.WriteLine("===== CPU INFO =====");
                var cpu = await new CpuScanner().ScanAsync();
                Console.WriteLine(JsonSerializer.Serialize(cpu, options));
                
                Console.WriteLine("\n===== RAM INFO =====");
                var ram = await new RamScanner().ScanAsync();
                Console.WriteLine(JsonSerializer.Serialize(ram, options));
                
                Console.WriteLine("\n===== GPU INFO =====");
                var gpu = await new GpuScanner().ScanAsync();
                Console.WriteLine(JsonSerializer.Serialize(gpu, options));
                
                Console.WriteLine("\n===== DISK INFO =====");
                var disks = await new DiskScanner().ScanAsync();
                Console.WriteLine(JsonSerializer.Serialize(disks, options));
                
                Console.WriteLine("\n===== MOTHERBOARD INFO =====");
                var mb = await new MotherboardScanner().ScanAsync();
                Console.WriteLine(JsonSerializer.Serialize(mb, options));
                
                Console.WriteLine("\n===== BIOS INFO =====");
                var bios = await new BiosScanner().ScanAsync();
                Console.WriteLine(JsonSerializer.Serialize(bios, options));
                
                Console.WriteLine("\n===== OS INFO =====");
                var os = await new OsScanner().ScanAsync();
                Console.WriteLine(JsonSerializer.Serialize(os, options));
                
                Console.WriteLine("\n===== DISPLAY INFO =====");
                var displays = await new DisplayScanner().ScanAsync();
                Console.WriteLine(JsonSerializer.Serialize(displays, options));
                
                Console.WriteLine("\n===== NETWORK INFO =====");
                var networks = await new NetworkScanner().ScanAsync();
                Console.WriteLine(JsonSerializer.Serialize(networks, options));

                Console.WriteLine("\nQuét phần cứng hoàn tất!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nLỗi trong quá trình quét: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }

            Console.WriteLine("\nHoàn tất kiểm tra.");
        }
    }
}