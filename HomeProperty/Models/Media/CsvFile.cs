using EPiServer.Framework.DataAnnotations;

namespace HomeProperty.Models.Media
{
    [ContentType(DisplayName = "Csv File", 
        GUID = "5462a4f2-8e07-4df8-86c5-0339a5b66671", 
        Description = "CSV File")]
    [MediaDescriptor(ExtensionString = "csv")]

    public class CsvFile : MediaData
    {
       
    }
}
