using Orchard.Environment.Extensions;
using Orchard.UI.Resources;

namespace Piedone.Avatars
{
    [OrchardFeature("Piedone.Avatars")]
    public class ResourceManifest : IResourceManifestProvider
    {
        public void BuildManifests(ResourceManifestBuilder builder)
        {
            var manifest = builder.Add();
            manifest.DefineStyle("Avatars").SetUrl("piedone-avatars.css");
        }
    }
}
