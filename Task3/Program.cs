using System;
using System.IO;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            string _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            _filePath = Directory.GetParent(_filePath).FullName;

            using (var reader = new StreamReader(_filePath))
            {
                var line = reader.ReadLine();
                Console.WriteLine(line);
            }



        }
        private static object GetResourceStream(string filePath)
        {
            throw new NotImplementedException();
        }
    }
    }
}
