using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.Core.Common.Models;
using Orchard.Environment.Extensions;
using Piedone.Avatars.Models;

namespace Piedone.Avatars.Drivers
{
    [OrchardFeature("Piedone.Avatars")]
    public class AvatarPartDriver : ContentPartDriver<AvatarPart>
    {
        protected override DriverResult Display(AvatarPart part, string displayType, dynamic shapeHelper)
        {
            if (!part.HasAvatar) return null;

            return ContentShape("Parts_Avatar",
                () => shapeHelper.Parts_Avatar(UserName: part.As<CommonPart>().Owner.UserName));
        }
    }
}