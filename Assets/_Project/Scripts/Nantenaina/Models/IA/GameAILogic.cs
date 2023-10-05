

//using System;
//using System.Collections.Generic;

//public class GameAILogic : Logics
//{
//    public Position PlayerLastPosition = new();
//    public List<int> PlayerMoves = new();
//    public Position CurrentIAPosition = new();
//    public List<int> IaMoves = new();
//    public bool IsPlayFirst = true;
//    private Series _series = new();
//    public int Id;
//    private bool isSeriesExist = false;
//    private bool isFirstMove = true;

//    public bool CheckIAPreviousPosition()
//    {
//        throw new NotImplementedException();
//    }

//    public bool CheckPlayerPosition()
//    {
//        throw new NotImplementedException();
//    }

//    public int GetIACurrentPosition()
//    {
//        if (CurrentIAPosition.GridIndex != 999)
//        {
//            Console.WriteLine("pos" + CurrentIAPosition.GridIndex);
//            return this.CurrentIAPosition.GridIndex;
//        }
//        return this.PlayerLastPosition.GridIndex;
//    }

//    public Position GetIALastPosition()
//    {
//        throw new NotImplementedException();
//    }

//    public Position GetPlayerLastPosition()
//    {
//        throw new NotImplementedException();
//    }


//    public void setPosition()
//    {
//        isSeriesExist = CheckIfSeriesExists(PlayerMoves);

//        if (IsPlayFirst && isFirstMove)
//        {

//            this.CurrentIAPosition.GridIndex = 4;
//            this.IaMoves.Add(this.CurrentIAPosition.GridIndex);
//            isFirstMove = false;
//        }
//        if (!IsPlayFirst && isFirstMove)
//        {
//            if (this.PlayerLastPosition.GridIndex != 4)
//            {
//                this.CurrentIAPosition.GridIndex = 4;
//                this.IaMoves.Add(this.CurrentIAPosition.GridIndex);
//            }
//            else
//            {
//                this.CurrentIAPosition.GridIndex = GetRandomPosition();
//                this.IaMoves.Add(this.CurrentIAPosition.GridIndex);
//            }

//        }
//        else
//        {
//            this.CurrentIAPosition.GridIndex = GetRandomPosition() - 1;
//        }


//    }
//    private int GetRandomPosition()
//    {
//        return new Random().Next(0, 5) + 1;
//    }

//    public void CheckPosition(int playerPosition)
//    {
//        if (playerPosition == 1)
//        {
//            this.PlayerLastPosition.GridIndex += 1;
//        }
//        else if (playerPosition == 2)
//        {

//        }


//    }

//    public bool CheckIfSeriesExists(List<int> playerMoves)
//    {
//        if (playerMoves.Count >= 2)
//        {
//            if (playerMoves.Contains(1))
//                return true;
//        }


//        return false;
//    }

  
//}
