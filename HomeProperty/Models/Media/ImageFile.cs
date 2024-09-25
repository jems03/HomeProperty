using EPiServer.Framework.DataAnnotations;

namespace HomeProperty.Models.Media
{
    [ContentType(GUID = "87E58C31-BA11-4E7D-82BC-F46216361F06")]
    [MediaDescriptor(ExtensionString = "jpg,jpeg,jpe,ico,gif,bmp,png")]
    public class ImageFile : ImageData
    {
        public virtual string Copyright { get; set; }
    }
}

