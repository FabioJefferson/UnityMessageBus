using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public  interface Logics
{
    Position GetPlayerLastPosition();
    public void setPosition();
    Position GetIALastPosition();
    int GetIACurrentPosition();
    bool CheckPlayerPosition();
    bool CheckIAPreviousPosition();
    void  CheckPosition(int playerPosition);
    bool CheckIfSeriesExists( List<int> PlayerMoves);
}
