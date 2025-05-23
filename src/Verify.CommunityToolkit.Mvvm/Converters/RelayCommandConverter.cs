class RelayCommandConverter :
    WriteOnlyJsonConverter<RelayCommand>
{
    static FieldInfo execute = typeof(RelayCommand).GetInstanceField("execute");
    static FieldInfo canExecute = typeof(RelayCommand).GetInstanceField("canExecute");

    public override void Write(VerifyJsonWriter writer, RelayCommand value) =>
        CommandWriter.Write(writer, value, execute, canExecute);
}