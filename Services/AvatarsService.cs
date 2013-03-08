using System;
using System.IO;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;
using Orchard.Environment.Extensions;
using Orchard.FileSystems.Media;
using Orchard.Localization;
using Orchard.Settings;
using Piedone.Avatars.Extensions;
using Piedone.Avatars.Models;
using Piedone.HelpfulLibraries.ServiceValidation.ValidationDictionaries;

namespace Piedone.Avatars.Services
{
    [OrchardFeature("Piedone.Avatars")]
    public class AvatarsService : IAvatarsService
    {
        private readonly IStorageProvider _storageProvider;
        private readonly IContentManager _contentManager;
        private readonly ISiteService _siteService;

        private const string AvatarFolderPath = "Modules/Piedone/Avatars";

        public IServiceValidationDictionary<AvatarsServiceValidationKey> ValidationDictionary { get; private set; }
        public Localizer T { get; set; }


        public AvatarsService(
            IStorageProvider storageProvider,
            IContentManager contentManager,
            ISiteService siteService,
            IServiceValidationDictionary<AvatarsServiceValidationKey> validationDictionary)
        {
            _storageProvider = storageProvider;
            _contentManager = contentManager;
            _siteService = siteService;
            ValidationDictionary = validationDictionary;

            T = NullLocalizer.Instance;
        }


        public void CreateAvatarsFolder()
        {
            _storageProvider.TryCreateFolder(AvatarFolderPath);
        }

        public bool SaveAvatarFile(int id, Stream stream, string extension)
        {
            extension = extension.StripExtension();
            var settings = GetSettings();
            
            if (stream.Length > settings.MaxFileSize)
            {
                ValidationDictionary.AddError(AvatarsServiceValidationKey.FileTooLarge, T("The file was too large for an avatar ({0}KB), maximum file size is {1}KB", 
                    Math.Round((float)(stream.Length / 1024)),
                    Math.Round((float)(settings.MaxFileSize / 1024))));

                return false;
            }

            var filePath = GetFilePath(id, extension);

            if (!IsFileAllowed(filePath))
            {
                ValidationDictionary.AddError(AvatarsServiceValidationKey.NotAllowedFileType, T("This file type is not allowed as an avatar."));

                return false;
            }

            // This is the way to overwrite a file... We can't check its existence yet with IStorageProvider, but soon there will be such a method.
            try
            {
                _storageProvider.DeleteFile(filePath);
            }
            catch (Exception)
            {
            }

            _storageProvider.SaveStream(filePath, stream);

            var avatar = _contentManager.Get<AvatarProfilePart>(id);
            avatar.FileExtension = extension;
            _contentManager.Flush();

            return true;
        }

        public void DeleteAvatarFile(int id)
        {
            _contentManager.Get<AvatarProfilePart>(id).FileExtension = "";
            // Maybe to be used in the Handler in OnRemoved(). But since removing is not hard deleting, this isn't required yet.
            _storageProvider.DeleteFile(GetFilePath(id, _contentManager.Get<AvatarProfilePart>(id).FileExtension));
        }

        public bool IsFileAllowed(string fileName)
        {
            var settings = GetSettings();

            // Must be in the whitelist
            if (settings == null ||
                !settings.AllowedFileTypeWhitelist.ToLowerInvariant().Split(' ').Contains(Path.GetExtension(fileName).StripExtension()))
            {
                return false;
            }

            return true;
        }

        public string GetAvatarUrl(int id)
        {
            var extension = _contentManager.Get<AvatarProfilePart>(id).FileExtension;
            if (String.IsNullOrEmpty(extension)) return ""; // There is no avatar yet.

            return _storageProvider.GetPublicUrl(GetFilePath(id, extension));
        }

        private string GetFilePath(int id, string extension)
        {
            return AvatarFolderPath + "/" + id + "." + extension;
        }

        private string StripExtension(string extension)
        {
            return extension.Trim().TrimStart('.').ToLowerInvariant();
        }

        private AvatarsSettingsPart GetSettings()
        {
            return _siteService.GetSiteSettings().As<AvatarsSettingsPart>();
        }
    }
}
