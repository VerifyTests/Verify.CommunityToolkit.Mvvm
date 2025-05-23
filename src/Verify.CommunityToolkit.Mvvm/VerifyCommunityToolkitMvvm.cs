namespace VerifyTests;

public static class VerifyCommunityToolkitMvvm
{
    public static bool Initialized { get; private set; }

    public static void Initialize()
    {
        if (Initialized)
        {
            throw new("Already Initialized");
        }

        Initialized = true;

        InnerVerifier.ThrowIfVerifyHasBeenRun();
        VerifierSettings.AddExtraSettings(_ =>
        {
            _.Converters.Add(new AsyncRelayCommandConverter());
            _.Converters.Add(new RelayCommandConverter());
        });
    }

    internal static MethodInfo? GetMethod(this FieldInfo field, object value)
    {
        var execute = (Delegate?) field.GetValue(value);
        return execute?.Method;
    }

    internal static FieldInfo GetInstanceField(this Type type, string name) => type
            .GetField(name, BindingFlags.Instance | BindingFlags.NonPublic)!;
}
