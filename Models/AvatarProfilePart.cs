using System;
using Orchard.ContentManagement;
using Orchard.Core.Common.Utilities;
using Orchard.Environment.Extensions;

namespace Piedone.Avatars.Models
{
    [OrchardFeature("Piedone.Avatars")]
    public class AvatarProfilePart : ContentPart<AvatarProfilePartRecord>
    {
        public bool HasAvatar
        {
            get { return !String.IsNullOrEmpty(FileExtension); }
        }

        public string FileExtension
        {
            get { return Retrieve(x => x.FileExtension); }
            set { Store(x => x.FileExtension, value); }
        }

        private readonly LazyField<string> _imageUrl = new LazyField<string>();
        internal LazyField<string> ImageUrlField { get { return _imageUrl; } }
        public string ImageUrl
        {
            get { return _imageUrl.Value; }
        }
    }
}
