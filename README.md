# BreadButter .Net
---
The official BreadButter .NET API library.

### Install BreadButter (NuGet)
---
Via command line:

	nuget install BreadButter

Via Package Manager:

	PM> Install-Package BreadButter

Via Visual Studio:

1. Open the Solution Explorer.
2. Right-click on a project within your solution.
3. Click on *Manage NuGet Packages...*
4. Click on the *Browse* tab and search for "BreadButter".
5. Click on the BreadButter package, select the appropriate version in the right-tab and click *Install*.

## Bread Butter API
---

- Prior to coding, some configuration is required at https://app.breadbutter.io/app/#app-settings.

- For the full Developer Documentation please visit: https://app.breadbutter.io/api/

---
### Instantiating a new client

- `APP_ID` can be found in [App Settings](https://app.BreadButter.io/app/#/app-settings)
- `APP_SECRET` is configured at [App Secrets](https://app.BreadButter.io/app/#/app-secrets)
- `BREADBUTTER_API_ENDPOINT` should be set to `https://api.breadbutter.io`

Create a new instance of `BreadButter`.  

```csharp
using BreadButter;
using BreadButter.Model;

BreadButterClient client = new BreadButterClient(baseUrl: "{BREADBUTTER_API_ENDPOINT}", appId: "{APP_ID}",  appSecret: "{APP_SECRET}");
```
---
### Login QuickStart

The StartAuthentication function in the JS library begins the Bread Butter managed login process.  

>Further documentation on starting the login process via our JavaScript client can be found at our GitHub page [here](https://github.com/BreadButter/BreadButter-js)

The following example demonstrates what to do once the `Callback Url` has been used by our system to redirect the user back to your page:

```csharp
using BreadButter;
using BreadButter.Model;

//NOTE: depending on what flavor of .NET you are using (Asp.Net, .net Core, .NET Framework), this could be slightly different
var authToken = Request.Query["authentication_token"];

GetAuthenticationResponse response = client.GetAuthenticationAsync(authToken);

var authData = response.auth_data;

var email = authData.email_address;
var firstName = authData.first_name;
var lastName = authData.last_name;
var profileImage = authData.profile_image_url;

```