using System;
public static class GameVersion
{
    public static readonly int VERSION_MAJOR = 0;
    public static readonly int VERSION_MINOR = 1;
    public static readonly int VERSION_PATCH = 0;

    public static string Version
    {
        get
        {
            string _version = $"{VERSION_MAJOR}.{VERSION_MINOR}.{VERSION_PATCH}";
#if UNITY_EDITOR || UNITY_DEVELOPMENT
            _version += $" (Development Build)";
#endif
            return _version;
        }
    }
}
