using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using Orchard.Environment.Extensions;
using Piedone.Avatars.Models;

namespace Piedone.Avatars.Migrations
{
    [OrchardFeature("Piedone.Avatars.Blogs")]
    public class BlogpostAvatarsMigrations : DataMigrationImpl
    {
        public int Create()
        {
            ContentDefinitionManager.AlterTypeDefinition("BlogPost",
                cfg => cfg
                    .WithPart(nameof(AvatarPart)));

            ContentDefinitionManager.AlterPartDefinition(nameof(AvatarPart),
                builder => builder
                    .WithDescription("Adds Avatars to Blog Posts in Detail view."));

            return 1;
        }
    }
}