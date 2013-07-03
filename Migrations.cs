using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using Orchard.Environment.Extensions;
using Orchard.FileSystems.Media;
using Piedone.Avatars.Models;
using Piedone.Avatars.Services;

namespace Piedone.Avatars.Migrations
{
    [OrchardFeature("Piedone.Avatars")]
    public class Migrations : DataMigrationImpl
    {
        private readonly IAvatarsService _avatarsService;
        private readonly IStorageProvider _storageProvider;


        public Migrations(IAvatarsService avatarsService, IStorageProvider storageProvider)
        {
            _avatarsService = avatarsService;
            _storageProvider = storageProvider;
        }


        public int Create()
        {
            SchemaBuilder.CreateTable(typeof(AvatarsSettingsPartRecord).Name, 
                table => table
                    .ContentPartRecord()
                    .Column<string>("AllowedFileTypeWhitelist")
                    .Column<int>("MaxFileSize")
                );

            SchemaBuilder.CreateTable(typeof(AvatarProfilePartRecord).Name, 
                table => table
                    .ContentPartRecord()
                    .Column<string>("FileExtension")
                );

            ContentDefinitionManager.AlterTypeDefinition("User",
                cfg => cfg
                    .WithPart(typeof(AvatarProfilePart).Name)
                );

            ContentDefinitionManager.AlterPartDefinition(typeof(AvatarPart).Name,
                builder => builder.Attachable());


            _avatarsService.CreateAvatarsFolder();


            return 3;
        }

        public int UpdateFrom1()
        {
            ContentDefinitionManager.AlterTypeDefinition("User",
                cfg => cfg
                    .WithPart(typeof(AvatarProfilePart).Name)
                );

            return 2;
        }

        public int UpdateFrom2()
        {
            var avatars = _storageProvider.ListFiles("Avatars");

            foreach (var file in avatars)
            {
                using (var stream = file.OpenRead())
                {
                    var copy = _storageProvider.CreateFile("Modules/Piedone/Avatars/" + file.GetName());
                    using (var copyStream = copy.OpenWrite())
                    {
                        stream.CopyTo(copyStream);
                    }
                }
            }

            _storageProvider.DeleteFolder("Avatars");


            return 3;
        }
    }
}