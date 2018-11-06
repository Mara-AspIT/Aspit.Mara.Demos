/* Demonstrates how to use StreamReader and StreamWriter to read and write to and from a textfile.
 * StreamReader: https://docs.microsoft.com/da-dk/dotnet/api/system.io.streamreader?view=netframework-4.7.2
 * StreamWriter: https://docs.microsoft.com/da-dk/dotnet/api/system.io.streamwriter?view=netframework-4.7.2 */

using System;
using System.IO;

namespace Aspit.Mara.Demos.TextFileIO
{
    class TextFileIoProgram
    {
        static void Main()
        {
            string textToWrite = "This is the content of the file";
            string directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filename = "testFile";
            string fileExtension = ".txt";
            string path = Path.Combine(directory, filename + fileExtension);

            try
            {
                using(StreamWriter writer = new StreamWriter(path))
                {
                    writer.Write(textToWrite);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error writing to file. {e.Message}");
            }

            string textToRead;

            try
            {
                using(StreamReader reader = new StreamReader(path))
                {
                    textToRead = reader.ReadToEnd();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error reading from file. {e.Message}");
            }
            Console.ReadLine();
        }
    }
}