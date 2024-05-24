using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGameEngine
{
    public class Fire_Sorcerer : Hero
    {
        private int hitCount;
        private int mana;
        private int fireShieldCooldown;
        public Fire_Sorcerer() : this("Kael Emberstorm")
        {
        }

        public Fire_Sorcerer(string name) : base(name)
        {
            hitCount = 0;
            mana = 100; // Initialize with full mana
            fireShieldCooldown = 0; // Initialize fire shield cooldown
        }

        public override int Attack()
        {
            int baseAttack = base.Attack();
            mana += Random.Shared.Next(10, 20); // Regenerate some mana with each attack

            if (mana >= 40)
            {
                mana -= 40;
                Console.WriteLine($"{Name} casts Fireball!");
                baseAttack += Strength * 3; // Powerful fireball attack consuming mana
            }

            return baseAttack;
        }

        public override void TakeDamage(int incomingDamage)
        {
            int healthThreshold = Random.Shared.Next(0, 100);

            if (fireShieldCooldown == 0 && healthThreshold <= 30)
            {
                incomingDamage = 0;
                fireShieldCooldown = 4; // Fire shield ability with cooldown
                Console.WriteLine($"{Name} activates Fire Shield and negates the damage!");
            }
            else
            {
                base.TakeDamage(incomingDamage);
            }

            if (fireShieldCooldown > 0)
            {
                fireShieldCooldown--; // Decrease cooldown each turn
            }
        }

        public void CastFlameStrike()
        {
            if (mana >= 50)
            {
                mana -= 50;
                Console.WriteLine($"{Name} casts Flame Strike, dealing massive area damage!");
                // Implement the area damage effect in the game logic
            }
            else
            {
                Console.WriteLine($"{Name} doesn't have enough mana to cast Flame Strike.");
            }
        }
    }
}
