using System;
using System.Collections;// Note: actual namespace depends on the project name.

public class Line
{
    public Piece[] Piece = new Piece[3];
    public Line(Piece p1,Piece p2,Piece p3)
    {
        Piece[0] = p1;
        Piece[1] = p2;
        Piece[2] = p3;
    // print("Constructeur Line");
    }
}