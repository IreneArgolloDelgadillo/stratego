namespace Stratego
{
    public class Game
    {
        
        public Game()
        {
            turnController = new TurnController();
            isFinished = false;
            board = new Board();
        }

        public Board GetBoard()
        {
            return board;
        }

        public bool SetGamers(Gamer gamerOne, Gamer gamerTwo)
        {
            if (!isFinished && !gamerOne.Equals(gamerTwo))
            {
                gamerOne.LowerLimitY = 1;
                gamerOne.UpperLimitY = 4;
                gamerTwo.LowerLimitY = 7;
                gamerTwo.UpperLimitY = 10;
                turnController.AddGamer(gamerOne);
                turnController.AddGamer(gamerTwo);
                return true;
            }
            return false;
        }

        public bool SetPieceOn(int x, int y, Piece piece)
        {
            if (turnController.Gamers.Contains(piece.Owner) && 
                ValidateCoordinates(y, x, piece.Owner)&&
                ValidatePieceQuantity(piece, piece.Owner))
            {
                return board.SetPiece(new Square(x, y), piece);
            }
            return false;
        }

        private bool ValidateCoordinates( int y, int x, Gamer gamer)
        {
            return x >= 1 && x <= 10 &&  y >= gamer.LowerLimitY && y <= gamer.UpperLimitY;
        }

        private bool ValidatePieceQuantity(Piece piece, Gamer gamer)
        {
            return gamer.Put(piece);
        }

        private bool isFinished;
        private TurnController turnController;
        private Board board;
        private const int lowerLimit = 1;
        private const int upperLimitX = 10;
    }
}