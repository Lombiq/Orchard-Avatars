using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Orchard.Environment.Extensions;
using Piedone.Avatars.Models;
using Piedone.Avatars.Services;
using Orchard.Environment;

namespace Piedone.Avatars.Handlers
{
    [OrchardFeature("Piedone.Avatars")]
    public class AvatarProfilePartHandler : ContentHandler
    {
        public AvatarProfilePartHandler(
            IRepository<AvatarProfilePartRecord> repository,
            Work<IAvatarsService> avatarsServiceWork)
        {
            Filters.Add(StorageFilter.For(repository));

            OnActivated<AvatarProfilePart>((context, part) =>
                {
                    // Add loaders that will load content just-in-time
                    part.ImageUrlField.Loader(() => avatarsServiceWork.Value.GetAvatarUrl(part.Id));
                });
        }
    }
}