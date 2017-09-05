---
title: NServiceBus Host Upgrade Version 7 to 8
summary: Instructions on how to upgrade NServiceBus Host Version 7 to 8.
reviewed: 2016-04-06
component: Host
related:
 - nservicebus/upgrades/6to7
isUpgradeGuide: true
upgradeGuideCoreVersions:
 - 6
 - 7
---

The NServiceBus will be deprecated as of Version 9 and users are recommended to avoid using it for new endpoints. Upgrading existing endpoints is still supported for Version 8

## Incompatible with NuGet X.Y

NuGet no longer support packages adding files and modifying project files. This means that installing the host won't result in a runnable endpoint.

TBD: Is it possible/should we add instructions on how to manually modify the csproj to get this working?


## Incompatible with the new Visual Studio project system

TBD: What is actally not compatible?

## Migrating procedure

Create a new console application project. According to the following guidelined LINK TO SAMPLE

### Configuration

Self hosting gives access to the same configuration options. See below for migration of host specific configuration API's.

#### Custom endpoint configuration

Configuration code in `IConfigureThisEndpoint.Customize` can be transfered as is to the configuration of the self hosted endpoint.

#### Roles

The `AsA_Client` role can be replaces with the followin configuration:

snippet: 7to8AsAClient 

#### Endpoint name

The host defaults the endpoint name to the namespace of the type implementing `IConfigureThisEndpoint`. Just pass that value to the name to the constructor of `EndpointConfiguration`.


#### Overriding endpoint name

Overriding endpoint name using the `EndpointName` attribute or `DefineEndpointName` method is no longer needed. Pass the relevant name to the constructor of `EndpointConfiguration`.

#### Defining SLA for the endpoint

Is this still a thing?

#### Executing custom code on start and stop

The host allowed custom code to run at start and stop by implementing `IWantToRunWhenEndpointStartsAndStops`. Since self hosted endpoints are in full control over start and stop this code can be executed explicitly when starting/stopping.

#### Profiles    

Profiles allowed customization of configuration based on the environment the enpoint is running in. When custom hosting you can explicitly inspect Environment variables, command lines arguments, machine names etc. and make relevant configuration adjustments accordingly. 

### Installation

TBD