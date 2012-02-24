using Orchard;
using Piedone.HelpfulLibraries.ServiceValidation.ServiceInterfaces;
using System.Web;
using Piedone.Avatars.Models;
using System.IO;

namespace Piedone.Avatars.Services
{
    /// <summary>
    /// Use these values to check the ValidationDictionary against errors
    /// </summary>
    public enum AvatarsServiceValidationKey
    {
        FileTooLarge,
        NotAllowedFileType
    }

    public interface IAvatarsService : IDependency, IValidatingService<AvatarsServiceValidationKey>
    {
        /// <summary>
        /// Creates the media folder where avatars are stored
        /// </summary>
        /// <remarks>
        /// Used in Migrations.
        /// </remarks>
        void CreateAvatarsFolder();

        /// <summary>
        /// Saves an avatar file
        /// </summary>
        /// <param name="id">Id of the content item (user) to attach the file to</param>
        /// <param name="stream">The content of the file</param>
        /// <param name="extension">The extension of the file</param>
        /// <returns>True or false indicating success or failure</returns>
        bool SaveAvatarFile(int id, Stream stream, string extension);

        /// <summary>
        /// Deletes an avatar file
        /// </summary>
        /// <param name="id">Id of the content item (user) the file was attached to</param>
        void DeleteAvatarFile(int id);

        /// <summary>
        /// Checks whether the file is allowed to be used as an avatar
        /// </summary>
        /// <param name="fileName">The file's name</param>
        bool IsFileAllowed(string fileName);

        /// <summary>
        /// Returns the avatar's public url
        /// </summary>
        /// <param name="id">Id of the content item (user) the file was attached to</param>
        string GetAvatarUrl(int id);
    }

    public static class AvatarsServiceExtensions
    {
        /// <summary>
        /// Saves an avatar file
        /// </summary>
        /// <param name="avatar">The actual AvatarProfilePart attach the file to</param>
        /// <param name="postedFile">A posted image file</param>
        /// <returns>True or false indicating success or failure</returns>
        public static bool SaveAvatarFile(this IAvatarsService service, AvatarProfilePart avatar, HttpPostedFileBase postedFile)
        {
            return service.SaveAvatarFile(avatar.Id, postedFile);
        }

        /// <summary>
        /// Saves an avatar file
        /// </summary>
        /// <param name="id">Id of the content item (user) to attach the file to</param>
        /// <param name="postedFile">A posted image file</param>
        /// <returns>True or false indicating success or failure</returns>
        public static bool SaveAvatarFile(this IAvatarsService service, int id, HttpPostedFileBase postedFile)
        {
            return service.SaveAvatarFile(id, postedFile.InputStream, Path.GetExtension(postedFile.FileName));
        }

        /// <summary>
        /// Checks whether the file is allowed to be used as an avatar
        /// </summary>
        /// <param name="postedFile">A posted image file</param>
        public static bool IsFileAllowed(this IAvatarsService service, HttpPostedFileBase postedFile)
        {
            if (postedFile == null)
            {
                return false;
            }

            return service.IsFileAllowed(postedFile.FileName);
        }
    }
}
