using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Security;
using EPiServer.ServiceLocation;

namespace HomeProperty.Business.Initialization
{
    [InitializableModule]
    public class RestrictMoveToTrash : IInitializableModule
    {          
        public void Initialize(InitializationEngine context)
        {
            var contentEvents = ServiceLocator.Current.GetInstance<IContentEvents>();
            contentEvents.MovingContent += OnMovingContent;
        }

        private void OnMovingContent(object sender, ContentEventArgs e)
        {        

            // Check if the content is being moved to the Trash
            if (e.TargetLink.CompareToIgnoreWorkID(ContentReference.WasteBasket))
            {
                if (!PrincipalInfo.CurrentPrincipal.IsInRole(Globals.WebRoles.WebAdmins))
                {
                    e.CancelAction = true;
                    e.CancelReason = "You do not have permission to move this content to trash.";
                }
            }
        }

        public void Uninitialize(InitializationEngine context)
        {
            var contentEvents = ServiceLocator.Current.GetInstance<IContentEvents>();
            contentEvents.MovingContent -= OnMovingContent;
        }
    }
}
