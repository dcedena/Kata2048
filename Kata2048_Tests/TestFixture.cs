using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Kata2048;
using Kata2048_Classes;
using NUnit.Framework;

namespace Kata2048_Tests
{
    [TestFixture]
    public class TestFixture1
    {
        private GameBoard board = null;

        [Test]
        public void Test_CreateBoard()
        {
            board = new GameBoard(4, 4);

            board.Reset();
        }

        [Test]
        public void Test_PrintBoard()
        {
            board = new GameBoard(4, 4);
            board.Print();
        }

        [Test]
        public void Test_PrintBoard_Initialized()
        {
            board = new GameBoard(4, 4);
            board.Print();
            board.Initialize();
            board.Print();
       
        }

        [Test]
        public void Test_CreateBoard_Initialized_MoveTOP_IsMoved()
        {
            board = new GameBoard(Boards.BOARD_01);
            board.Print();
            bool isMovedTo = true;
            
            isMovedTo = board.MoveToTop();
            Debug.WriteLine("IsMoved: " + (isMovedTo ? "TRUE" : "FALSE"));
            board.Print();

            Assert.IsTrue(isMovedTo);
        }

        [Test]
        public void Test_CreateBoard_Initialized_MoveRIGHT_IsMoved()
        {
            board = new GameBoard(Boards.BOARD_01);
            board.Print();
            bool isMovedTo = true;

            isMovedTo = board.MoveToRight();
            Debug.WriteLine("IsMoved: " + (isMovedTo ? "TRUE" : "FALSE"));
            board.Print();

            Assert.IsTrue(isMovedTo);
        }

        [Test]
        public void Test_CreateBoard_Initialized_MoveBOTTOM_IsMoved()
        {
            board = new GameBoard(Boards.BOARD_01);
            board.Print();
            bool isMovedTo = true;

            isMovedTo = board.MoveToBottom();
            Debug.WriteLine("IsMoved: " + (isMovedTo ? "TRUE" : "FALSE"));
            board.Print();

            Assert.IsTrue(isMovedTo);
        }

        [Test]
        public void Test_CreateBoard_Initialized_MoveLEFT_IsMoved()
        {
            board = new GameBoard(Boards.BOARD_01);
            board.Print();
            bool isMovedTo = true;

            isMovedTo = board.MoveToLeft();
            Debug.WriteLine("IsMoved: " + (isMovedTo ? "TRUE" : "FALSE"));
            board.Print();

            Assert.IsTrue(isMovedTo);
        }


        [Test]
        public void Test_CreateBoard_Initialized_MoveTOP_NoMoved()
        {
            board = new GameBoard(Boards.BOARD_02_NO_MOVE_TOP);
            board.Print();
            bool isMovedTo = true;

            isMovedTo = board.MoveToTop();
            Debug.WriteLine("IsMoved: " + (isMovedTo ? "TRUE" : "FALSE"));
            board.Print();

            Assert.IsFalse(isMovedTo);
        }

        [Test]
        public void Test_CreateBoard_Initialized_MoveRIGHT_NoMoved()
        {
            board = new GameBoard(Boards.BOARD_02_NO_MOVE_RIGHT);
            board.Print();
            bool isMovedTo = true;

            isMovedTo = board.MoveToRight();
            Debug.WriteLine("IsMoved: " + (isMovedTo ? "TRUE" : "FALSE"));
            board.Print();

            Assert.IsFalse(isMovedTo);
        }

        [Test]
        public void Test_CreateBoard_Initialized_MoveBOTTOM_NoMoved()
        {
            board = new GameBoard(Boards.BOARD_02_NO_MOVE_BOTTOM);
            board.Print();
            bool isMovedTo = true;

            isMovedTo = board.MoveToBottom();
            Debug.WriteLine("IsMoved: " + (isMovedTo ? "TRUE" : "FALSE"));
            board.Print();

            Assert.IsFalse(isMovedTo);
        }

        [Test]
        public void Test_CreateBoard_Initialized_MoveLEFT_NoMoved()
        {
            board = new GameBoard(Boards.BOARD_02_NO_MOVE_LEFT);
            board.Print();
            bool isMovedTo = true;

            isMovedTo = board.MoveToLeft();
            Debug.WriteLine("IsMoved: " + (isMovedTo ? "TRUE" : "FALSE"));
            board.Print();

            Assert.IsFalse(isMovedTo);
        }

        [Test]
        public void Test_CreateBoard_MoveTop_AcumToTop()
        {
            board = new GameBoard(Boards.BOARD_01_MOVE_WITH_ACUMULATE);
            board.Print();
            bool isMovedTo = true;

            isMovedTo = board.MoveToTop();
            Debug.WriteLine("IsMoved: " + (isMovedTo ? "TRUE" : "FALSE"));
            board.Print();
        }

        [Test]
        public void Test_CreateBoard_MoveRight_AcumToRight()
        {
            board = new GameBoard(Boards.BOARD_01_MOVE_WITH_ACUMULATE);
            board.Print();
            bool isMovedTo = true;

            isMovedTo = board.MoveToRight();
            Debug.WriteLine("IsMoved: " + (isMovedTo ? "TRUE" : "FALSE"));
            board.Print();
        }

        [Test]
        public void Test_CreateBoard_MoveBottom_AcumToBottom()
        {
            board = new GameBoard(Boards.BOARD_01_MOVE_WITH_ACUMULATE);
            board.Print();
            bool isMovedTo = true;

            isMovedTo = board.MoveToBottom();
            Debug.WriteLine("IsMoved: " + (isMovedTo ? "TRUE" : "FALSE"));
            board.Print();
        }

        [Test]
        public void Test_CreateBoard_MoveLeft_AcumToLeft()
        {
            board = new GameBoard(Boards.BOARD_01_MOVE_WITH_ACUMULATE);
            board.Print();
            bool isMovedTo = true;

            isMovedTo = board.MoveToLeft();
            Debug.WriteLine("IsMoved: " + (isMovedTo ? "TRUE" : "FALSE"));
            board.Print();
        }
    }
}