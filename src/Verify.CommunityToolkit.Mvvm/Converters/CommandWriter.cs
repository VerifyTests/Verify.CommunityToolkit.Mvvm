static class CommandWriter
{
    public static void Write(VerifyJsonWriter writer, IAsyncRelayCommand value, FieldInfo executeField, FieldInfo canExecuteField, FieldInfo cancelableExecuteField)
    {
        var execute = executeField.GetMethod(value);
        var canExecute = canExecuteField.GetMethod(value);
        var cancelableExecute = cancelableExecuteField.GetMethod(value);

        var span = new[] {execute, canExecute, cancelableExecute};
        var numberOfMembers = span.OfType<string>().Count();

        if (numberOfMembers is 1)
        {
            if (execute is not null)
            {
                writer.WriteValue(execute);
            }

            if (canExecute is not null)
            {
                writer.WriteValue(canExecute);
            }

            if (cancelableExecute is not null)
            {
                writer.WriteValue(cancelableExecute);
            }
        }
        else
        {
            writer.WriteStartObject();
            if (execute is not null)
            {
                writer.WriteMember(value, execute, "Execute");
            }

            if (canExecute is not null)
            {
                writer.WriteMember(value, canExecute, "CanExecute");
            }

            if (cancelableExecute is not null)
            {
                writer.WriteMember(value, cancelableExecute, "CancelableExecute");
            }

            writer.WriteEndObject();
        }
    }

    public static void Write(VerifyJsonWriter writer, IRelayCommand value, FieldInfo executeField, FieldInfo canExecuteField)
    {
        var execute = executeField.GetMethod(value)!;
        var canExecute = canExecuteField.GetMethod(value);
        if (canExecute == null)
        {
            writer.WriteValue(execute);
            return;
        }

        writer.WriteStartObject();
        writer.WriteMember(value, execute, "Execute");
        writer.WriteMember(value, canExecute, "CanExecute");
        writer.WriteEndObject();
    }
}