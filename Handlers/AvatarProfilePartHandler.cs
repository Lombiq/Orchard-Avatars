using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Orchard.Environment.Extensions;
using Piedone.Avatars.Models;
using Piedone.Avatars.Services;

namespace Piedone.Avatars.Handlers
{
    [OrchardFeature("Piedone.Avatars")]
    public class AvatarProfilePartHandler : ContentHandler
    {
        private readonly IAvatarsService _avatarsService;
        public AvatarProfilePartHandler(
            IRepository<AvatarProfilePartRecord> repository,
            IAvatarsService avatarsService)
        {
            Filters.Add(new ActivatingFilter<AvatarProfilePart>("User"));
            Filters.Add(StorageFilter.For(repository));

            _avatarsService = avatarsService;

            OnLoaded<AvatarProfilePart>((context, part) =>
                {
                    // Add loaders that will load content just-in-time
                    part.ImageUrlField.Loader(() => _avatarsService.GetAvatarUrl(part.Id));
                });
        }
    }
}