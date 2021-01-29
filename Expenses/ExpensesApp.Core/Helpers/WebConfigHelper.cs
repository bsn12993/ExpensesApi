using System.Configuration;

namespace ExpensesApp.Core.Helpers
{
    public static class WebConfigHelper
    {
        public static string PATH_FILES
        {
            get { return ConfigurationManager.AppSettings["PATH_FILES"]; }
        }

        public static string GetImageProfileDefault
        {
            get { return ConfigurationManager.AppSettings["PATH_USER_PROFILE_DEFAULT"]; }
        }
    }
}
