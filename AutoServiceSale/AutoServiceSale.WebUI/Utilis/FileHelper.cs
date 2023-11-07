namespace AutoServiceSale.WebUI.Utilis
{
    public class FileHelper
    {
        public static async Task<string> FileLoaderAsync(IFormFile formfile,string filePath="/Img/")
        {
            var fileName = "";
            if (formfile != null && formfile.Length>0 )
            {
                fileName = formfile.FileName;
                string directory = Directory.GetCurrentDirectory() + "/wwwroot/" + filePath + fileName;
                using var stream = new FileStream(directory, FileMode.Create);
                await formfile.CopyToAsync(stream);
            }
            return fileName;
        }
    }
}
