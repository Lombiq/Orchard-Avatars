using Orchard.ContentManagement;
using Orchard.Core.Common.Utilities;
using Orchard.Environment.Extensions;

namespace Piedone.Avatars.Models
{
    [OrchardFeature("Piedone.Avatars")]
    public class AvatarProfilePart : ContentPart<AvatarProfilePartRecord>
    {
        public string FileExtension
        {
            get { return Record.FileExtension; }
            set { Record.FileExtension = value; }
        }

        private readonly LazyField<string> _imageUrl = new LazyField<string>();

        public LazyField<string> ImageUrlField { get { return _imageUrl; } }

        public string ImageUrl
        {
            get { return _imageUrl.Value; }
        }
    }
}
