using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGameEngine
{
    public class Arena
    {
        private List<Hero> heroes;
        public GameEventListener EventListener { get; set; }

        public Arena(params Hero[] initialHeroes)
        {
            heroes = new List<Hero>(initialHeroes);
        }

        public Hero Battle()
        {
            while (heroes.Count > 1)
            {
                for (int i = 0; i < heroes.Count; i++)
                {
                    Hero attacker = heroes[i];
                    Hero defender = GetNextAliveHero(i);
                    if (defender == null) break;

                    int damage = attacker.Attack();
                    defender.TakeDamage(damage);

                    if (EventListener != null)
                    {
                        EventListener.GameRound(attacker, defender, damage);
                    }

                    if (defender.IsDead)
                    {
                        heroes.Remove(defender);
                    }
                }
            }

            return heroes.Count > 0 ? heroes[0] : null;
        }

        private Hero GetNextAliveHero(int currentIndex)
        {
            for (int i = currentIndex + 1; i < heroes.Count; i++)
            {
                if (!heroes[i].IsDead)
                {
                    return heroes[i];
                }
            }
            for (int i = 0; i < currentIndex; i++)
            {
                if (!heroes[i].IsDead)
                {
                    return heroes[i];
                }
            }
            return null;
        }
    }
}
