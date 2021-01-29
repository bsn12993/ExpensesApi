using System.IO;

namespace ExpensesApp.Core.Helpers
{
    public class DirectoryHelper
    {
        public static string GetCurrentRootPath()
        {
            return System.Web.HttpContext.Current.Server.MapPath("~/");
        }

        public static string GetCurrentDomain()
        {
            return string.Format("{0}://{1}:{2}",
                System.Web.HttpContext.Current.Request.Url.Scheme,
                System.Web.HttpContext.Current.Request.Url.Host,
                System.Web.HttpContext.Current.Request.Url.Port);
        }

        public static string CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }

        public static void DeleteDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
        }
    }
}
