using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Orchard.Environment.Extensions;
using Piedone.Avatars.Models;

namespace Piedone.Avatars.Handlers
{
    [OrchardFeature("Piedone.Avatars")]
    public class AvatarsSettingsPartHandler : ContentHandler
    {
        public AvatarsSettingsPartHandler(IRepository<AvatarsSettingsPartRecord> repository)
        {
            Filters.Add(new ActivatingFilter<AvatarsSettingsPart>("Site"));
            Filters.Add(StorageFilter.For(repository));
        }
    }
}