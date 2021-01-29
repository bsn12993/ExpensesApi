using System;
using System.IO;

namespace Expenses.Core.Helpers
{
    public class FileHelper
    {
        public static string CreateFile(string base64, string path, string fileName)
        {
            try
            {
                var imageBytes = Convert.FromBase64String(base64);
                var filePath = Path.Combine(path, fileName);
                File.WriteAllBytes(filePath, imageBytes);
                return path;
            }
            catch(FileLoadException e)
            {
                throw e;
            }
            catch(FileNotFoundException e)
            {
                throw e;
            }
        }

 
    }
}
