public class Play
{
    public bool ShoudlSwitchPlayer = true;

    public Player CheckForWinnersId(Line[] all_line)
    {
        int counter = 0;

        foreach (var ll in all_line)
        {
            Player test = GetOwnerOnMatch(ll);
            if (test != null)
            {
                return test;
            }
            counter++;
        }
        return null;

        Player GetOwnerOnMatch(Line l)
        {
            Player reference = l.Piece[0].Owner;
            for (int i = 0, count = 0; i < l.Piece.Length; i++)
            {
                if (l.Piece[i].Owner == reference)
                {
                    count++;
                    if (count >= 3)
                    {
                        return reference;
                    }
                }
            }          
            return null;
        }
    }

    public InputCheckResult CheckInput(Piece[] all_p, int input)
    {
        if (all_p[input].Owner != null)
        {
            ShoudlSwitchPlayer = false;
            return new(false);
        }
        return new(true, input);
    }
    
    public void AssignOwnership(Piece[] all_p, int input, Player currentPlayer)
    {
        ShoudlSwitchPlayer = true;
        all_p[input].Owner = currentPlayer;
    }
}

public class InputCheckResult
{
    public readonly bool InputAllowed;
    public readonly int Input;

    public InputCheckResult(bool inputAllowed, int input = -1)
    {
        InputAllowed = inputAllowed;
        Input = input;
    }
}

