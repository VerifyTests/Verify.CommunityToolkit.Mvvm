class AsyncRelayCommandConverter :
    WriteOnlyJsonConverter<AsyncRelayCommand>
{
    static FieldInfo execute = typeof(AsyncRelayCommand).GetInstanceField("execute");
    static FieldInfo canExecute = typeof(AsyncRelayCommand).GetInstanceField("canExecute");
    static FieldInfo cancelableExecute = typeof(AsyncRelayCommand).GetInstanceField("cancelableExecute");

    public override void Write(VerifyJsonWriter writer, AsyncRelayCommand value) =>
        CommandWriter.Write(writer, value, execute, canExecute, cancelableExecute);
}