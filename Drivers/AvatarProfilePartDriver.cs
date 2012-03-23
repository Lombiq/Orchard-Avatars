using System.Web.Mvc;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.Environment.Extensions;
using Orchard.Users.Models;
using Piedone.Avatars.Models;
using Piedone.Avatars.Services;
using Piedone.HelpfulLibraries.ServiceValidation.Extensions;
using System;

namespace Piedone.Avatars.Drivers
{
    [OrchardFeature("Piedone.Avatars")]
    public class AvatarProfilePartDriver : ContentPartDriver<AvatarProfilePart>
    {
        private readonly IAvatarsService _avatarsService;

        protected override string Prefix
        {
            get { return "Avatars"; }
        }

        public AvatarProfilePartDriver(IAvatarsService avatarsService)
        {
            _avatarsService = avatarsService;
        }

        protected override DriverResult Display(AvatarProfilePart part, string displayType, dynamic shapeHelper)
        {
            if (!part.HasAvatar) return null;

            return ContentShape("Parts_AvatarProfile",
                () => shapeHelper.Parts_AvatarProfile(UserName: part.As<UserPart>().UserName));
        }

        // GET
        protected override DriverResult Editor(AvatarProfilePart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_AvatarProfile_Edit",
                () => shapeHelper.EditorTemplate(
                    TemplateName: "Parts/AvatarProfile",
                    Model: part,
                    Prefix: Prefix));
        }

        // POST
        protected override DriverResult Editor(AvatarProfilePart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);

            var postedFile = ((Controller)updater).Request.Files["Avatars_FileUpload"];
            if (postedFile != null && !String.IsNullOrEmpty(postedFile.FileName))
            {
                _avatarsService.SaveAvatarFile(part, postedFile);
                updater.TranscribeValidationDictionaryErrors<AvatarsServiceValidationKey>(_avatarsService.ValidationDictionary);
            }

            return Editor(part, shapeHelper);
        }
    }
}