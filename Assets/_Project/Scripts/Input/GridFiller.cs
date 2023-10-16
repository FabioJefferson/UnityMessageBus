using System;
using System.Collections;// Note: actual namespace depends on the project name.

public class GridFiller
{
    public GridFiller(Piece[] all_p, Line[] all_l)
    {
        Fill(all_p);
        FillLine(all_l, all_p);
        Console.WriteLine("Fill data");

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
            Console.WriteLine("Fill Piece " + all_piece.Length);
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
            Console.WriteLine("Fill Line " + all_line.Length);
        }
    }
}
