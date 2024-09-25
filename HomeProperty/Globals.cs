using System.ComponentModel.DataAnnotations;

namespace HomeProperty
{
    public class Globals
    {
        [GroupDefinitions]
        public static class GroupNames
        {
            [Display(Name = "SEO", Order = 10)]
            public const string SEO = "SEO";

            [Display(Name = "Layout", Order = 20)]
            public const string Layout = "Layout";
        }

        
    }
}
