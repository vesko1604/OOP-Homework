using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGameEngine
{
    public class Frost_Archer : Hero
    {
        private int hitCount;
        private int mana;
        private int frostShieldCooldown;
        public Frost_Archer() : this("Raiko Coldblade")
        {
        }

        public Frost_Archer(string name) : base(name)
        {
            hitCount = 0;
            mana = 100; // Initialize with full mana
            frostShieldCooldown = 0; // Initialize frost shield cooldown
        }

        public override int Attack()
        {
            int baseAttack = base.Attack();
            mana += Random.Shared.Next(10, 20); // Regenerate some mana with each attack

            if (mana >= 40)
            {
                mana -= 40;
                Console.WriteLine($"{Name} shoots Frost Arrow!");
                baseAttack += Strength * 2; // Frost Arrow attack consuming mana
            }

            return baseAttack;
        }

        public override void TakeDamage(int incomingDamage)
        {
            int healthThreshold = Random.Shared.Next(0, 100);

            if (frostShieldCooldown == 0 && healthThreshold <= 30)
            {
                incomingDamage = 0;
                frostShieldCooldown = 4; // Frost shield ability with cooldown
                Console.WriteLine($"{Name} activates Frost Shield and blocks the attack!");
            }
            else
            {
                base.TakeDamage(incomingDamage);
            }

            if (frostShieldCooldown > 0)
            {
                frostShieldCooldown--; // Decrease cooldown each turn
            }
        }

        public void CastBlizzard()
        {
            if (mana >= 60)
            {
                mana -= 60;
                Console.WriteLine($"{Name} casts Blizzard, freezing enemies in the area!");
                // Implement the area freezing effect in the game logic
            }
            else
            {
                Console.WriteLine($"{Name} doesn't have enough mana to cast Blizzard.");
            }
        }
    }
}
