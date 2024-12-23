﻿using System.ComponentModel.DataAnnotations;

namespace HomeProperty
{
    public class Globals
    {
        [GroupDefinitions]
        public static class GroupNames
        {
            [Display(Name = "SEO", Order = 1)]
            public const string SEO = "SEO";

            [Display(Name = "Layout", Order = 2)]
            public const string Layout = "Layout";

            [Display(Name = "Properties", Order = 3)]
            public const string Properties = "Properties";
        }

       public static class UIHintDescriptors
        {
            public const string TinyMCE = "TinyMCEDescriptor";
        }

        public static class WebRoles
        {
            public const string WebAdmins = "WebAdmins";
            public const string WebEditors = "WebEditors";
        }

        public static class ContentAreaTags
        {
            public const string FullWidth = "full";
            public const string WideWidth = "wide";
            public const string HalfWidth = "half";
            public const string NarrowWidth = "narrow";
            public const string NoRenderer = "norenderer";
        }

        public static class CmsCategories
        {
            public const string PropertyFeatures = "Property Features";
        }

    }
}
