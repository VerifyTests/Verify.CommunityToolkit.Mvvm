class AsyncRelayCommandConverter :
    WriteOnlyJsonConverter<IAsyncRelayCommand>
{
    public override void Write(VerifyJsonWriter writer, IAsyncRelayCommand value)
    {
        var type = value.GetType();
        var executeField = type.GetInstanceField("execute");
        var canExecuteField = type.GetInstanceField("canExecute");
        var cancelableExecuteField = type.GetInstanceField("cancelableExecute");
        var execute = executeField.GetMethod(value);
        var canExecute = canExecuteField.GetMethod(value);
        var cancelableExecute = cancelableExecuteField.GetMethod(value);

        var numberOfMembers = NumberOfNotNullFields(execute, canExecute, cancelableExecute);

        if (numberOfMembers is 1)
        {
            if (execute is not null)
            {
                writer.Serialize(execute);
            }

            if (canExecute is not null)
            {
                writer.Serialize(canExecute);
            }

            if (cancelableExecute is not null)
            {
                writer.Serialize(cancelableExecute);
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

    private static int NumberOfNotNullFields(params MethodInfo?[] span) => span.OfType<MethodInfo>().Count();
}