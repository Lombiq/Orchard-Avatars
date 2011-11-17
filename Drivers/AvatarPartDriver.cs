using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.Environment.Extensions;
using Piedone.Avatars.Models;
using Piedone.Avatars.Services;
using Orchard.Core.Common.Models;
using Orchard.Users.Models;
using System.Web.Mvc;
using Piedone.ServiceValidation.Helpers;

namespace Piedone.Avatars.Drivers
{
    [OrchardFeature("Piedone.Avatars")]
    public class AvatarPartDriver : ContentPartDriver<AvatarPart>
    {
        protected override DriverResult Display(AvatarPart part, string displayType, dynamic shapeHelper)
        {
            if (!part.HasAvatar) return null;

            return ContentShape("Parts_Avatar",
                () => shapeHelper.Parts_Avatar(
                                                HasAvatar: part.HasAvatar,
                                                ImageUrl: part.ImageUrl,
                                                UserName: part.As<CommonPart>().Owner.UserName
                                                ));
        }
    }
}