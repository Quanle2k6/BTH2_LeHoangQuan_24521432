using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Bai02
{
    public class B2
    {
        public void Run()
        {
            Console.Write("Enter a directory path: ");
            string directoryPath = Console.ReadLine();
            while (string.IsNullOrEmpty(directoryPath))
            {
                Console.WriteLine("Directory path cannot be empty.");
                Console.Write("Enter a directory path: ");
                directoryPath = Console.ReadLine();
            }
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(directoryPath);
                if (!dirInfo.Exists)
                {
                    Console.WriteLine("The specified directory does not exist.");
                    return;
                }
                Console.WriteLine($"Contents of directory: {directoryPath}");
                var entries = dirInfo.GetFileSystemInfos().OrderBy(x => x.Name);
                int fileCount = 0;
                int dirCount = 0;
                long totalFileSize = 0;
                foreach (var entry in entries)
                {
                    if (entry is DirectoryInfo)
                    {
                        if (entry.Name.StartsWith("$")) continue;
                        Console.WriteLine($"{entry.CreationTime:dd/MM/yyyy HH:mm}\t<DIR>\t\t{entry.Name}");
                        dirCount++;
                    }
                    else if (entry is FileInfo file)
                    {
                        if (file.Name.StartsWith("~$"))
                        {
                            continue;
                        }
                        else
                        {
                            Console.WriteLine($"{file.CreationTime:dd/MM/yyyy HH:mm}\t{file.Length,15:N0}\t{file.Name}");
                            fileCount++;
                            totalFileSize += file.Length;
                        }
                    }
                }
                DriveInfo drive = DriveInfo.GetDrives().FirstOrDefault(d => directoryPath.StartsWith(d.Name, StringComparison.OrdinalIgnoreCase));

                long freeSpace = drive?.AvailableFreeSpace ?? 0;

                Console.WriteLine();
                Console.WriteLine($"{fileCount,15} File(s) {totalFileSize,20:N0} bytes");
                Console.WriteLine($"{dirCount,15} Dir(s)  {freeSpace,20:N0} bytes free");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
