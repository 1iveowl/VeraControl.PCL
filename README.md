# Vera Control .NET Library

[![NuGet](https://img.shields.io/badge/nuget-0.0.55-brightgreen.svg)](https://https://www.nuget.org/packages/VeraControl.PCL/) [![.NET Standard](http://img.shields.io/badge/.NET_Standard-1.2-green.svg)](https://docs.microsoft.com/da-dk/dotnet/articles/standard/library)
## Why this library

The purpose of the Vera Control .NET library is to facilitate interoperability to the [Vera Smart Home Controller](http://getvera.com/ "Vera Smart Home Controller").

There already exist a similar library - i.e. the [.NET Library for Micasaverde (Vera) Home Automation Controllers](http://veradotnet.codeplex.com/ ".NET Library for Micasaverde (Vera) Home Automation Controllers") - howecer this library have not evolved further for almost two years and while it is more complete than this library it also have some short comings, such as no default support for async/await. 

## How to use this library
The library works with Xamarin across iOS, Android, Windows 8.1 and lated, Windows Phone 8.1 and later and .NET 4.5.1 and later. 

Usage is simple:

1. Get the NuGet.
1. Start writing code:
```csharp
using IVeraControl.Model;
using VeraControl.Service;
using UpnpModels.Model;
using UpnpModels.Model.UpnpDevice;
using UpnpModels.Model.UpnpService;

...

// Create an instance of the Vera Service
var veraService = new VeraControlService();

// Get all Vera Controllers in your set-up using your username and password
var controllers = await veraService.GetControllers(username, password);

//Pick the controller you want interact with.
var veraPlus = controllers.FirstOrDefault(c => c.DeviceSerialId == "<Insert your device ID here>");
```

#### To Run a Scene:

```csharp
// Create an instance of the device you want to interact with.
// In the case of a Scene it is the Home Automation Gateway itself
var homeGateway = new HomeAutomationGateway(veraPlus);

var runScene = await homeGateway.ActionAsync(
	ServiceType.HomeAutomationGateway1,
	HomeAutomationGatewayAction.RunScene,
	<Insert Scene id here>,
	ConnectionType.Local);
```

#### To Get/Set a Dimmer Value

```csharp
var dimmer = new Dimmer1(veraPlus) {DeviceNumber = <Inset the id of the Dimmer device>};

// Get the current value of the Dimmer
var dimmerState = await dimmer.GetStateVariableAsync(
	ServiceType.Dimmer1,
	Dimming1StateVariable.LoadLevelStatus,
	ConnectionType.Local);

var dimmer50Pct = await dimmer.ActionAsync(
	ServiceType.Dimmer1,
	Dimming1Action.SetLoadLevelTarget,
	50,
	ConnectionType.Local);
```

#### To Flip a Switch
```csharp
var binaryLight = new BinaryLight1(veraPlus) {DeviceNumber = <Insert switch device id>};

var binaryLightStatus = await binaryLight.GetStateVariableAsync(
	ServiceType.SwitchPower1, 
	SwitchPower1StateVariable.Status, 
	ConnectionType.Local);

var result = await binaryLight.ActionAsync(
	ServiceType.SwitchPower1, 
	SwitchPower1Action.SetTarget, 
	!binaryLightStatus, 
	ConnectionType.Local);
```
#### To Read a Thermometer
```csharp
var thermometer = new TemperatureSensor1(veraPlus) { DeviceNumber = <Insert thermometer id> };

var temperature = await thermometer.GetStateVariableAsync(
ServiceType.TemperatureSensor1,
TemperatureSensor1StateVariables.CurrentTemperature,
ConnectionType.Local);
```
#### To Set a Thermostat
```csharp
var thermostat = new HVAC_ZoneThermostat1(veraPlus) {DeviceNumber = <Insert thermostat device id>};

var resultSetThermostate = await thermostat.ActionAsync(
	ServiceType.TemperatureSetpoint1,
	TemperatureSetpoint1Action.CurrentSetpoint,
	10,
	ConnectionType.Local);
```
