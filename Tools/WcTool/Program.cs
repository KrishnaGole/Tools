using System.Text;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: wctool <option> <filename>");
            Console.WriteLine("Options:");
            Console.WriteLine("-c: Output the number of bytes in a file");
            Console.WriteLine("-l: Output the number of lines in a file");
            return;
        }
        string option = args[0];
        string projectDir = AppDomain.CurrentDomain.BaseDirectory;
        string filename = args[1];
        string filePath = Path.Combine(projectDir, filename);
        if(!File.Exists(filePath))
        {
            Console.WriteLine($"File '{filename}' not found.");
            return;
        }
        try
        {
            switch (option)
            {
                case "-c":
                    OutputBytes(filePath, filename);
                    break;
                case "-l":
                    OutputLines(filePath, filename);
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured: {ex.Message}");
        }
    }

    static void OutputBytes(string filePath, string filename)
    {
        FileInfo fileInfo = new FileInfo(filePath);
        long fileSizeInBytes = fileInfo.Length;
        Console.WriteLine($"{fileSizeInBytes} {filename}");
    }
    static void OutputLines(string filePath, string filename)
    {
        int lineCount = File.ReadLines(filePath).Count();
        Console.WriteLine($"{lineCount} {filename}");
    }
}