using EPiServer.Shell.ObjectEditing;

namespace HomeProperty.SelectionFactories
{
    public class PropertyTypeSelection : ISelectionFactory
    { 

        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            yield return new SelectItem { Text = "Apartment", Value = "apartment" };
            yield return new SelectItem { Text = "Office", Value = "office" };
            yield return new SelectItem { Text = "Townhouse", Value = "townhouse" };
            yield return new SelectItem { Text = "House", Value = "house" };
            yield return new SelectItem { Text = "Retail", Value = "retail" };
        }
    }
}
