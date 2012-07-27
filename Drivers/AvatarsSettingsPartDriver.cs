using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.Environment.Extensions;
using Piedone.Avatars.Models;
using Orchard.ContentManagement.Handlers;

namespace Piedone.Avatars.Drivers
{
    [OrchardFeature("Piedone.Avatars")]
    public class AvatarsSettingsPartDriver : ContentPartDriver<AvatarsSettingsPart>
    {
        protected override string Prefix
        {
            get { return "Avatars"; }
        }

        // GET
        protected override DriverResult Editor(AvatarsSettingsPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_AvatarsSettings_SiteSettings",
                () =>
                {
                    return shapeHelper.EditorTemplate(
                        TemplateName: "Parts.AvatarsSettings.SiteSettings",
                        Model: part,
                        Prefix: Prefix);
                }).OnGroup("Media");
        }

        // POST
        protected override DriverResult Editor(AvatarsSettingsPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }

        protected override void Exporting(AvatarsSettingsPart part, ExportContentContext context)
        {
            var element = context.Element(part.PartDefinition.Name);

            element.SetAttributeValue("AllowedFileTypeWhitelist", part.AllowedFileTypeWhitelist);
            element.SetAttributeValue("MaxFileSize", part.MaxFileSize);
        }

        protected override void Importing(AvatarsSettingsPart part, ImportContentContext context)
        {
            var partName = part.PartDefinition.Name;

            context.ImportAttribute(partName, "AllowedFileTypeWhitelist", value => part.AllowedFileTypeWhitelist = value);
            context.ImportAttribute(partName, "MaxFileSize", value => part.MaxFileSize = int.Parse(value));
        }
    }
}