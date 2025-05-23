class RelayCommandInterfaceConverter :
    WriteOnlyJsonConverter<IRelayCommand>
{
    public override void Write(VerifyJsonWriter writer, IRelayCommand value)
    {
        var type = value.GetType();
        var executeField = type.GetInstanceField("execute");
        var canExecuteField = type.GetInstanceField("canExecute");
        CommandWriter.Write(writer, value, executeField, canExecuteField);
    }
}