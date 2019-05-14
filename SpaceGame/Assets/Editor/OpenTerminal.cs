using System;
using System.IO;
using System.Diagnostics;
using UnityEngine;
using UnityEditor;

public class OpenTerminal : ScriptableObject
{
    [MenuItem("Space Game/Open Command Prompt")]
    static void OpenTerminalPrompt()
    {
        string appsFolder = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
        string terminalApp;

        Process process = new Process();
#if UNITY_EDITOR_OSX
        // Tested, and it works.
        terminalApp = Path.Combine(appsFolder, "Utilities", "Terminal.app");

        // Configure the process using the StartInfo properties.
        process.StartInfo.FileName = "open";
        process.StartInfo.Arguments = $"-a \"{terminalApp}\" ..";
#elif UNITY_EDITOR_WIN
        // Create task to open cmd.exe (or powershell)
#endif
        process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
        process.Start();

        UnityEngine.Debug.Log($"Opening command prompt at \"{terminalApp}\".\nCmd: {process.StartInfo.FileName} {process.StartInfo.Arguments}");
    }
}