using System;
 
public class InputManager
{
    public int InputResult;
    public bool IsSuccess;
    public String Response="";
    public InputManager(string input)
    {
        int response;
        if (int.TryParse(input, out response))
        {
            InputResult = response;
            IsSuccess = true;
            Response = "Success: "+InputResult;
        }
        else
        {
            IsSuccess = false;
            Response = "error: " + InputResult;
        }
    }
}
