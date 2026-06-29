
namespace DevReady.Core.Interfaces;

public interface IScanner<T>
{
    Task<T> ScanAsync();
}