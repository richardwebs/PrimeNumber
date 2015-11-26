using System.IO;
using System.Text;

namespace PrimeLib
{
    public interface ICsvWriter
    {
        void WriteCsvFile(string filename, long[,] array);
    }
    public class CsvWriter : ICsvWriter
    {
        public void WriteCsvFile(string filename, long[,] array)
        {
            using (var writer = new StreamWriter(filename))
            {
                var rowCount = array.GetUpperBound(0) + 1;
                var colCount = array.GetUpperBound(1) + 1;
                for (var i = 0; i < rowCount; i++)
                {
                    var line = new StringBuilder();
                    for (var j = 0; j < colCount; j++)
                    {
                        if (line.Length == 0) line.Append(array[i, j]);
                        else line.Append("," + array[i, j]);
                    }
                    writer.WriteLine(line);
                }
                writer.Close();
            }
        }
    }
}

