using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using Orchard.Environment.Extensions;

namespace Piedone.Avatars.Migrations
{
    [OrchardFeature("Piedone.Avatars.Blogpost")]
    public class BlogpostAvatarsMigrations : DataMigrationImpl
    {

        public int Create()
        {
            ContentDefinitionManager.AlterTypeDefinition("BlogPost",
                cfg => cfg
                    .WithPart("AvatarPart"));

            ContentDefinitionManager.AlterPartDefinition("AvatarPart",
                builder => builder
                    .WithDescription("Adds Avatars to Blog Posts in Detail view."));

            return 1;
        }
    }
}