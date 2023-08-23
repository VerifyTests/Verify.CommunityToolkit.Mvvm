using CommunityToolkit.Mvvm.Input;

class RelayCommandConverter :
    WriteOnlyJsonConverter<IRelayCommand>
{
    public override void Write(VerifyJsonWriter writer, IRelayCommand value)
    {
        var type = value.GetType();
        var executeField = type
            .GetField("execute", BindingFlags.Instance | BindingFlags.NonPublic)!;
        var canExecuteField = type
            .GetField("canExecute", BindingFlags.Instance | BindingFlags.NonPublic)!;
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