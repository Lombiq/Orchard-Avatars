using Orchard.ContentManagement;
using Orchard.Environment.Extensions;

namespace Piedone.Avatars.Models
{
    [OrchardFeature("Piedone.Avatars")]
    public class AvatarsSettingsPart : ContentPart<AvatarsSettingsPartRecord>
    {
        public string AllowedFileTypeWhitelist
        {
            get { return Record.AllowedFileTypeWhitelist; }
            set { Record.AllowedFileTypeWhitelist = value; }
        }

        /// <summary>
        /// Maximal size of avatar file, in bytes
        /// </summary>
        public int MaxFileSize
        {
            get { return Record.MaxFileSize; }
            set { Record.MaxFileSize = value; }
        }
    }
}