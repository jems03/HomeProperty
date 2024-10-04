using EPiServer.Security;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;

namespace HomeProperty.Business.UIDescriptiors
{
    [EditorDescriptorRegistration(TargetType = typeof(XhtmlString), UIHint = "TinyMCEDescriptor" ,EditorDescriptorBehavior = EditorDescriptorBehavior.ExtendBase)]
    public class TinyMceEditorDescriptor : EditorDescriptor
    {
        public override void ModifyMetadata(ExtendedMetadata metadata, IEnumerable<Attribute> attributes)
        {
            // base method
            base.ModifyMetadata(metadata, attributes);

            // Set the client editing class to TinyMCE
            ClientEditingClass = "epi-cms/contentediting/editors/TinyMCEEditor";

            var settings = new Dictionary<string, object>
        {
            { "force_p_newlines", false },
            { "plugins", "link" }, // Add plugin for everyone
            { "toolbar", "link" }   // Toolbar for everyone
        };

            if (PrincipalInfo.CurrentPrincipal.IsInRole(Globals.WebRoles.WebAdmins))
            {
                settings["plugins"] += " code"; // Add for admins
                settings["toolbar"] += " | code"; // Add for admins
            }

            // Set the customized settings to the editor configuration
            metadata.EditorConfiguration["tinyMCE"] = settings;
        }
    }
}
