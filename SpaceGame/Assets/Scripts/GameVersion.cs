//
// 	Copyright (C) 2019 Outlaw Games Studio. All Rights Reserved.
//
// 	This document is the property of Outlaw Games Studio.
// 	It is considered confidential and proprietary.
//
// 	This document may not be reproduced or transmitted in any form
// 	without the consent of Outlaw Games Studio.
//
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
            _version += $" (Development Build)"
#endif
            return _version;
        }
    }
}
