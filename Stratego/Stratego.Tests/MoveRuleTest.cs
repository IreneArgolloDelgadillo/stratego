using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stratego.Pieces;
using Stratego.Playrules.Move;

namespace Stratego.Tests
{
    [TestClass]
    public class MoveRuleTest
    {
        private IMovementRule rule;
        private Gamer sasi, cateto;
        private Board board;

        [TestInitialize()]
        public void MyTestInitialize()
        {
            board = new Board();
            sasi = new Gamer("sasi");
            cateto = new Gamer("cateto");
        }

        [TestMethod]
        public void TestCantMoveRule()
        {
            board = new Board();
            rule = new CantMove();

            board.SetPiece(new Square(4, 4), new Bomb(sasi));
            board.SetPiece(new Square(6, 5), null);
            board.SetPiece(new Square(8, 4), null);
            Assert.IsFalse(rule.AcceptCriterion(new Square(4, 4), new Square(6, 5), board.BoardSpace));

        }

        [TestMethod]
        public void TestMoveOnLake()
        {
            board = new Board();
            rule = new OccupiedSquare();

            board.SetPiece(new Square(3, 4), new Major(sasi));
            board.SetPiece(new Square(3, 7), new Miner(cateto));
            board.SetPiece(new Square(6, 4), new Coronel(sasi));
            board.SetPiece(new Square(6, 5), null);
            board.SetPiece(new Square(8, 7), new General(cateto));

            Assert.IsFalse(rule.AcceptCriterion(new Square(3, 4), new Square(3, 5), board.BoardSpace));
            Assert.IsFalse(rule.AcceptCriterion(new Square(3, 7), new Square(3, 6), board.BoardSpace));
            Assert.IsFalse(rule.AcceptCriterion(new Square(8, 7), new Square(8, 6), board.BoardSpace));
            Assert.IsTrue(rule.AcceptCriterion(new Square(6, 4), new Square(6, 5), board.BoardSpace));
        }

        [TestMethod]
        public void TestMoveOnBoard()
        {
            board = new Board();
            rule = new OccupiedSquare();

            board.SetPiece(new Square(5, 3), new Major(sasi));
            board.SetPiece(new Square(5, 4), new Scout(sasi));
            board.SetPiece(new Square(5, 2), new Bomb(sasi));
            board.SetPiece(new Square(1, 4), new Captain(sasi));
            board.SetPiece(new Square(1, 5), null);
            board.SetPiece(new Square(2, 5), new Captain(sasi));
            board.SetPiece(new Square(2, 6), new Sergeant(cateto));

            Assert.IsFalse(rule.AcceptCriterion(new Square(5, 3), new Square(5, 4), board.BoardSpace));
            Assert.IsFalse(rule.AcceptCriterion(new Square(5, 3), new Square(5, 2), board.BoardSpace));
            Assert.IsTrue(rule.AcceptCriterion(new Square(1, 4), new Square(1, 5), board.BoardSpace));
            Assert.IsFalse(rule.AcceptCriterion(new Square(2, 6), new Square(2, 5), board.BoardSpace));
        }



        [TestMethod()]
        public void TestMoveNextStep()
        {
            board = new Board();
            rule = new StepByStep();

            board.SetPiece(new Square(5, 3), new Major(sasi));
            board.SetPiece(new Square(6, 3), new Sergeant(sasi));
            board.SetPiece(new Square(7, 3), new Lieutentaium(sasi));
            board.SetPiece(new Square(5, 4), null);
            board.SetPiece(new Square(6, 4), null);
            board.SetPiece(new Square(7, 4), null);
            board.SetPiece(new Square(6, 2), null);

            Assert.IsTrue(rule.AcceptCriterion(new Square(5, 3), new Square(5, 4), board.BoardSpace));
            Assert.IsTrue(rule.AcceptCriterion(new Square(6, 3), new Square(6, 4), board.BoardSpace));
            Assert.IsTrue(rule.AcceptCriterion(new Square(7, 3), new Square(7, 4), board.BoardSpace));
            Assert.IsFalse(rule.AcceptCriterion(new Square(5, 3), new Square(7, 3), board.BoardSpace));
            Assert.IsFalse(rule.AcceptCriterion(new Square(6, 4), new Square(7, 3), board.BoardSpace));
            Assert.IsFalse(rule.AcceptCriterion(new Square(7, 3), new Square(6, 2), board.BoardSpace));
        }

        [TestMethod()]
        public void TestMoveOnManyStep()
        {
            board = new Board();
            rule = new ManyStepByStep();

            board.SetPiece(new Square(5, 3), new Scout(sasi));
            board.SetPiece(new Square(6, 3), null);
            board.SetPiece(new Square(7, 3), null);
            board.SetPiece(new Square(5, 4), null);
            board.SetPiece(new Square(5, 5), null);
            board.SetPiece(new Square(5, 6), null);
            board.SetPiece(new Square(5, 7), null);
            board.SetPiece(new Square(5, 8), null);
            board.SetPiece(new Square(5, 9), null);
            board.SetPiece(new Square(5, 10), null);
            board.SetPiece(new Square(8, 1), null);

            Assert.IsTrue(rule.AcceptCriterion(new Square(5, 3), new Square(7, 3), board.BoardSpace));
            Assert.IsTrue(rule.AcceptCriterion(new Square(5, 3), new Square(5, 10), board.BoardSpace));
            Assert.IsFalse(rule.AcceptCriterion(new Square(5, 10), new Square(8, 1), board.BoardSpace));
        }
    }
}
