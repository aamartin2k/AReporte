using System;
using System.IO;
using System.Linq;
using System.Text;

namespace ReportString
{
    class Program
    {
        static void ReportAsString(string reportPath, string outputPath)
        {
            // abrir archivo, leer todas las lineas
            var source = File.ReadAllLines(reportPath);

            string[] destination = new string[source.Length] ;

            for (int i = 0; i < source.Length; i++)
            {
                destination[i] = SAR(source[i]);
            }

            TextWriter textWriter = new StreamWriter(outputPath);
            foreach (var item in destination)
            {
                textWriter.WriteLine(item);
            }

            textWriter.Close();
        }

        static string SAR(string line)
        {
            // replace " with \" in body of string
            const string dquote = "\"";
            const string slashdquote = "\\\"";
            const string dquoteplus = "\" +";

            string newString;

            newString = line.Replace(dquote, slashdquote);

            // enclose string in " xxxxxxx " + 
            return  dquote + newString + dquoteplus;
        }


        static void Main(string[] args)
        {
            if (args.Length < 1)
                return;

            string source = null;
            string destination = null;

            if (args.Length == 1)
            {
                source = args[0];

                destination = Path.GetFileNameWithoutExtension(source) + ".txt";
            }

            if (args.Length == 2)
            {
                source = args[0];
                destination = args[1];
            }

            if (!File.Exists(source))
                return;

            ReportAsString(source, destination);
        }
    }
}
