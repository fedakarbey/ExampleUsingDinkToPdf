using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Loader;

public class CustomAssemblyLoadContext : AssemblyLoadContext
{
    public CustomAssemblyLoadContext() : base(isCollectible: true) { }

    public IntPtr LoadUnmanagedLibrary(string absolutePath)
    {
        if (string.IsNullOrEmpty(absolutePath))
        {
            throw new ArgumentNullException(nameof(absolutePath));
        }

        return LoadUnmanagedDll(absolutePath);
    }

    protected override IntPtr LoadUnmanagedDll(string unmanagedDllPath)
    {
        return NativeLibrary.Load(unmanagedDllPath);
    }

    protected override Assembly Load(AssemblyName assemblyName)
    {
        return null; // Managed DLL'ler için yükleme işlemi yapmayız
    }
}
