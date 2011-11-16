using Orchard.ContentManagement.Records;
using Orchard.Environment.Extensions;

namespace Piedone.Avatars.Models
{
    [OrchardFeature("Piedone.Avatars")]
    public class AvatarsSettingsPartRecord : ContentPartRecord
    {
        public virtual string AllowedFileTypeWhitelist { get; set; }
        public virtual int MaxFileSize { get; set; }

        public AvatarsSettingsPartRecord()
        {
            AllowedFileTypeWhitelist = "jpg jpeg gif png";
            MaxFileSize = 102400;
        }
    }
}