# saml-xamarin-app
Author: Erik Jan de Wit (edewit@redhat.com)   
Level: Beginner   
Technologies: Xamarin, Android, iOS, RHMAP   
Summary: A demonstration of how to authenticate with SAML IdP with RHMAP   
Community Project : [Feed Henry](http://feedhenry.org)   
Target Product: RHMAP   
Product Versions: RHMAP 3.8.0+   
Source: https://github.com/feedhenry-templates/saml-xamarin-app   
rerequisites: fh-dotnet-sdk : 3.+, Visual Studio : 2013/2015 or Xamarin Studio, SDK: iOS 8 or newer, Android SDK : 22+ or newer

## What is it?

Simple native Windows app to work with [```SAML Service``` connector service](https://github.com/feedhenry-templates/saml-service) in RHMAP. The user can login to the app using SAML authentication, user details available on SAML IdP are displayed once successfully logged in.To configure the service in your RHMAP platform read the [SAML notes](https://github.com/feedhenry-templates/saml-service/blob/master/NOTES.md).

## How do I run it?

### RHMAP Studio

This application and its cloud services are available as a project template in RHMAP as part of the "SAML Project" template.

### Local Clone (ideal for Open Source Development)
If you wish to contribute to this template, the following information may be helpful; otherwise, RHMAP and its build facilities are the preferred solution.

## Build instructions
1. Clone this project

2. Populate ```saml-xamarin-app/saml-ios-app/fhconfig.plist``` and/or ```saml-xamarin-app/saml-android-app/Assets/fhconfig.properties```with your values as explained 
[here for ios](http://docs.feedhenry.com/v3/dev_tools/sdks/ios.html#ios-get_started-setup) and [here for android](http://docs.feedhenry.com/v3/dev_tools/sdks/android.html#android-get_started-setup).

3. Open ```saml-xamarin-app.sln```

4. Run the project
 
## Troubleshootings

* Compilation error: error XA5209: Unzipping failed

When building, Xamarin fetches dependencies in `~/.local/share/Xamarin/`, it happens from times to times that the download of dependencies goes wrong and leave your `.local` folder in a corrupted state.
It happens when building Android (more dependencies to fetch), the best way to fix issue like missing [Android.Support.v4 support](https://forums.xamarin.com/discussion/42982/android-build-failure-unzipping-failed) is to delete `~/.local/share/` folder and build again. 

## How does it work?

### Using FHClient
In this example we used ```FHClient.GetCloudRequest``` to make request on the REST endpoint setup to deal with SAML authentication.
