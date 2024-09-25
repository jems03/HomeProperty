using HomeProperty.Models.Pages;

namespace HomeProperty.Models.ViewModels
{
    public interface IPageViewModel<out T> where T : SitePageData
    {
        T CurrentPage { get; }
        LayoutModel Layout { get; set; }
    }
}
