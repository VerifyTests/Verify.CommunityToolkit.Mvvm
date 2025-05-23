class RelayCommandConverter :
    WriteOnlyJsonConverter<IRelayCommand>
{
    public override void Write(VerifyJsonWriter writer, IRelayCommand value)
    {
        var type = value.GetType();
        var executeField = type.GetInstanceField("execute");
        var canExecuteField = type.GetInstanceField("canExecute");
        var execute = executeField.GetMethod(value)!;
        var canExecute = canExecuteField.GetMethod(value);
        if (canExecute == null)
        {
            writer.Serialize(execute);
            return;
        }

        writer.WriteStartObject();
        writer.WriteMember(value, execute, "Execute");
        writer.WriteMember(value, canExecute, "CanExecute");
        writer.WriteEndObject();
    }
}