using UnityEngine;

namespace UnityCombat.Skills {
    public abstract class Attack : ActiveSkill {
        [SerializeField]
        private uint baseDamage;

        public uint BaseDamage {
            get {
                return baseDamage;
            }
        }

        public override void Execute(ICombatant combatant) {
            float multiplier = 1;
            foreach (var effect in combatant.GetActiveStatusEffects()) {
                multiplier *= effect.GetDamageGivenMultiplier();
            }

            ExecuteAttack(combatant, (uint) (baseDamage * multiplier), multiplier);
        }

        protected abstract void ExecuteAttack(ICombatant combatant, uint damage, float multiplier);
    }
}