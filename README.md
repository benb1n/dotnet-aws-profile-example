# Using AWS Profiles for .Net Credential Management
The AWS .Net SDK can load credentials defined locally in your AWS profiles files located in your ~/.aws folder. You can use the following AWS CLI command to configure a new profile:

```
aws configure --profile your-profile-name
```

Follow the prompts to save the new profile.

Once the profile is setup, you can use it in your .Net app by setting the following section in your config file:

``` json
{
  "AWS": {
    "Profile": "your-profile-name"
  }
}
```

If the profile approach is only used for local development, save it in your `appSettings.Development.json` file instead of the main `appSettings.json` file that is checked into source control since profile names can vary from developer to developer and since the profile approach is also not likely the approach you'll use in production.
