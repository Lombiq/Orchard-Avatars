using Orchard;
using Piedone.ServiceValidation.ServiceInterfaces;

namespace Piedone.Avatars.Services
{
    public interface IAvatarsService : IDependency, IValidatingService
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
        /// <param name="avatar">The actual AvatarProfilePart attach the file to</param>
        /// <param name="postedFile">A posted image file</param>
        /// <returns>True or false indicating success or failure</returns>
        bool SaveAvatarFile(Piedone.Avatars.Models.AvatarProfilePart avatar, System.Web.HttpPostedFileBase postedFile);

        /// <summary>
        /// Saves an avatar file
        /// </summary>
        /// <param name="id">Id of the content item (user) to attach the file to</param>
        /// <param name="postedFile">A posted image file</param>
        /// <returns>True or false indicating success or failure</returns>
        bool SaveAvatarFile(int id, System.Web.HttpPostedFileBase postedFile);

        /// <summary>
        /// Saves an avatar file
        /// </summary>
        /// <param name="id">Id of the content item (user) to attach the file to</param>
        /// <param name="stream">The content of the file</param>
        /// <param name="extension">The extension of the file, without the dot</param>
        /// <returns>True or false indicating success or failure</returns>
        bool SaveAvatarFile(int id, System.IO.Stream stream, string extension);

        /// <summary>
        /// Deletes an avatar file
        /// </summary>
        /// <param name="id">Id of the content item (user) the file was attached to</param>
        void DeleteAvatarFile(int id);

        /// <summary>
        /// Checks whether the file is allowed to be used as an avatar
        /// </summary>
        /// <param name="postedFile">A posted image file</param>
        bool IsFileAllowed(System.Web.HttpPostedFileBase postedFile);

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
}
