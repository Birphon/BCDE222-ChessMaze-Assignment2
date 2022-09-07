using System;
using System.Data.Common;

namespace LevelDesigner
{
    public class Level : ILevel
    {
        private IFileableExtension _currentLevel;
        private int _width;
        private Part[,] _level;
        private int _height;
        private bool validLevel;

        private int levelsMade;

        private int goalX;
        private int goalY;
        private int totalNumOfGoals;

        private int xPlayerValue;
        private int yPlayerValue;
        private int playerCount;


        public Level(string loadedLevel = "REN\nEER\nBBK")
        {
            string[] actualLevel = loadedLevel.Split('\n');
            int actualWidth = actualLevel[0].Length;
            int actualHeight = actualLevel.Length;

            CreateLevel(3,3);
            AddBishop(0,0);
            AddEmpty(0,1);
            AddKing(0,2);
            AddKnight(1,0);
        }

        public void AddBishop(int gridX, int gridY)                                             //Feature 2 Add Bishop
        {
            if (gridX >= 0 && gridX < _height && gridY >= 0 && gridY < _width)
            {
                _level[gridX, gridY] = Part.Bishop;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void AddEmpty(int gridX, int gridY)                                              //Feature 3 Add Empty
        {
            if (gridX >= 0 && gridX < _height && gridY >= 0 && gridY < _width)
            {
                _level[gridX, gridY] = Part.Empty;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void AddKing(int gridX, int gridY)                                               //Feature 4 Add King
        {
            if (gridX >= 0 && gridX < _height && gridY >= 0 && gridY < _width)
            {
                _level[gridX, gridY] = Part.King;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void AddKnight(int gridX, int gridY)                                             //Feature 11 Add Knight
        {
            if (gridX >= 0 && gridX < _height && gridY >= 0 && gridY < _width)
            {
                _level[gridX, gridY] = Part.Knight;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void AddPlayerOnBishop(int gridX, int gridY)                                     //Feature 5 Add Player On Bishop
        {
            if (gridX >= 0 && gridX < _height && gridY >= 0 && gridY < _width)
            {
                _level[gridX, gridY] = Part.PlayerOnBishop;
                xPlayerValue = gridX;
                yPlayerValue = gridY;
                playerCount++;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void AddPlayerOnEmpty(int gridX, int gridY)                                      //Feature 6 Add Player On Empty
        {
            if (gridX >= 0 && gridX < _height && gridY >= 0 && gridY < _width)
            {
                _level[gridX, gridY] = Part.PlayerOnEmpty;
                xPlayerValue = gridX;
                yPlayerValue = gridY;
                playerCount++;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void AddPlayerOnKing(int gridX, int gridY)                                       //Feature 7 Add Player On King
        {
            if (gridX >= 0 && gridX < _height && gridY >= 0 && gridY < _width)
            {
                _level[gridX, gridY] = Part.PlayerOnKing;
                xPlayerValue = gridX;
                yPlayerValue = gridY;
                playerCount++;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void AddPlayerOnKnight(int gridX, int gridY)                                     //Feature 8 Add Player On Knight
        {
            if (gridX >= 0 && gridX < _height && gridY >= 0 && gridY < _width)
            {
                _level[gridX, gridY] = Part.PlayerOnKnight;
                xPlayerValue = gridX;
                yPlayerValue = gridY;
                playerCount++;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void AddPlayerOnRook(int gridX, int gridY)                                       //Feature 9 Add Player On Rook
        {
            if (gridX >= 0 && gridX < _height && gridY >= 0 && gridY < _width)
            {
                _level[gridX, gridY] = Part.PlayerOnRook;
                xPlayerValue = gridX;
                yPlayerValue = gridY;
                playerCount++;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void AddRook(int gridX, int gridY)                                               //Feature 10 Add Rook
        {
            if (gridX >= 0 && gridX < _height && gridY >= 0 && gridY < _width)
            {
                _level[gridX, gridY] = Part.Rook;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public bool CheckValid()                                                                //Feature 15 Level is Valid
        {
            validLevel = true;
            if (_height == 0 && _width == 0)
            {
                validLevel = false;
                throw new Exception("Level generation failed");
            }
            else if (_height < 3 && _width < 3)
            {
                validLevel = false;
                throw new Exception("Incorrect Level Size! Too Small");
            }
            else if (_height > 10 && _width > 10)
            {
                validLevel = false;
                throw new Exception("Incorrect Level Size! Too Large");
            }
            else if (_height == 5 && _width != _height) 
            { 
                validLevel = false;
                throw new Exception("Incorrect Level Size! Not the same Height and Width"); 
            }
            return validLevel;

        }

        public void CreateLevel(int width, int height)                                          //Feature 1 Create Level
        {
            _height = height;
            _width = width;
            _level = new Part[_height, _width];
            levelsMade++;

            for (int x = 0; x < _height; x++)
            {
                for (int y = 0; y < _width; y++)
                {
                    _level[x, y] = Part.Empty;
                }
            }
            goalX = GetRowCount();
            goalY = GetColumnCount();
            totalNumOfGoals++;
        }



        public void SaveMe()                                                                    //Feature 18 Save Level
        {
            ISaver saver = new Saver();
            saver.Save(_currentLevel.Name, _currentLevel);
        }

        public void LoadMe()                                                                    //Feature 19 Load Level
        {
            throw new NotImplementedException();
        }

        public int GetPlayerX()                                                                 //Feature 17 Return Player X Location
        {

            return (xPlayerValue);
        }

        public int GetPlayerY()                                                                 //Feature 14 Return Player Y Location
        {

            return (yPlayerValue);
        }

        public Part WhatsAt(int row, int column)
        {
            try
            {
                return ((Part)_level[row, column]);
            }
            catch
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public int GetColumnCount()
        {
            _height = _level.GetLength(0);
            return _height;
        }

        public int GetRowCount()
        {
            _width = _level.GetLength(1);
            return _width;
        }


        // TODO - The ones below are the ones we don't want to keep technically. They need to call from the other one... call? push? I can't remember

        public int GetLevelWidth()
        {
            _width = _level.GetLength(1);
            return _width;
        }

        public int GetLevelHeight()
        {
            _height = _level.GetLength(0);
            return _height;
        }

        public Part GetPartAtIndex(int gridX, int gridY)
        {
            try
            {
                return ((Part)_level[gridX, gridY]);
            }
            catch
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
