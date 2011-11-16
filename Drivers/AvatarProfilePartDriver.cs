using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.Environment.Extensions;
using Piedone.Avatars.Models;

namespace Piedone.Avatars.Drivers
{
    [OrchardFeature("Piedone.Avatars")]
    public class AvatarProfilePartDriver : ContentPartDriver<AvatarProfilePart>
    {
        protected override string Prefix
        {
            get { return "Avatars"; }
        }

        protected override DriverResult Display(AvatarProfilePart part, string displayType, dynamic shapeHelper)
        {
            return ContentShape("Parts_FacebookCommentsBox",
                () => shapeHelper.Parts_FacebookCommentsBox(
                                                //NumberOfPosts: part.NumberOfPosts
                                                ));
        }

        // GET
        protected override DriverResult Editor(AvatarProfilePart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_FacebookCommentsBox_Edit",
                () => shapeHelper.EditorTemplate(
                    TemplateName: "Parts/FacebookCommentsBox",
                    Model: part,
                    Prefix: Prefix));
        }

        // POST
        protected override DriverResult Editor(AvatarProfilePart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }
    }
}