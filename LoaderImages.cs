using System.IO;

namespace LoaderImages
{
    public static class Loaderimages
    {
        public static byte[] LoadPhoto(string path)
        {
            return File.ReadAllBytes(path);
        }
    }
}