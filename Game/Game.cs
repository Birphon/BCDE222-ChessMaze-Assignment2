using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game
{
    public class Game : IGame
    {

        protected int moveCount;
        protected int goalsLeft;
        protected Part activePart;
        protected int playerX = 0;
        protected int playerY = 0;
        protected int targetX;
        protected int targetY;
        protected int xMoveDistance;
        protected int yMoveDistance;
        protected int topBoarder = 0;
        protected int leftBoarder = 0;
        protected int bottomBoarder;
        protected int rightBoarder;
        protected string textOutput;
        protected Direction currentDirection;
        protected List<int> playerXMovement = new List<int>();
        protected List<int> playerYMovement = new List<int>();
        protected List<Part> playerPartHistory = new List<Part>();

        public Game()
        {
            moveCount = 0;
            goalsLeft = 1;
            playerX = 0;
            playerY = 0;
        }

        public int getPlayerX()
        {
            return playerX;
        }

        public int getPlayerY()
        {
            return playerY;
        }

        public int GetMoveCount()             
        {
            return moveCount;
        }

        
        public bool IsFinished()
        {
            if (playerX == rightBoarder && playerY == bottomBoarder)
            {
                return true;
            }
            else
            {
                return false;
            }
        }       

        protected void calculateMoveDistance()
        {
            xMoveDistance = targetX - playerX;
            yMoveDistance = targetY - playerY;
        }

        protected void changePosition()
        {
            playerY = playerY + yMoveDistance;
            playerX = playerX + xMoveDistance;
        }

        protected Part getActivePart()
        {
            return activePart;
        }

        protected string getActivePartString()
        {
            int currentActivePart = (int)activePart;
            return currentActivePart.ToString();
        }

        protected Part loadActivePart()
        {
            return (Part)Int32.Parse(getActivePartString());
        }

        public void Undo()
        {
            moveCount--;
            playerX = playerX - playerXMovement.Last();
            playerXMovement.RemoveAt(playerXMovement.Count - 1);
            playerY = playerY - playerYMovement.Last();
            playerYMovement.RemoveAt(playerYMovement.Count - 1);
            activePart = playerPartHistory.Last();
            playerPartHistory.RemoveAt(playerPartHistory.Count - 1);

        }

        public void Restart()
        {
            for (int a = 0; a < moveCount; a++)
            {
                Undo();
            }
        }

        public string filePath()
        {
            string filePath = @"C:\temp\ChessMaze\saves\savegame.txt";
            return filePath;
        }

        public void SaveMe()
        {            
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath()))
                {
                    sw.WriteLine(getActivePartString(), playerX, playerY);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public void Load(string newLevel)
        {
            try
            {
                using (StreamReader sr = new StreamReader(filePath()))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        newLevel = line;
                        loadActivePart(); // Dont think this works here
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        protected void recordMyMoves()
        {
            playerXMovement.Add(xMoveDistance);
            playerYMovement.Add(yMoveDistance);
        }

        public string returnTextOuput()
        {
            return textOutput;
        }
        public void Move(Direction moveDirection)
        {
            if (IsFinished() == true)
            {
                textOutput = "game finished congrates";
            }
            else
            {
                currentDirection = moveDirection;
                calculateMoveDistance();
                playerPartHistory.Add(getActivePart());
                switch (getActivePart())
                {
                    case Part.PlayerOnKing:
                        moveKing();
                        break;
                    case Part.PlayerOnBishop:
                        moveBishop();
                        break;
                    case Part.PlayerOnRook:
                        moveRook();
                        break;
                    case Part.PlayerOnKnight:
                        moveKnight();
                        break;
                }
            }
        }
        protected void MoveRecorder()
        {
            changePosition();
            recordMyMoves();
        }

        protected void NoMove()
        {
            Console.WriteLine("Can not move here!!");
        }

        // Dont think I can split King and Knight up based on how they move
        protected void moveKing()
        {
            switch (currentDirection)
            {
                case Direction.Up:
                    if (playerY == topBoarder)
                    {
                        NoMove();
                    }
                    else
                    {
                        playerY--;
                        playerXMovement.Add(0);
                        playerYMovement.Add(-1);
                    }
                    break;

                case Direction.UpLeft:
                    if (playerY == topBoarder || playerX == leftBoarder)
                    {
                        NoMove();
                    }
                    else
                    {
                        playerY--;
                        playerX--;
                        playerXMovement.Add(-1);
                        playerYMovement.Add(-1);
                    }
                    break;
                case Direction.UpRight:
                    if (playerY == topBoarder || playerX == rightBoarder)
                    {
                        NoMove();
                    }
                    else
                    {
                        playerY--;
                        playerX++;
                        playerXMovement.Add(1);
                        playerYMovement.Add(-1);
                    }
                    break;
                case Direction.Left:
                    if (playerX == leftBoarder)
                    {
                        NoMove();
                    }
                    else
                    {
                        playerX--;
                        playerXMovement.Add(-1);
                        playerYMovement.Add(0);
                    }
                    break;
                case Direction.Right:
                    if (playerX == rightBoarder)
                    {
                        NoMove();
                    }
                    else
                    {
                        playerX++;
                        playerXMovement.Add(1);
                        playerYMovement.Add(0);
                    }
                    break;

                case Direction.Down:
                    if (playerY == bottomBoarder)
                    {
                        NoMove();
                    }
                    else
                    {
                        playerY++;
                        playerXMovement.Add(0);
                        playerYMovement.Add(1);
                    }
                    break;
                case Direction.DownLeft:
                    if (playerY == bottomBoarder || playerX == rightBoarder)
                    {
                        NoMove();
                    }
                    else
                    {
                        playerY++;
                        playerX++;
                        playerXMovement.Add(-1);
                        playerYMovement.Add(1);
                    }
                    break;
                case Direction.DownRight:
                    if (playerY == bottomBoarder || playerX == rightBoarder)
                    {
                        NoMove();
                    }
                    else
                    {
                        playerY++;
                        playerX++;
                        playerXMovement.Add(1);
                        playerYMovement.Add(1);
                    }
                    break;
            }
        }

        protected void moveKnight()
        {
            switch (xMoveDistance, yMoveDistance)
            {
                // left 2 up 1
                case (-2, -1):
                    if ((playerY - 1) == topBoarder || (playerX - 2) == leftBoarder)
                    {
                        NoMove();
                    }
                    else
                    {
                        MoveRecorder();
                    }
                    break;
                // left 1 up 2
                case (-1, -2):
                    if ((playerY - 2) == topBoarder || (playerX - 1) == leftBoarder)
                    {
                        NoMove();
                    }
                    else
                    {
                        MoveRecorder();
                    }
                    break;
                // right 1 up 2
                case (1, -2):
                    if ((playerY - 2) == topBoarder || (playerX + 1) == rightBoarder)
                    {
                        NoMove();
                    }
                    else
                    {
                        MoveRecorder();
                    }
                    break;
                // right 2 up 1  
                case (2, -1):
                    if ((playerY - 1) == topBoarder || (playerX + 2) == rightBoarder)
                    {
                        NoMove();
                    }
                    else
                    {
                        MoveRecorder();
                    }
                    break;
                // right 2 down 1
                case (2, 1):
                    if ((playerY + 1) == bottomBoarder || (playerX + 2) == rightBoarder)
                    {
                        NoMove();
                    }
                    else
                    {
                        MoveRecorder();
                    }
                    break;
                // right 1 down 2
                case (1, 2):
                    if ((playerY - 2) == bottomBoarder || (playerX + 1) == rightBoarder)
                    {
                        NoMove();
                    }
                    else
                    {
                        MoveRecorder();
                    }
                    break;
                // left 1 down 2
                case (-1, 2):
                    if ((playerY + 2) == bottomBoarder || (playerX - 1) == leftBoarder)
                    {
                        NoMove();
                    }
                    else
                    {
                        MoveRecorder();
                    }
                    break;
                // left 2 down 1
                case (-2, 1):
                    if ((playerY + 1) == bottomBoarder || (playerX - 2) == leftBoarder)
                    {
                        NoMove();
                    }
                    else
                    {
                        MoveRecorder();
                    }
                    break;
            }
        }

        protected void moveRook()
        {
            switch (currentDirection)
            {
                case Direction.Up:
                    moveUp();
                    break;
                case Direction.Left:
                    moveLeft();
                    break;
                case Direction.Right:
                    moveRight();
                    break;
                case Direction.Down:
                    moveDown();
                    break;
            }
        }

        protected void moveBishop()
        {
            switch (currentDirection)
            {
                case Direction.UpRight:
                    moveUpRight();
                    break;
                case Direction.DownRight:
                    moveDownRight();
                    break;
                case Direction.DownLeft:
                    moveDownLeft();
                    break;

                case Direction.UpLeft:
                    moveUpLeft();
                    break;
            }
        }

        protected void moveQueen()
        {
            switch (currentDirection)
            {
                case Direction.Up:
                    moveUp();
                    break;
                case Direction.Right:
                    moveRight();
                    break;
                case Direction.Down:
                    moveDown();
                    break;
                case Direction.Left:
                    moveLeft();
                    break;
                case Direction.UpRight:
                    moveUpRight();
                    break;
                case Direction.DownRight:
                    moveDownRight();
                    break;
                case Direction.DownLeft:
                    moveDownLeft();
                    break;
                case Direction.UpLeft:
                    moveUpLeft();
                    break;
            }
        }

        // If Future pieces get added and have similar movesets to Rook/Bishop/Queen
        protected void moveUp()
        {
            if (playerY == topBoarder)
            {
                NoMove();
            }
            else
            {
                changePosition();
                recordMyMoves();
            }
        }
        protected void moveRight()
        {
            if (playerX == rightBoarder)
            {
                NoMove();
            }
            else
            {
                changePosition();
                recordMyMoves();
            }
        }
        protected void moveDown()
        {
            if (playerY == bottomBoarder)
            {
                NoMove();
            }
            else
            {
                changePosition();
                recordMyMoves();
            }
        }
        protected void moveLeft()
        {
            if (playerX == leftBoarder)
            {
                NoMove();
            }
            else
            {
                changePosition();
                recordMyMoves();
            }
        }
        protected void moveUpRight()
        {
            if (playerY == topBoarder || playerX == leftBoarder || (0 - yMoveDistance == 0 + xMoveDistance))
            {
                NoMove();
            }
            else
            {
                MoveRecorder();
            }
        }
        protected void moveDownRight()
        {
            if (playerY == bottomBoarder || playerX == rightBoarder || (0 - yMoveDistance == 0 - xMoveDistance))
            {
                NoMove();
            }
            else
            {
                MoveRecorder();
            }
        }
        protected void moveDownLeft()
        {
            if (playerY == bottomBoarder || playerX == leftBoarder || (0 + yMoveDistance == 0 - xMoveDistance))
            {
                NoMove();
            }
            else
            {
                MoveRecorder();
            }
        }
        protected void moveUpLeft()
        {
            if (playerY == topBoarder || playerX == leftBoarder || (0 + yMoveDistance == 0 + xMoveDistance))
            {
                NoMove();
            }
            else
            {
                MoveRecorder();
            }
        }
    }
}