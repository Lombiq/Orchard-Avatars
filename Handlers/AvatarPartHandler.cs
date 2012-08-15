using Orchard.ContentManagement;
using Orchard.ContentManagement.Handlers;
using Orchard.Core.Common.Models;
using Orchard.Environment.Extensions;
using Piedone.Avatars.Models;
using Piedone.Avatars.Services;
using Orchard.Environment;

namespace Piedone.Avatars.Handlers
{
    [OrchardFeature("Piedone.Avatars")]
    public class AvatarPartHandler : ContentHandler
    {
        public AvatarPartHandler(
            Work<IAvatarsService> avatarsServiceWork)
        {
            OnActivated<AvatarPart>((context, part) =>
                {
                    // Add loaders that will load content just-in-time
                    part.ImageUrlField.Loader(() => avatarsServiceWork.Value.GetAvatarUrl(part.As<CommonPart>().Owner.Id));
                });
        }
    }
}