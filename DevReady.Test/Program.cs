using System;
using System.Collections;
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

            try
            {
                Console.WriteLine("===== CPU INFO =====");
                var cpu = await new CpuScanner().ScanAsync();
                PrintInfo(cpu);
                
                Console.WriteLine("\n===== RAM INFO =====");
                var ram = await new RamScanner().ScanAsync();
                PrintInfo(ram);
                
                Console.WriteLine("\n===== GPU INFO =====");
                var gpu = await new GpuScanner().ScanAsync();
                PrintInfo(gpu);
                
                Console.WriteLine("\n===== DISK INFO =====");
                var disks = await new DiskScanner().ScanAsync();
                PrintInfo(disks);
                
                Console.WriteLine("\n===== MOTHERBOARD INFO =====");
                var mb = await new MotherboardScanner().ScanAsync();
                PrintInfo(mb);
                
                Console.WriteLine("\n===== BIOS INFO =====");
                var bios = await new BiosScanner().ScanAsync();
                PrintInfo(bios);
                
                Console.WriteLine("\n===== OS INFO =====");
                var os = await new OsScanner().ScanAsync();
                PrintInfo(os);
                
                Console.WriteLine("\n===== DISPLAY INFO =====");
                var displays = await new DisplayScanner().ScanAsync();
                PrintInfo(displays);
                
                Console.WriteLine("\n===== NETWORK INFO =====");
                var networks = await new NetworkScanner().ScanAsync();
                PrintInfo(networks);

                Console.WriteLine("\nQuét phần cứng hoàn tất!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nLỗi trong quá trình quét: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }

            Console.WriteLine("\nHoàn tất kiểm tra.");
        }

        static void PrintInfo(object obj)
        {
            if (obj == null) return;

            if (obj is IEnumerable list && !(obj is string))
            {
                int index = 1;
                foreach (var item in list)
                {
                    Console.WriteLine($"  --- Item {index++} ---");
                    PrintProperties(item);
                }
            }
            else
            {
                PrintProperties(obj);
            }
        }

        static void PrintProperties(object obj)
        {
            var props = obj.GetType().GetProperties();
            foreach (var prop in props)
            {
                var val = prop.GetValue(obj);
                Console.WriteLine($"  {prop.Name}: {val}");
            }
        }
    }
}