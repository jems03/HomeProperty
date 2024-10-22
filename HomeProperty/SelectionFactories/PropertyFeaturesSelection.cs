using EPiServer.ServiceLocation;
using EPiServer.Shell.ObjectEditing;

namespace HomeProperty.SelectionFactories
{
    public class PropertyFeaturesSelection : ISelectionFactory
    {
        private readonly CategoryRepository _categoryRepository;

        public PropertyFeaturesSelection(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            var propertyCategories = _categoryRepository.GetRoot().Categories.Where(c => c.Name == Globals.CmsCategories.PropertyFeatures).FirstOrDefault();

            if (propertyCategories != null)
            {
                var propertySubCategories = propertyCategories.Categories;

                foreach (var subcategory in propertySubCategories)
                {
                    yield return new SelectItem() { Text = subcategory.Description, Value = subcategory.Name };
                }

            }
            else
            {
                yield return new SelectItem() { Text = "No subcategories found", Value = string.Empty };
            }

        }
    }
}
