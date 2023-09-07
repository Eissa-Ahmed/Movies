using Microsoft.AspNetCore.Http;

namespace Movie.BL.Helper
{
    public static class FileUploader
    {
        public static string UploadFile(string FolderName , IFormFile file)
        {
			try
			{
                var pathFolder = Directory.GetCurrentDirectory() + "\\wwwroot\\Files\\" + FolderName;
                var NameFile = Guid.NewGuid() + Path.GetFileName(file.FileName);
                var finalPathFolder = Path.Combine(pathFolder, NameFile);

                using (var stream = new FileStream (finalPathFolder, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                return NameFile;
            }
			catch (Exception ex)
			{
                return ex.Message;
			}

        }

        public static string RemoveFile(string FolderName, string NameFile) 
        {
            try
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files" , FolderName , NameFile);
                if (File.Exists(path))
                {
                    File.Delete(path);
                    return "File Deleted";
                }
                else
                {
                    return "File Not Deleted";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
