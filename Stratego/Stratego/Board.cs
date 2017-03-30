using Stratego.Pieces;
using System.Collections.Generic;

namespace Stratego
{
    public class Board
    {
        public Board()
        {
            isFinish = false;
            boardSpace = new Dictionary<Square, Piece>();
            InitializeLakes();
        }

        public Gamer Winner
        {
           get { return winner; }
        }

        public bool IsFinish { get { return isFinish; } }

        public Dictionary<Square, Piece> BoardSpace { get { return boardSpace; } }

        private void InitializeLakes()
        {
            Piece lake = new Lake();
            boardSpace.Add(new Square(3, 5), lake);
            boardSpace.Add(new Square(4, 5), lake);
            boardSpace.Add(new Square(7, 5), lake);
            boardSpace.Add(new Square(8, 5), lake);

            boardSpace.Add(new Square(3, 6), lake);
            boardSpace.Add(new Square(4, 6), lake);
            boardSpace.Add(new Square(7, 6), lake);
            boardSpace.Add(new Square(8, 6), lake);
        }

        public bool SetPiece(Square square, Piece piece)
        {
            if (boardSpace.Count < boardSize)
            {
                boardSpace.Add(square, piece);
                return true;
            }
            return false;
        }

        public void MovePiece(Square current, Square nextStep)
        {
            Piece currentPiece = boardSpace[current];
            if (currentPiece.MoveAt(current, nextStep, boardSpace))
            {
                boardSpace[nextStep] = boardSpace[current];
                boardSpace[current] = null;
            }
        }

        public void AttackPiece(Square current, Square next)
        {
            Piece attacker = boardSpace[current];
            Piece attacked = boardSpace[next];

            AttackResult result = attacker.Attack(attacked);
            switch (result)
            {
                case (AttackResult.Win):
                    boardSpace[next].Owner.LosePiece(attacked);
                    VerifyGameIsFinish(attacker, attacked);
                    boardSpace[next] = attacker;
                    boardSpace[current] = null;
                    break;
                case AttackResult.Draw:
                    boardSpace[current].Owner.LosePiece(attacked);
                    boardSpace[next].Owner.LosePiece(attacked);
                    VerifyGameIsFinish(attacker, attacked);
                    boardSpace[current] = null;
                    boardSpace[next] = null;
                    break;
                case AttackResult.Lose:
                    boardSpace[next].Owner.LosePiece(attacked);
                    boardSpace[current] = null; 
                    VerifyGameIsFinish(attacker, attacked);
                    break;
            }
        }

        private void VerifyGameIsFinish(Piece attacker, Piece attacked)
        {
            if (attacked is Flag)
            {
                isFinish = true;
                winner = attacker.Owner;
            }
            else
            {
                AnalizeSquares(attacker.Owner, attacked.Owner);
            }
        }

        private bool AnalizeSquares(Gamer attacker, Gamer attacked)
        {
            if(!attacker.ContainsPieces && !attacked.ContainsPieces)
            {
                winner = new Gamer("draw");
                return true;
            }
            return false;
        }

        private bool isFinish;
        private Gamer winner;
        private Dictionary<Square, Piece> boardSpace;
        private const int boardSize = 100;
    }
}
