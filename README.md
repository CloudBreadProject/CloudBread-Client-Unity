# CloudBread-Client-Unity
CloudBread unity client developer app project.

This project's goal is helpful for CloudBread users to use CloudBread APIs.

This is designed for unity game developer to build CloudBread mobile game server engine backend.

## feature
* No platform dependent code
* support Azure Authentication
* provide test tool based on OnGUI layout for CloudBread APIs Test

### No platform dependent code
To make this project, we use only unity c# script. Don't Worry about platform dependent code. Just build for platform you wanted!

Runs across Platform tested
* Unity Editor
* Mac OSX
* Android
* Probably almost all of things Unity runs on
We will be update other platforms tested

## How to use
1. Just clone this project!
```
git clone https://github.com/CloudBreadProject/CloudBread-Client-Unity.git
```

2. Open this project on Unity (over 5.0 will be stable)

3. Enjoy~

4. if you want to use this project on existing project, you import script files!

### Azure Authentication
It is based on this page : https://azure.microsoft.com/ko-kr/documentation/articles/mobile-services-how-to-register-facebook-authentication/

####To use Azure Authentication, you have to register your app on Facebook Login
1. Go to this Page : https://developers.facebook.com
My Apps > add a New App > Web Sites

2. Type your app name and Click Create New Facebook App ID

3. Fill out Categories, click Make a App ID

4. Type following URL formats in Site URL form
* https://<mobile_service>.azure-mobile.net

5. Go to Dash Board (in this page, Click Skip to Developer Dashboard)

6. Get App ID and Secret ID.

7. Setting > Advanced, fill Valid OAuth redirect URIs with following URL format

#### You have to type following URL format in Valid OAuth redirect URIs on Advanced tab
* https://<mobile_service>.azure-mobile.net/login/facebook

#### Go to Azure Portal
1. In CloudBread Mobile App Service, Click Authentication

2. Facebook click

3. fill out App ID and Secret ID that you get before

License : MIT license
