using System.Configuration.Install;
using System.IO;

namespace ServiceInstaller
{
    class Program
    {
        static void Main(string[] args)
        {
            string exePath = "AaSampleService.exe";
            string serviceDirectory = @"c:\adayazilim\services";

            if(!Directory.Exists(serviceDirectory))
            {
                Directory.CreateDirectory(serviceDirectory);
            }

            string servicePath = Path.Combine(serviceDirectory, exePath);

            File.Copy(exePath, servicePath);

            AssemblyInstaller installer = new AssemblyInstaller();
            installer.UseNewContext = true;
            installer.Path = servicePath;
            installer.Install(null);
            installer.Commit(null);
        }
    }
}
