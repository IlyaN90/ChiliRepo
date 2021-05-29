using Chilli.Core.Product.Models;
using Microsoft.Extensions.Hosting;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace Chilli.Application.ImageHelper
{
    public class ImageHelperService
    {
        private static IHostEnvironment _env;
      
        public ImageHelperService(IHostEnvironment env)
        {
            _env = env;
        }

        public static IHostEnvironment Env { get => _env; set => _env = value; }

        public static string SaveImage(UploadProductImageRequest request)
        {
            try
            {
                var img = Convert.FromBase64String(request.Base64str);
                var image = ResizeImage(img, 250);
                if (!Directory.Exists("Images"))
                {
                    Directory.CreateDirectory("Images");
                }
                Guid fileName = Guid.NewGuid();
                StringBuilder path = new StringBuilder();
                path.Append("Images/");
                path.Append(fileName);
                path.Append(".jpeg");
                //string path = "Images/" + fileName+".jpeg";
                File.WriteAllBytes(path.ToString(), img.ToArray());
                return path.ToString();
            }
            catch (FormatException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private static byte[] ResizeImage(byte[] data, int largestSide)
        {
            byte[] result;
            using (MemoryStream StartMemoryStream = new MemoryStream(), NewMemoryStream = new MemoryStream())
            {
                StartMemoryStream.Write(data, 0, data.Length);
                var startBitmap = new Bitmap(StartMemoryStream);
                if (startBitmap.Width < largestSide)
                    return data;
                int newHeight;
                int newWidth;
                double HW_ratio;
                newWidth = largestSide;
                HW_ratio = largestSide / (double)startBitmap.Width;
                newHeight = (int)(HW_ratio * startBitmap.Height);
                var newBitmap = ResizeImage(startBitmap, newWidth, newHeight);
                newBitmap.Save(NewMemoryStream, ImageFormat.Jpeg);

                result = NewMemoryStream.ToArray();
                StartMemoryStream.FlushAsync();
                
            }

            return result;
        }
        private static Bitmap ResizeImage(Image image, int width, int height)
        {
            var resizedImage = new Bitmap(width, height);
            using (var gfx = Graphics.FromImage(resizedImage))
            {
                gfx.DrawImage(image, new Rectangle(0, 0, width, height),
                    new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);
            }
            return resizedImage;
        }
    }
}
