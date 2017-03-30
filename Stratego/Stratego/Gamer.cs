using System.Collections.Generic;

namespace Stratego
{
    public class Gamer
    {
        private bool containsPieces;
        private string nickname;
        private int lowerLimitY;
        private int upperLimitY;
        private Dictionary<string, int> pieces;

        public Gamer(string v)
        {
            this.nickname = v;
            containsPieces = false;
            pieces = new Dictionary<string, int>();
            pieces.Add("Stratego.Pieces.Bomb", 0);
            pieces.Add("Stratego.Pieces.Marshal", 0);
            pieces.Add("Stratego.Pieces.General", 0);
            pieces.Add("Stratego.Pieces.Coronel", 0);
            pieces.Add("Stratego.Pieces.Major", 0);
            pieces.Add("Stratego.Pieces.Captain", 0);
            pieces.Add("Stratego.Pieces.Lieutentaium", 0);
            pieces.Add("Stratego.Pieces.Sergeant", 0);
            pieces.Add("Stratego.Pieces.Miner", 0);
            pieces.Add("Stratego.Pieces.Scout", 0);
            pieces.Add("Stratego.Pieces.Spy", 0);
            pieces.Add("Stratego.Pieces.Flag", 0);
        }

        public bool Put(Piece piece)
        {
            string pieceName = piece.ToString();
            int value = pieces[pieceName] + 1;
            if (value <= piece.MaximumQuantity)
            {
                pieces[pieceName] = value;
                return true;
            }
            return false;
        }

        public void LosePiece(Piece piece)
        {
            string pieceName = piece.ToString();
            int pieceQuantity = pieces[pieceName] - 1;
            if (pieceQuantity >= 0)
            {
                pieces[pieceName] = pieceQuantity;
            }
            else
            {
                pieces.Remove(pieceName);
                VerifyState();
            }
        }

        public Dictionary<string, int> Pieces
        {
            get { return pieces; }
        }

        public bool ContainsPieces
        {
            get { return containsPieces;  }
        }

        public override bool Equals(object obj)
        {
            Gamer gamer = obj as Gamer;
            return this.nickname.Equals(gamer.nickname);
        }

        public override int GetHashCode()
        {
            return nickname.GetHashCode();
        }

        public int LowerLimitY
        {
            get { return lowerLimitY; }
            set { lowerLimitY = value; }
        }

        public int UpperLimitY
        {
            get { return upperLimitY; }
            set { upperLimitY = value; }
        }

        private void VerifyState()
        {
            containsPieces = (pieces.ContainsKey("Stratego.Pieces.Marshal") ||
            pieces.ContainsKey("Stratego.Pieces.General") ||
            pieces.ContainsKey("Stratego.Pieces.Coronel") ||
            pieces.ContainsKey("Stratego.Pieces.Major") ||
            pieces.ContainsKey("Stratego.Pieces.Captain") ||
            pieces.ContainsKey("Stratego.Pieces.Lieutentaium") ||
            pieces.ContainsKey("Stratego.Pieces.Sergeant") ||
            pieces.ContainsKey("Stratego.Pieces.Miner") ||
            pieces.ContainsKey("Stratego.Pieces.Scout") ||
            pieces.ContainsKey("Stratego.Pieces.Spy"));
        }

    }
}
