using Orchard;
using Piedone.ServiceValidation.ServiceInterfaces;

namespace Piedone.Avatars.Services
{
    public interface IAvatarsService : IDependency, IValidatingService
    {
        void CreateAvatarsFolder();
        bool SaveAvatarFile(Piedone.Avatars.Models.AvatarProfilePart avatar, System.Web.HttpPostedFileBase postedFile);
        bool SaveAvatarFile(int id, System.Web.HttpPostedFileBase postedFile);
        bool SaveAvatarFile(int id, System.IO.Stream stream, string extension);
        void DeleteAvatarFile(int id);
        bool IsFileAllowed(System.Web.HttpPostedFileBase postedFile);
        bool IsFileAllowed(string fileName);
        string GetAvatarUrl(int id);
    }
}
