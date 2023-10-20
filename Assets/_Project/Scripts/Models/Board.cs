using KLab.MessageBuses;

public class Board
{
    private Piece[] _pawns;
    private Line[] _lines;

    public Board()
    {
        _pawns = new Piece[9];
        _lines = new Line[8];
        FillGrid(_pawns, _lines);
    }

    private void FillGrid(Piece[] all_p, Line[] all_l)
    {
        Fill(all_p);
        FillLine(all_l, all_p);

        void Fill(Piece[] all_piece)
        {
            all_piece[0] = new Piece();
            all_piece[1] = new Piece();
            all_piece[2] = new Piece();
            all_piece[3] = new Piece();
            all_piece[4] = new Piece();
            all_piece[5] = new Piece();
            all_piece[6] = new Piece();
            all_piece[7] = new Piece();
            all_piece[8] = new Piece();
        }

        void FillLine(Line[] all_line, Piece[] all_piece)
        {
            all_line[0] = new Line(all_piece[0], all_piece[1], all_piece[2]);
            all_line[1] = new Line(all_piece[3], all_piece[4], all_piece[5]);
            all_line[2] = new Line(all_piece[6], all_piece[7], all_piece[8]);
            all_line[3] = new Line(all_piece[0], all_piece[3], all_piece[6]);
            all_line[4] = new Line(all_piece[1], all_piece[4], all_piece[7]);
            all_line[5] = new Line(all_piece[2], all_piece[5], all_piece[8]);
            all_line[6] = new Line(all_piece[0], all_piece[4], all_piece[8]);
            all_line[7] = new Line(all_piece[2], all_piece[4], all_piece[6]);
        }
    }

    public InputResult CheckForWin(Player currentPlayer, int input, Play play)
    {
      InputCheckResult inputResult = play.CheckInput(_pawns, input);

       if (!inputResult.InputAllowed)
        {
           // MessageBus.GetBus<IOErrorBus>().Broadcast(new ErrorMessage() { Message = "Wrong Input: Selected" });
            return new InputResult(false, null);
        }
        else
        {
            play.AssignOwnership(_pawns, input, currentPlayer);

            Player winnersId = play.CheckForWinnersId(_lines);

            if (winnersId != null)
            {
                return new InputResult(true, new PlaySessionResult(true, winnersId));
            }

            return new InputResult(true, new PlaySessionResult(false));
        }
    }

    //public String ReturnForm(int number)
    //{
    //    String tmp = "";
    //    if (number == -1)
    //    {
    //        tmp = ".";
    //    }
    //    if (number == 0)
    //    {
    //        tmp = "x";
    //    }
    //    if (number == 1)
    //    {
    //        tmp = "o";
    //    }
    //    return tmp;
    //}
    //
    //public void Show(Piece[] all_piece)
    //{
    //    for (int i = 0; i <= 2; i++)
    //    {
    //        Console.Write(i + " | ");
    //    }
    //    Console.WriteLine("\n-----------");
    //    for (int i = 3; i <= 5; i++)
    //    {
    //        Console.Write(i + " | ");
    //    }
    //    Console.WriteLine("\n-----------");
    //    for (int i = 6; i <= 8; i++)
    //    {
    //        Console.Write(i + " | ");
    //    }
    //    Console.WriteLine("\n");
    //    for (int i = 0; i <= 2; i++)
    //    {
    //        Console.Write(this.ReturnForm(all_piece[i].OwnerId) + " | ");
    //    }
    //    Console.WriteLine("\n-----------");
    //    for (int i = 3; i <= 5; i++)
    //    {
    //        Console.Write(this.ReturnForm(all_piece[i].OwnerId) + " | ");
    //    }
    //    Console.WriteLine("\n-----------");
    //    for (int i = 6; i <= 8; i++)
    //    {
    //        Console.Write(this.ReturnForm(all_piece[i].OwnerId) + " | ");
    //    }
    //    Console.WriteLine("\n");
    //}
}

