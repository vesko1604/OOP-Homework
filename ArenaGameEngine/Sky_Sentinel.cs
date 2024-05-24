using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGameEngine
{
    public class Sky_Sentinel : Hero
    {
        private int hitCount;
        private int shieldCooldown;
        private int mana;
        public Sky_Sentinel() : this("Orlin Silverhawk")
        {
        }

        public Sky_Sentinel(string name) : base(name)
        {
            hitCount = 0;
            shieldCooldown = 0;
            mana = 100; // New property to manage mana
        }

        public override int Attack()
        {
            int baseAttack = base.Attack();
            mana += Random.Shared.Next(10, 20); // Regenerate some mana with each attack
            if (mana >= 30)
            {
                mana -= 30;
                Console.WriteLine($"{Name} uses Thunder Strike!");
                baseAttack += Strength * 2; // Special attack that consumes mana
            }
            return baseAttack;
        }

        public override void TakeDamage(int incomingDamage)
        {
            int healthThreshold = Random.Shared.Next(0, 100);
            if (shieldCooldown == 0 && healthThreshold <= 20)
            {
                incomingDamage = 0;
                shieldCooldown = 3; // Shield ability with cooldown
                Console.WriteLine($"{Name} activates Shield Barrier and blocks the attack!");
            }
            else
            {
                base.TakeDamage(incomingDamage);
            }

            if (shieldCooldown > 0)
            {
                shieldCooldown--; // Decrease cooldown each turn
            }
        }
    }
}
