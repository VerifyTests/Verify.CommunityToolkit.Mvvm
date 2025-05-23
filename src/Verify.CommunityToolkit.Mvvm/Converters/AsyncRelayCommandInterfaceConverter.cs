class AsyncRelayCommandInterfaceConverter :
    WriteOnlyJsonConverter<IAsyncRelayCommand>
{
    public override void Write(VerifyJsonWriter writer, IAsyncRelayCommand value)
    {
        var type = value.GetType();
        var executeField = type.GetInstanceField("execute");
        var canExecuteField = type.GetInstanceField("canExecute");
        var cancelableExecuteField = type.GetInstanceField("cancelableExecute");
        CommandWriter.Write(writer, value, executeField, canExecuteField, cancelableExecuteField);
    }
}