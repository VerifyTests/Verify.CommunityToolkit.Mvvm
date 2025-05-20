class AsyncRelayCommandConverter :
    WriteOnlyJsonConverter<IAsyncRelayCommand>
{
    public override void Write(VerifyJsonWriter writer, IAsyncRelayCommand value)
    {
        var type = value.GetType();
        var executeField = type
            .GetField("execute", BindingFlags.Instance | BindingFlags.NonPublic);
        var canExecuteField = type
            .GetField("canExecute", BindingFlags.Instance | BindingFlags.NonPublic);
        var cancelableExecuteField = type
            .GetField("cancelableExecute", BindingFlags.Instance | BindingFlags.NonPublic);
        var execute = (Delegate?) executeField?.GetValue(value);
        var canExecute = (Delegate?) canExecuteField?.GetValue(value);
        var cancelableExecute = (Delegate?) cancelableExecuteField?.GetValue(value);

        var numberOfMembers = NumberOfNotNullFields(execute, canExecute, cancelableExecute);

        if (numberOfMembers is 1)
        {
            if (execute is not null)
            {
                writer.Serialize(execute.Method);
            }

            if (canExecute is not null)
            {
                writer.Serialize(canExecute.Method);
            }

            if (cancelableExecute is not null)
            {
                writer.Serialize(cancelableExecute.Method);
            }
        }
        else
        {
            writer.WriteStartObject();
            if (execute is not null)
            {
                writer.WriteMember(value, execute.Method, "Execute");
            }

            if (canExecute is not null)
            {
                writer.WriteMember(value, canExecute.Method, "CanExecute");
            }

            if (cancelableExecute is not null)
            {
                writer.WriteMember(value, cancelableExecute.Method, "CancelableExecute");
            }

            writer.WriteEndObject();
        }
    }

    private static int NumberOfNotNullFields<T>(params T?[] span) => span.OfType<T>().Count();
}