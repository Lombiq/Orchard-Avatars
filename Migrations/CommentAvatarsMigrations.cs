using Orchard.ContentManagement.MetaData;
using Orchard.Data.Migration;
using Orchard.Environment.Extensions;

namespace Piedone.Avatars.Migrations
{
    [OrchardFeature("Piedone.Avatars.Comment")]
    public class CommentAvatarsMigrations : DataMigrationImpl
    {

        public int Create()
        {
            ContentDefinitionManager.AlterTypeDefinition("Comment",
                cfg => cfg
                    .WithPart("AvatarPart"));

            return 1;
        }

    }
}