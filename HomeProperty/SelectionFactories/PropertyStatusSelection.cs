using EPiServer.Shell.ObjectEditing;

namespace HomeProperty.SelectionFactories
{
    public class PropertyStatusSelection : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            yield return new SelectItem { Text = "For Sale", Value = "for-sale" };
            yield return new SelectItem { Text = "For Rent", Value = "for-rent" };
            yield return new SelectItem { Text = "Sold Out", Value = "sold-out" };
        }
    }
}
