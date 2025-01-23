using Microsoft.AspNetCore.Http;

namespace Plumberz.BL.Extensions
{
    public static class FileExtension
    {
        public static bool IsValidType(this IFormFile file, string type)
        => file.FileName == type;
        public static bool IsValidSize(this IFormFile file, int size)
            => file.Length <= 1024 * 1024 * size;
        public static async Task<string> UploadAsync(this IFormFile file, string fileName)
        {
            string path = Path.Combine(fileName);

            string newFilePath = Path.GetRandomFileName() + Path.GetFileName(file.FileName);
            if (!File.Exists(newFilePath))
            {
                File.Create(newFilePath);
            }
            using (Stream st = File.Create(Path.Combine(path, newFilePath)))
            {
                await file.CopyToAsync(st);
            }
            return newFilePath;
        }
    }
}
