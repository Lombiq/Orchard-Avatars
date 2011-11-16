using Orchard.ContentManagement.Records;
using Orchard.Environment.Extensions;

namespace Piedone.Avatars.Models
{
    [OrchardFeature("Piedone.Avatars")]
    public class AvatarProfilePartRecord : ContentPartRecord
    {
        public virtual string FileExtension { get; set; }
    }
}
