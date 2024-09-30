using HomeProperty.Models.Blocks;

namespace HomeProperty.Utilities
{
    public static class PropertyStatusHelper
    {
        public static string GetPropertyStatusText(string value)
        {
            var selectionFactory = new PropertyStatusSelectionFactory();
            var selections = selectionFactory.GetSelections(null);

            var selectedItem = selections.FirstOrDefault(s => s.Value.ToString() == value);
            return selectedItem?.Text ?? " ";
        }
    }
}
