using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputResult
{
    public readonly bool InputSuccess;
    public readonly PlaySessionResult ResultOnInputSuccess;
    public readonly string ErrorMessageOnFail;

    public InputResult(bool inputSuccess, PlaySessionResult resultOnInputSuccess, string errorMessageOnFail = "")
    {
        InputSuccess = inputSuccess;
        ResultOnInputSuccess = resultOnInputSuccess;
        ErrorMessageOnFail = errorMessageOnFail;
    }
}

public class PlaySessionResult
{
    public readonly bool WinOccured;

    public readonly Player Winner;

    public PlaySessionResult(bool winOccured, Player winner = null)
    {
        WinOccured = winOccured;
        Winner = winner;
    }
}

public enum SessionEndResult
{
    None = 0,
    Win,
    Draw
}
