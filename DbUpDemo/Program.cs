using System.Reflection;
using DbUp;
using DbUp.ScriptProviders;

namespace DbUpDemo
{
    internal class Program
    {
        static int Main(string[] args)
        {
            var connectionString =
                args.FirstOrDefault()
                ?? "Server=(local)\\SqlExpress; Database=DbUpDemoDB; Trusted_connection=true";

            var folderPath = new FileInfo(
                Path.Combine(
                    Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) ?? String.Empty, 
                    @"..\Scritps"
                )
            ).FullName;

            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    // 埋め込みリソースを使う場合に使用する
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())

                    // 指定ディレクトリの全てを対象にする場合に使用する
                    //.WithScriptsFromFileSystem(folderPath, new FileSystemScriptOptions
                    //{
                    //    IncludeSubDirectories = true
                    //})
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
#if DEBUG
                Console.ReadLine();
#endif
                return -1;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
            return 0;
        }
    }
}