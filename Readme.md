# Avatars Orchard module Readme



## Project Description

An Orchard module that brings avatars to the platform


## Features

- Avatar pictures can be uploaded by users
- User profiles show avatar pictures
- AvatarPart to show avatars with any content type
- Configuration to make constraints on uploadable images
- Import/export settings


## Documentation

**This module needs at least Orchard 1.8!**

### First steps

**The module depends on [Helpful Libraries](https://gallery.orchardproject.net/List/Modules/Orchard.Module.Piedone.HelpfulLibraries) and [Profile](https://orchardprofile.codeplex.com/). Make sure to install them first!** From Profile use [this fork](https://bitbucket.org/Lombiq/orchard-contrib-profile), updated to be compatible with the latest Orchard version.

- Avatar settings are added to Settings/Media.
- There'll be a new content part, AvatarPart. You can attach this part to any content type you wish the avatar to display at. **Please note that AvatarPart can only be attached to types that also have Common part (and therefore an Owner)!**
- Users can upload their own avatar on their profile page. Please refer to the documentation of the [Profile](http://orchardprofile.codeplex.com/) module how it works and how you can display a link to the profiles and the profile editor page.
- The module overrides some shapes to integrate the functionality the Profile module provides. - The User shape, where the "Welcome, <UserName>" and the logout link is displayed is enhanced with a link to the profile editing page. Parts_Common_Metadata and Parts_Common_Metadata_Summary contain a link to the author's profile.

**[Version History](Docs/VersionHistory.md)**

The module's source is available in two public source repositories, automatically mirrored in both directions with [Git-hg Mirror](https://githgmirror.com):

- [https://bitbucket.org/Lombiq/orchard-avatars](https://bitbucket.org/Lombiq/orchard-avatars	) (Mercurial repository)
- [https://github.com/Lombiq/Orchard-Avatars](https://github.com/Lombiq/Orchard-Avatars) (Git repository)

Bug reports, feature requests and comments are warmly welcome, **please do so via GitHub**.
Feel free to send pull requests too, no matter which source repository you choose for this purpose.

This project is developed by [Lombiq Technologies Ltd](http://lombiq.com/). Commercial-grade support is available through Lombiq.