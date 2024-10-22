using EPiServer.Shell.ObjectEditing;
using HomeProperty.Models.Properties;

namespace HomeProperty.SelectionFactories
{
    public class PropertyTypeSelection : ISelectionFactory
    { 

        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            // Get all enum values from PropertyEnum
            foreach (var enumValue in Enum.GetValues(typeof(PropertyEnum)).Cast<PropertyEnum>())
            {
                // Create a select item for each enum value
                yield return new SelectItem
                {
                    Text = enumValue.ToString(),  // Enum name as display text
                    Value = ((int)enumValue).ToString()  // Enum integer value as the select value
                };
            }
        }
    }
}
