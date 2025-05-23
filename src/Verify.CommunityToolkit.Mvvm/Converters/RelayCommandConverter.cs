class RelayCommandConverter :
    WriteOnlyJsonConverter<IRelayCommand>
{
    public override void Write(VerifyJsonWriter writer, IRelayCommand value)
    {
        var type = value.GetType();
        var executeField = type.GetInstanceField("execute");
        var canExecuteField = type.GetInstanceField("canExecute");
        var execute = (Delegate) executeField.GetValue(value)!;
        var canExecute = (Delegate?) canExecuteField.GetValue(value);
        if (canExecute == null)
        {
            writer.Serialize(execute.Method);
            return;
        }

        writer.WriteStartObject();
        writer.WriteMember(value, execute.Method, "Execute");
        writer.WriteMember(value, canExecute.Method, "CanExecute");
        writer.WriteEndObject();
    }

}