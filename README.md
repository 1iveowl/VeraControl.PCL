# Vera Control .NET Library

[![NuGet](https://img.shields.io/badge/nuget-v0.6.0-brightgreen.svg)](https://www.nuget.org/packages/VeraControl.PCL/) [![.NET Standard](http://img.shields.io/badge/.NET_Standard-1.2-green.svg)](https://docs.microsoft.com/da-dk/dotnet/articles/standard/library)
## Why this library

The purpose of the Vera Control .NET Library is to facilitate interoperability with the [Vera Smart Home Controller](http://getvera.com/ "Vera Smart Home Controller").

This library works across iOS, Android and Windows 8.1, Windows 10, .NET Core and .NET 4.5.1+ and supports [Xamarin](https://www.xamarin.com/ "Xamarin").

There already exist another library with a similar purpose - i.e. the [.NET Library for Micasaverde (Vera) Home Automation Controllers](http://veradotnet.codeplex.com/ ".NET Library for Micasaverde (Vera) Home Automation Controllers") - however that library have not evolved since early 2015 and while it is currently more complete in terms of device and services support, that library have some short-comings, which inspired me to create this Vera Control .NET Library from scratch. 

The Vera Control .NET Library supports async/await and I find it more simple to use. 

## Devices and Services Support
The current version supports the following Devices (although not necessary all Services and StateVariables):
- HomeAutmationGateway1
- BinaryLight1
- Dimmer1
- VContainer1
- VSwitch1
- HVAC_Thermostat1
- TemperatureSensor1

The current version implementns the follwing Services:
- SwitchPower1
- TemperatureSensor1
- TemperatureSetpoint1
- VContainer1
- Dimmer1
- HomeAutomationGateway1

## How This Library Works
The Library works by abstracting http [Luup Requests](http://wiki.micasaverde.com/index.php/Luup_Requests "Luup Requests"). 

This library also takes care of managing the authentication scheme with the Vera cloud service. 

As soon as the authentication is established this library can access Vera controllers on the local network and/or using the Vera Cloud Relay. 

Connection type can be defined for each request using `ConnectionType.Local` or `ConnectionType.Remote` respectively (see examples below).

## How to use this library
The library works with Xamarin across iOS, Android, Windows 8.1 and lated, Windows Phone 8.1 and later and .NET 4.5.1 and later. 

Usage is simple:

1. Get the NuGet.
1. Start writing code:

Relevant Using statements:
```csharp
using IVeraControl.Model;
using VeraControl.Service;
using UpnpModels.Model;
using UpnpModels.Model.UpnpDevice;
using UpnpModels.Model.UpnpService;
```
How to begin:

```csharp
// Create an instance of the Vera Service
var veraService = new VeraControlService();

// Get all Vera Controllers in your set-up using your username and password
var controllers = await veraService.GetControllers(username, password);

//Pick the controller you want interact with.
var veraPlus = controllers.FirstOrDefault(c => c.DeviceSerialId == "<Insert your device ID here>");
```
Note: that the instance veraPlus is used through-out the following examples - i.e. it is injected into each instance of an UPnP Device/Service.
#### To Check If Vera Controller is Alive

```csharp
// Check if controller is alive in local network
var aliveLocal = await veraPlus.IsAliveAsync(ConnectionType.Local);

// ... or check if controller is alive via the Vera Cloud Relay
var aliveRemote = await veraPlus.IsAliveAsync(ConnectionType.Remote);
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
var binaryLight = new BinaryLight1(veraPlus) {DeviceNumber = <Insert Binary Switch Device Id>};

var binaryLightStatus = await binaryLight.GetStateVariableAsync(
	ServiceType.SwitchPower1, 
	SwitchPower1StateVariable.Status, 
	ConnectionType.Local);

var result = await binaryLight.ActionAsync(
	ServiceType.SwitchPower1, 
	SwitchPower1Action.SetTarget, 
	!binaryLightStatus, // i.e. setting the value to the opposite of the currently set value.
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

#### Reload The Luup Engine
Sometimes it makes sense to reload the Luup Engine. The details about when this is relevant is beyond this Readme, however it is easy to do with the library:

`var reload = await veraPlus.ReloadAsync(ConnectionType.Local);`

The reload will by default await fir the controller to to come back alive after the reload again (typically this takes 10-30 seconds), however if you don't want the code to wait, then just set the waitUntilAliveAgain to false like this:

`var reload = await veraPlus.ReloadAsync(ConnectionType.Local, waitUntilAliveAgain:false);`

## Adding UPnP Devices and Services
To add new capabilities to the library all you need to do is to extend the [UPnPModels Assembly](https://github.com/1iveowl/VeraControl.PCL/tree/master/src/main/Upnp/UpnpModels "UPnPModels Assembly") - or you could theoretically create your very own, as long as you adhere to the interfaces defined in IVeraControl. 

For instance look at the device `BinaryLight1`, which has one service `SwitchPower1` as defined in the constructor:

```csharp
public class BinaryLight1 : UpnpDeviceBase, IUpnpDevice
{
	public string DeviceUrn => "urn:schemas-upnp-org:device:BinaryLight:1";

	public string DeviceName => nameof(BinaryLight1);


	public BinaryLight1(IVeraController controller)
	{
		Services = new List<IUpnpService> { new SwitchPower1(controller, this) };
	}
}
```

The `SwitchPower1` service is defined in the following. To make the service easy to use the enums `SwitchPower1Action` and `SwitchPower1StateVariable` are created:

```csharp
public enum SwitchPower1Action
{
	SetTarget,
}

public enum SwitchPower1StateVariable
{
	Target,
	Status
}

public class SwitchPower1 : UpnpServiceBase, IUpnpService
{
	public string ServiceUrn => "urn:upnp-org:serviceId:SwitchPower1";
	public string ServiceName { get; } = ServiceType.SwitchPower1.ToString();

	public SwitchPower1(IVeraController controller, IUpnpDevice device)
	{
		StateVariables = new List<IUpnpStateVariable>
		{
			new UpnpStateVariable(controller, this, device)
			{
				VariableName = SwitchPower1StateVariable.Target.ToString(),
				Type = typeof(bool)
			},
			new UpnpStateVariable(controller, this, device)
			{
				VariableName = SwitchPower1StateVariable.Status.ToString(),
				Type = typeof(bool)
			}
		};

		Actions = new List<IUpnpAction>
		{
			new UpnpAction(controller, this, device)
			{
				ActionName = SwitchPower1Action.SetTarget.ToString(),
				ArgumentName = "newTargetValue",
				Type = typeof(bool),
				Value = null,
				Direction = Direction.In
			},
		};
	}
}
```
Finally to make it even easier to use `SwitchPower1` it has been added to the `ServiceType enum`. New services should be added here too:
```csharp
public enum ServiceType
{
	SwitchPower1,
	TemperatureSensor1,
	TemperatureSetpoint1,
	VContainer1,
	Dimmer1,
	HomeAutomationGateway1
}
```

That is it!

If you decide add new Services and Devices please don't hesitate to do a Pull Request here to extend this library.
