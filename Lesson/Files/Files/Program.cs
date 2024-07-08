using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------------------");
            string path = @"C:\programs\file.txt";
            // Get file name.
            string filename = Path.GetFileName(path);

            Console.WriteLine("PATH:     {0}", path);
            Console.WriteLine("FILENAME: {0}", filename);
            string filename2 = Path.GetFileNameWithoutExtension(path);

            Console.WriteLine("PATH:         {0}", path);
            Console.WriteLine("NO EXTENSION: {0}", filename2);
            string value1 = @"C:\perls\word.txt";
            string value2 = @"C:\file.excel.dots.xlsx";

            // ... Get extensions.
            string ext1 = Path.GetExtension(value1);
            string ext2 = Path.GetExtension(value2);
            Console.WriteLine(ext1);
            Console.WriteLine(ext2);

            Console.WriteLine("------------------------");

            // Put all file names in root directory into array.
            string[] array1 = Directory.GetFiles(@"C:\Users\44747\Downloads\");

            // Put all bin files in root directory into array.
            // ... This is case-insensitive.
            string[] array2 = Directory.GetFiles(@"C:\", "*.BIN");

            // Display all files.
            Console.WriteLine("--- Files: ---");
            foreach (string name in array1)
            {
                Console.WriteLine(name);
            }

            // Display all BIN files.
            Console.WriteLine("--- BIN Files: ---");
            foreach (string name in array2)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("------------------------");
            Console.ReadLine();

        }
    }
}
