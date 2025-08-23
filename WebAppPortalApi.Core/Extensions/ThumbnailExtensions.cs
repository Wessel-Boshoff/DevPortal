using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppPortalSite.Common.Resources;

namespace WebAppPortalSite.Extensions
{
    public static class ThumbnailExtensions
    {
        private static readonly int targetHeight = 50;

        private static readonly List<string> supportedPhotoExtensions = new()
        {
            ".jpg",
            ".jpeg",
            ".png",
            ".bmp",
            ".gif",
            ".tiff"
        };


        public static byte[] GetThumbnail(this byte[]? data , string? extension)
        {
            if (data == null || extension == null)
            {
                return Array.Empty<byte>();
            }

            if (supportedPhotoExtensions.Any(c => c.ToLower() == extension.ToLower()))
            {
                return GetThumbnailPhoto(data, extension);
            }

            return GetThumbnailPhoto(Convert.FromBase64String(FileThumbs.Fallback), extension);
        }

        private static byte[] GetThumbnailPhoto(this byte[]? dataToThumb, string? extension)
        {
            using MemoryStream ms = new(dataToThumb);
            using System.Drawing.Image originalImage = System.Drawing.Image.FromStream(ms);

            double aspectRatio = (double)originalImage.Width / originalImage.Height;
            int newWidth = (int)(targetHeight * aspectRatio);
            int newHeight = targetHeight;

            using Bitmap thumbnail = new(originalImage, new Size(newWidth, newHeight));
            using MemoryStream thumbMs = new();

            thumbnail.Save(thumbMs, ImageFormat.Png);
            return thumbMs.ToArray();
        }

    }
}
