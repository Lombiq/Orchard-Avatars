using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Orchard.Environment.Extensions;
using Piedone.Avatars.Models;
using Piedone.Avatars.Services;
using Orchard.ContentManagement;
using Orchard.Core.Common.Models;

namespace Piedone.Avatars.Handlers
{
    [OrchardFeature("Piedone.Avatars")]
    public class AvatarPartHandler : ContentHandler
    {
        private readonly IAvatarsService _avatarsService;
        public AvatarPartHandler(
            IAvatarsService avatarsService)
        {
            _avatarsService = avatarsService;

            OnLoaded<AvatarPart>((context, part) =>
                {
                    // Add loaders that will load content just-in-time
                    part.ImageUrlField.Loader(() => _avatarsService.GetAvatarUrl(part.As<CommonPart>().Owner.Id));
                });
        }
    }
}