# <img src="/src/icon.png" height="30px"> Verify.CommunityToolkit.Mvvm

[![Discussions](https://img.shields.io/badge/Verify-Discussions-yellow?svg=true&label=)](https://github.com/orgs/VerifyTests/discussions)
[![Build status](https://ci.appveyor.com/api/projects/status/sb66s1o8w1t9ba70?svg=true)](https://ci.appveyor.com/project/SimonCropp/verify-communitytoolkit-mvvm)
[![NuGet Status](https://img.shields.io/nuget/v/Verify.CommunityToolkit.Mvvm.svg)](https://www.nuget.org/packages/Verify.CommunityToolkit.Mvvm/)

Extends [Verify](https://github.com/VerifyTests/Verify) to allow verification of [CommunityToolkit.Mvvm](https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/).


## NuGet package

https://nuget.org/packages/Verify.CommunityToolkit.Mvvm/


## Usage

<!-- snippet: Enable -->
<a id='snippet-enable'></a>
```cs
[ModuleInitializer]
public static void Initialize() =>
    VerifyCommunityToolkitMvvm.Initialize();
```
<sup><a href='/src/Tests/ModuleInitializer.cs#L3-L9' title='Snippet source file'>snippet source</a> | <a href='#snippet-enable' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### RelayCommand

<!-- snippet: RelayCommand -->
<a id='snippet-relaycommand'></a>
```cs
[Fact]
public Task RelayCommand()
{
    var content = new RelayCommand(ActionMethod, CanExecuteMethod);
    return Verify(content);
}
```
<sup><a href='/src/Tests/Tests.cs#L10-L19' title='Snippet source file'>snippet source</a> | <a href='#snippet-relaycommand' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

Results in: 

<!-- snippet: Tests.RelayCommand.verified.txt -->
<a id='snippet-Tests.RelayCommand.verified.txt'></a>
```txt
{
  Execute: Tests.ActionMethod(),
  CanExecute: Tests.CanExecuteMethod()
}
```
<sup><a href='/src/Tests/Tests.RelayCommand.verified.txt#L1-L4' title='Snippet source file'>snippet source</a> | <a href='#snippet-Tests.RelayCommand.verified.txt' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

### AsyncRelayCommand

<!-- snippet: AsyncRelayCommand -->
<a id='snippet-asyncrelaycommand'></a>
```cs
[Fact]
public Task AsyncRelayCommand()
{
    var content = new AsyncRelayCommand(ActionMethodAsync, CanExecuteMethod);
    return Verify(content);
}
```
<sup><a href='/src/Tests/Tests.cs#L42-L51' title='Snippet source file'>snippet source</a> | <a href='#snippet-asyncrelaycommand' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

Results in: 

<!-- snippet: Tests.AsyncRelayCommand.verified.txt -->
<a id='snippet-Tests.AsyncRelayCommand.verified.txt'></a>
```txt
{
  Execute: Tests.ActionMethodAsync(),
  CanExecute: Tests.CanExecuteMethod()
}
```
<sup><a href='/src/Tests/Tests.AsyncRelayCommand.verified.txt#L1-L4' title='Snippet source file'>snippet source</a> | <a href='#snippet-Tests.AsyncRelayCommand.verified.txt' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->
