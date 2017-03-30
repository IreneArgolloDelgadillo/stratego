using System.Collections.Generic;

namespace Stratego
{
    public class TurnController
    {
        private Queue<Gamer> gamers;

        public TurnController()
        {
            gamers = new Queue<Gamer>();
        }

        public Gamer Next()
        {
            Gamer result = gamers.Dequeue();
            gamers.Enqueue(result);
            return result;
        }

        public bool AddGamer(Gamer gamer)
        {
            if (gamers.Contains(gamer))
            {
                return false;
            }
            else
            {
                gamers.Enqueue(gamer);
                return true;
            }
        }
        
        public Queue<Gamer> Gamers
        {
            get { return gamers; }
            private set { gamers = value; }
        }
    }
}
