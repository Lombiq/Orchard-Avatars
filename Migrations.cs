using Orchard.Data.Migration;
using Orchard.Environment.Extensions;
using Piedone.Avatars.Models;
using Piedone.Avatars.Services;
using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;

namespace Piedone.Avatars.Migrations
{
    [OrchardFeature("Piedone.Avatars")]
    public class Migrations : DataMigrationImpl
    {
        private readonly IAvatarsService _avatarsService;

        public Migrations(IAvatarsService avatarsService)
        {
            _avatarsService = avatarsService;
        }

        public int Create()
        {
            SchemaBuilder.CreateTable(typeof(AvatarsSettingsPartRecord).Name, table => table
                .ContentPartRecord()
                .Column<string>("AllowedFileTypeWhitelist")
                .Column<int>("MaxFileSize")
            );

            SchemaBuilder.CreateTable(typeof(AvatarProfilePartRecord).Name, table => table
                .ContentPartRecord()
                .Column<string>("FileExtension")
            );

            _avatarsService.CreateAvatarsFolder();


            return 1;
        }

        public int UpdateFrom1()
        {

            ContentDefinitionManager.AlterPartDefinition(typeof(AvatarPart).Name,
                builder => builder.Attachable());


            return 2;
        }
    }
}