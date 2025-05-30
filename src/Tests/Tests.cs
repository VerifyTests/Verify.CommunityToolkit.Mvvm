﻿public class Tests
{
    [Fact]
    public Task RelayCommandSimple()
    {
        var content = new RelayCommand(ActionMethod);
        return Verify(content);
    }

    #region RelayCommand

    [Fact]
    public Task RelayCommand()
    {
        var content = new RelayCommand(ActionMethod, CanExecuteMethod);
        return Verify(content);
    }

    #endregion

    [Fact]
    public Task GenericRelayCommandSimple()
    {
        var content = new RelayCommand<string>(ActionMethod);
        return Verify(content);
    }

    [Fact]
    public Task GenericRelayCommand()
    {
        var content = new RelayCommand<string>(ActionMethod, CanExecuteMethod);
        return Verify(content);
    }

    [Fact]
    public Task AsyncRelayCommandSimple()
    {
        var content = new AsyncRelayCommand(ActionMethodAsync);
        return Verify(content);
    }

    #region AsyncRelayCommand

    [Fact]
    public Task AsyncRelayCommand()
    {
        var content = new AsyncRelayCommand(ActionMethodAsync, CanExecuteMethod);
        return Verify(content);
    }

    #endregion

    [Fact]
    public Task AsyncRelayCommandWithCancellationTokenSimple()
    {
        var content = new AsyncRelayCommand(ActionMethodTokenAsync);
        return Verify(content);
    }

    [Fact]
    public Task AsyncRelayCommandWithCancellationToken()
    {
        var content = new AsyncRelayCommand(ActionMethodTokenAsync, CanExecuteMethod);
        return Verify(content);
    }

    [Fact]
    public Task GenericAsyncRelayCommandSimple()
    {
        var content = new AsyncRelayCommand<string>(ActionMethodAsync);
        return Verify(content);
    }

    [Fact]
    public Task GenericAsyncRelayCommand()
    {
        var content = new AsyncRelayCommand<string>(ActionMethodAsync, CanExecuteMethod);
        return Verify(content);
    }

    [Fact]
    public Task GenericAsyncRelayCommandWithCancellationTokenSimple()
    {
        var content = new AsyncRelayCommand<string>(ActionMethodTokenAsync);
        return Verify(content);
    }

    [Fact]
    public Task GenericAsyncRelayCommandWithCancellationToken()
    {
        var content = new AsyncRelayCommand<string>(ActionMethodTokenAsync, CanExecuteMethod);
        return Verify(content);
    }

    static bool CanExecuteMethod(string? obj) =>
        true;

    static void ActionMethod(string? obj)
    {
    }

    static Task ActionMethodAsync(string? obj) =>
        Task.CompletedTask;

    static Task ActionMethodAsync() =>
        Task.CompletedTask;

    static Task ActionMethodTokenAsync(string? obj, CancellationToken token) =>
        Task.CompletedTask;

    static Task ActionMethodTokenAsync(CancellationToken token) =>
        Task.CompletedTask;

    static void ActionMethod()
    {
    }

    static bool CanExecuteMethod() =>
        true;
}