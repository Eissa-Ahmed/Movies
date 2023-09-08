using Microsoft.AspNetCore.Http;
using System.Web.Mvc;

namespace Movie.BL.Helper
{
    public static class ValidateFile
    {
        public static bool CheckExtensionFile(IFormFile file)
        {
            List<string> allowExtension = new List<string>() { ".jpg" };
            if (!allowExtension.Contains(Path.GetExtension(file.FileName).ToLower()))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool CheckExtensionVideo(IFormFile file)
        {
            List<string> allowExtension = new List<string>() { ".mp4" };
            if (allowExtension.Contains(Path.GetExtension(file.FileName).ToLower()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool CheckSizeFile(IFormFile file)
        {
            if (file.Length > 100000)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
