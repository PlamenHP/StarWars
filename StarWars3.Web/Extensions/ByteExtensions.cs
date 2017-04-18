namespace StarWars3.Web.Extensions
{
    using System;

    public static class ByteExtensions
    {
        public static string ToStringImage(this byte[] imageData)
        {
            if (imageData == null)
            {
                return null;
            }

            var base64 = Convert.ToBase64String(imageData);
            return string.Format("data:image/jpg;base64,{0}", base64);
        }
    }
}