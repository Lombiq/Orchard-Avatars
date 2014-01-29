using Orchard.ContentManagement;
using Orchard.Environment.Extensions;

namespace Piedone.Avatars.Models
{
    [OrchardFeature("Piedone.Avatars")]
    public class AvatarsSettingsPart : ContentPart<AvatarsSettingsPartRecord>
    {
        public string AllowedFileTypeWhitelist
        {
            get { return Retrieve(x => x.AllowedFileTypeWhitelist); }
            set { Store(x => x.AllowedFileTypeWhitelist, value); }
        }

        /// <summary>
        /// Maximal size of avatar file, in bytes
        /// </summary>
        public int MaxFileSize
        {
            get { return Retrieve(x => x.MaxFileSize); }
            set { Store(x => x.MaxFileSize, value); }
        }
    }
}