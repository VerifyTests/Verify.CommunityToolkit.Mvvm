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
            _.Converters.Add(new AsyncRelayCommandInterfaceConverter());
            _.Converters.Add(new RelayCommandConverter());
            _.Converters.Add(new RelayCommandInterfaceConverter());
        });
    }

    internal static string? GetMethod(this FieldInfo field, object value)
    {
        var execute = (Delegate?) field.GetValue(value);
        if (execute == null)
        {
            return null;
        }

        var method = execute.Method;
        var type = method.DeclaringType;
        if (type != null)
        {
            return $"{type.FullName}.{method.Name}";
        }

        return method.Name;
    }

    internal static FieldInfo GetInstanceField(this Type type, string name) => type
            .GetField(name, BindingFlags.Instance | BindingFlags.NonPublic)!;
}
