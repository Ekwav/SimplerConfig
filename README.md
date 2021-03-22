# SimplerConfig
This package provides you with a simple-config option for your C# project.

[![NuGet](https://img.shields.io/nuget/v/SimplerConfig.svg?style=flat)](https://www.nuget.org/packages/SimplerConfig/)

## Usage
```
using SimplerConfig;
var setting = SConfig.Instance["KEY"];
var nestedSetting = SConfig.Instance["TopKey:SubKey"];
```


## Options
1. Default Configurations should be placed in `appsettings.json`.
2. It will be overwritten by settings in `custom.conf.json`
3. Those settings can be overwritten by Enviroment Variables.
4. Finally you can pass settings as [CommandLine arguments](#using-commandline-arguments).

### Format
You access sub-elements of `JSON` with `:`.  
Example:
```
{
    "plugin":
    {
        "name":"SimpleConfig"
    }
}
```
Access with 
```
SimplerConfig.SConfig.Instance["plugin:name"]
```
You can overwrite it by 
* changing it in `custom.conf.json`
* setting `plugin:name="YourName"` 
* or by passing `--plugin:name="AnotherName"`



If you can think of a simple way please open an issue :)

## Using Commandline Arguments
To enable the use of `commandline arguments` add this at the start of your `Main(string[] args)`:
```
SimplerConfig.Instance.StartArgs = args;
```

## Including JSON Config
By default `appsettings.json` and `custom.conf.json` aren't copied on build. 
If you want to include the settings with your build you have to add the following to your `.csproj` file:
```
[...]
  <ItemGroup>
    <None Include="custom.conf.json" CopyToOutputDirectory="Always" CopyToPublishDirectory="Always"/>
    <None Include="appsettings.json" CopyToOutputDirectory="Always" CopyToPublishDirectory="Always"/>
  </ItemGroup>
</Project>
```


