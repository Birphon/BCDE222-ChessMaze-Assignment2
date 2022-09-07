using LevelDesigner;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass]
    public class LevelTest
    {
        LevelDesigner.Level levelDesigner = new LevelDesigner.Level();

        [TestMethod]
        public void AddBishop_ExpectedBishop()                              //F2 test 1
        {
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddBishop(1, 1);
            Part actualPart = levelDesigner.GetPartAtIndex(1, 1);
            Part expectedPart = Part.Bishop;
            Assert.AreEqual(expectedPart, actualPart);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddBishop_ExpectedThrowError()                          //F2 test 2
        {
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddBishop(11, 11);
        }

        [TestMethod]
        public void AddEmpty_ExpectedEmpty()                                //F3 test 1
        {
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddKnight(1, 1);
            levelDesigner.AddEmpty(1, 1);
            Part actualPart = levelDesigner.GetPartAtIndex(1, 1);
            Part expectedPart = Part.Empty;
            Assert.AreEqual(expectedPart, actualPart);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddEmpty_ExpectedThrowError()                           //F3 test 2
        {
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddEmpty(11, 11);
        }

        [TestMethod]
        public void AddKing_ExpectedKing()                                  //F4 test 1
        {
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddKing(1, 1);
            Part actualPart = levelDesigner.GetPartAtIndex(1, 1);
            Part expectedPart = Part.King;
            Assert.AreEqual(expectedPart, actualPart);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddKing_ExpectedThrowError()                            //F4 test 2
        {
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddKing(11, 11);
        }

        [TestMethod]
        public void AddPlayerOnBishop_ExpectedPlayerOnBishop()              //F5 test 1
        {
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddPlayerOnBishop(1, 1);
            Part actualPart = levelDesigner.GetPartAtIndex(1, 1);
            Part expectedPart = Part.PlayerOnBishop;
            Assert.AreEqual(expectedPart, actualPart);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddPlayerOnBishop_ExpectedThrowError()                  //F5 test 2
        {
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddPlayerOnBishop(11, 11);
        }

        [TestMethod]
        public void AddPlayerOnEmpty_ExpectedPlayerOnEmpty()                //F6 test 1
        {
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddPlayerOnKnight(1, 1);
            levelDesigner.AddPlayerOnEmpty(1, 1);
            Part actualPart = levelDesigner.GetPartAtIndex(1, 1);
            Part expectedPart = Part.PlayerOnEmpty;
            Assert.AreEqual(expectedPart, actualPart);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddPlayerOnEmpty_ExpectedThrowError()                   //F6 test 2
        {
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddPlayerOnEmpty(11, 11);
        }

        [TestMethod]
        public void AddPlayerOnKing_ExpectedPlayerOnKing()                  //F7 test 1
        {
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddPlayerOnKing(1, 1);
            Part actualPart = levelDesigner.GetPartAtIndex(1, 1);
            Part expectedPart = Part.PlayerOnKing;
            Assert.AreEqual(expectedPart, actualPart);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddPlayerOnKing_ExpectedThrowError()                    //F7 test 2
        {
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddPlayerOnBishop(11, 11);
        }


        [TestMethod]
        public void AddPlayerOnKnight_ExpectedPlayerOnKnight()              //F8 test 1
        {
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddPlayerOnKnight(1, 1);
            Part actualPart = levelDesigner.GetPartAtIndex(1, 1);
            Part expectedPart = Part.PlayerOnKnight;
            Assert.AreEqual(expectedPart, actualPart);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddPlayerOnKnight_ExpectedThrowError()                  //F8 test 2
        {
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddPlayerOnKnight(11, 11);
        }

        [TestMethod]
        public void AddPlayerOnRook_ExpectedPlayerOnRook()                  //F9 test 1
        {
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddPlayerOnRook(1, 1);
            Part actualPart = levelDesigner.GetPartAtIndex(1, 1);
            Part expectedPart = Part.PlayerOnRook;
            Assert.AreEqual(expectedPart, actualPart);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddPlayerOnRook_ExpectedThrowError()                    //F9 test 2
        {
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddPlayerOnRook(11, 11);
        }

        [TestMethod]
        public void AddRook_ExpectedRook()                                //F10 test 1
        {
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddRook(1, 1);
            Part actualPart = levelDesigner.GetPartAtIndex(1, 1);
            Part expectedPart = Part.Rook;
            Assert.AreEqual(expectedPart, actualPart);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddRook_ExpectedThrowError()                          //F10 test 2
        {
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddRook(11, 11);
        }

        [TestMethod]
        public void AddKnight_ExpectedKnight()                              //F11 test 1
        {
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddKnight(1, 1);
            Part actualPart = levelDesigner.GetPartAtIndex(1, 1);
            Part expectedPart = Part.Knight;
            Assert.AreEqual(expectedPart, actualPart);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddKnight_ExpectedThrowError()                          //F11 test 2
        {
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddKnight(11, 11);
        }

        [TestMethod]
        public void GetLevelWidth_Expected4()                               //F12 test 1
        {
            levelDesigner.CreateLevel(3, 4);
            int expectedWidth = 3;
            int actualWidth = levelDesigner.GetLevelWidth();
            Assert.AreEqual(expectedWidth, actualWidth);
        }

        [TestMethod]
        public void GetLevelWidth_Expected100()                             //F12 test 2
        {
            levelDesigner.CreateLevel(100, 4);
            int expectedWidth = 100;
            int actualWidth = levelDesigner.GetLevelWidth();
            Assert.AreEqual(expectedWidth, actualWidth);
        }

        [TestMethod]
        public void GetLevelHeight_Expected3()                              //F13 test 1
        {
            levelDesigner.CreateLevel(3, 4);
            int expectedHeight = 4;
            int actualHeight = levelDesigner.GetLevelHeight();
            Assert.AreEqual(expectedHeight, actualHeight);
        }

        [TestMethod]
        public void GetLevelHeight_Expected100()                            //F13 test 2
        {
            levelDesigner.CreateLevel(3, 100);
            int expectedHeight = 100;
            int actualHeight = levelDesigner.GetLevelHeight();
            Assert.AreEqual(expectedHeight, actualHeight);
        }

        [TestMethod]
        public void GetPlayerY_Expected1()                                  //F14 test 1
        {
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddPlayerOnKnight(0, 1);
            int actualY = levelDesigner.GetPlayerY();
            int expectedY = 1;
            Assert.AreEqual(expectedY, actualY);
        }

        [TestMethod]
        public void GetPlayerY_Expected9()                                  //F14 test 2
        {
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddPlayerOnKnight(0, 9);
            int expectedY = 9;
            int actualY = levelDesigner.GetPlayerY();
            Assert.AreEqual(expectedY, actualY);
        }

        [TestMethod]
        public void CheckValid_ExpectedTrue()                                //F15 test 1
        {
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddPlayerOnKing(0, 0);
            Boolean actualResult = levelDesigner.CheckValid();
            Boolean expectedResult = true;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CheckValid_ExpectedFalse()                              //F15 test 2
        {
            levelDesigner.CreateLevel(70, 70);
            Assert.ThrowsException<System.Exception>(() => levelDesigner.CheckValid());
        }

        [TestMethod]
        public void GetPartAtIndex_ExpectedEmpty()                          //F16 test 1
        {
            levelDesigner.CreateLevel(10, 10);
            Part actualPart = levelDesigner.GetPartAtIndex(1, 1);
            Part expectedPart = Part.Empty;
            Assert.AreEqual(expectedPart, actualPart);
        }

        [TestMethod]
        public void GetPartAtIndex_ExpectedKnight()                         //F16 test 2
        {
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddKnight(1, 1);
            Part actualPart = levelDesigner.GetPartAtIndex(1, 1);
            Part expectedPart = Part.Knight;
            Assert.AreEqual(expectedPart, actualPart);
        }

        [TestMethod]
        public void GetPartAtIndex_ExpectedBishop()                         //F16 test 3
        {
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddBishop(1, 1);
            Part actualPart = levelDesigner.GetPartAtIndex(1, 1);
            Part expectedPart = Part.Bishop;
            Assert.AreEqual(expectedPart, actualPart);
        }

        [TestMethod]
        public void GetPartAtIndex_ExpectedKing()                           //F16 test 4
        {
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddKing(1, 1);
            Part actualPart = levelDesigner.GetPartAtIndex(1, 1);
            Part expectedPart = Part.King;
            Assert.AreEqual(expectedPart, actualPart);
        }

        [TestMethod]
        public void GetPlayerX_Expected0()                                  //F17 test 1
        {
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddPlayerOnKnight(0, 1);
            int actualX = levelDesigner.GetPlayerX();
            int expectedX = 0;
            Assert.AreEqual(expectedX, actualX);
        }

        [TestMethod]
        public void GetPlayerX_Expected9()                                  //F17 test 2
        {
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddPlayerOnKnight(9, 1);
            int expectedX = 9;
            int actualX = levelDesigner.GetPlayerX();
            Assert.AreEqual(expectedX, actualX);
        }
    }
}
