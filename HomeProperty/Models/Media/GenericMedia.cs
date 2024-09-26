namespace HomeProperty.Models.Media
{
    [ContentType(DisplayName = "Generic Media", 
        GUID = "c6795e1b-e429-496b-a08f-f5c1a8123ba5", 
        Description = "")]
    public class GenericMedia : MediaData
    {
        public virtual string Description { get; set; }

    }
}
