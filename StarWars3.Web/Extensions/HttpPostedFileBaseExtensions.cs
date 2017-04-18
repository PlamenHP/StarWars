namespace StarWars3.Web.Extensions
{
    using Services.Utilities;
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Web;

    public static class HttpPostedFileBaseExtensions
    {
        public static Byte[] ToByteArrayImage(this HttpPostedFileBase value)
        {
            if (value == null)
                return null;

            //var array = new Byte[value.ContentLength];
            //value.InputStream.Position = 0;
            //value.InputStream.Read(array, 0, value.ContentLength);
            //var resizedImage = ResizeImage(array);
            //return array;

            var image = Image.FromStream(value.InputStream, true, true);

            return ResizeImage(image, width: Constants.DefaultImageWidth, height: Constants.DefaultImageHeight);
        }

        public static byte[] ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(destImage, typeof(byte[]));
        }
    }
}
