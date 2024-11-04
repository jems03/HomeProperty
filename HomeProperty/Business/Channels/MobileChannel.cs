using EPiServer.Web;
using Wangkanai.Detection.Models;
using Wangkanai.Detection.Services;

namespace HomeProperty.Business.Channels
{
    public class MobileChannel : DisplayChannel
    {
        public const string Name = "mobile";

        public override string ChannelName => Name;

        public override string ResolutionId => typeof(IphoneVerticalResolution).FullName;

        public override bool IsActive(HttpContext context)
        {
            var detection = context.RequestServices.GetRequiredService<IDetectionService>();
            return detection.Device.Type == Device.Mobile;
        }
    }
}
