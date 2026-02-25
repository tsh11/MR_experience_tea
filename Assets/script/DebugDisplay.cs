using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugDisplay : MonoBehaviour
{
    public Text debugText;
    private string logHistory = "";

    void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        logHistory += logString + "\n";
        debugText.text = logHistory;

        // 控制最多顯示 10 行
        var lines = logHistory.Split('\n');
        if (lines.Length > 10)
        {
            logHistory = string.Join("\n", lines, lines.Length - 10, 10);
        }
    }
}