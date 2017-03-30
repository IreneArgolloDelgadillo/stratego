using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stratego.Pieces;

namespace Stratego.Tests
{
    [TestClass]
    public class PieceTest
    {
        private Gamer juan;
        private Gamer juana;
        private Game game;
        private Board board;
        private Piece bomb;
        private Piece marshal;
        private Piece general;
        private Piece coronel;
        private Piece spy;
        private Piece captain;
        private Piece flag;
        private Piece lieutentaium;
        private Piece sergeant;
        private Piece miner;
        private Piece scout;
        private Piece major;

        [TestInitialize()]
        public void TestInitialize()
        {
            juan = new Gamer("Juan");
            juana = new Gamer("Juana");
            game = new Game();
            game.SetGamers(juan, juana);
            bomb = new Bomb(juan);
            marshal = new Marshal(juan);
            general = new General(juan);
            coronel = new Coronel(juan);
            spy = new Spy(juan);
            captain = new Captain(juan);
            flag = new Flag(juan);
            lieutentaium = new Lieutentaium(juan);
            sergeant = new Sergeant(juan);
            miner = new Miner(juan);
            scout = new Scout(juan);
            major = new Major(juan);
            board = game.GetBoard();
        }

        [TestMethod]
        public void TestMovimentRulesToScout()
        {
            Square current = new Square(2, 4);
            Square next = new Square(2, 7);

            board.SetPiece(current, scout);
            board.SetPiece(new Square(2, 5), null);
            board.SetPiece(new Square(2, 6), null);
            board.SetPiece(next, null);
            board.SetPiece(new Square(3, 8), null);
            board.MovePiece(current, next);
            Assert.AreEqual(scout, board.BoardSpace[next]);
            Assert.AreEqual(null, board.BoardSpace[current]);

            board.MovePiece(next, new Square(3, 8));
            Assert.AreEqual(scout, board.BoardSpace[next]);
            Assert.AreEqual(null, board.BoardSpace[new Square(3, 8)]);
        }

        [TestMethod]
        public void TestNoMoveScoutOnTopOfPieces()
        {
            Square current = new Square(2, 4);
            Square next = new Square(2, 7);

            board.SetPiece(new Square(2, 4), scout);
            board.SetPiece(new Square(2, 5), new Captain(juan));
            board.SetPiece(new Square(2, 6), null);
            board.SetPiece(new Square(2, 7), null);
            board.SetPiece(new Square(3, 4), new Coronel(juana));
            board.SetPiece(new Square(3, 8), null);

            board.MovePiece(new Square(2, 4), new Square(2, 7));
            Assert.AreEqual(scout, board.BoardSpace[current]);
            Assert.AreEqual(null, board.BoardSpace[next]);

            board.MovePiece(new Square(3, 4), new Square(3, 8));
            Assert.AreEqual(new Coronel(juana), board.BoardSpace[new Square(3, 4)]);
            Assert.AreEqual(null, board.BoardSpace[new Square(3, 8)]);
        }

        [TestMethod]
        public void TestMovimentRulesStepByStep()
        {
            Square current = new Square(2, 4);
            Square next = new Square(2, 5);
            board.SetPiece(current, miner);
            board.SetPiece(next, null);
            board.MovePiece(current, next);

            Assert.AreEqual(null, board.BoardSpace[current]);
            Assert.AreEqual(miner, board.BoardSpace[next]);

            current = new Square(8, 3);
            next = new Square(8, 4);
            board.SetPiece(new Square(8, 3), miner);
            board.SetPiece(new Square(8, 4), captain);
            board.SetPiece(new Square(3, 4), null);

            board.MovePiece(new Square(8, 3), new Square(8, 4));

            Assert.AreEqual(miner, board.BoardSpace[new Square(8, 3)]);
            Assert.AreEqual(captain, board.BoardSpace[new Square(8, 4)]);

            board.MovePiece(new Square(8, 4), new Square(3, 4));

            Assert.AreEqual(captain, board.BoardSpace[new Square(8, 4)]);
            Assert.AreEqual(null, board.BoardSpace[new Square(3, 4)]);

        }

        [TestMethod]
        public void TestMovimentRulesNoMove()
        {
            Square current = new Square(2, 4);
            Square next = new Square(2, 5);

            board.SetPiece(new Square(2, 4), flag);
            board.SetPiece(new Square(2, 5), null);
            board.SetPiece(new Square(3, 4), bomb);

            board.MovePiece(current, next);
            Assert.AreEqual(flag, board.BoardSpace[current]);
            Assert.AreEqual(null, board.BoardSpace[next]);

            board.MovePiece(new Square(3, 4), next);
            Assert.AreEqual(bomb, board.BoardSpace[new Square(3, 4)]);
            Assert.AreEqual(null, board.BoardSpace[next]);
        }
    }
}
