using UnityEngine;

namespace UnityCombat.Effects {
    public class StatusEffect : CombatEffect {
        [SerializeField]
        private float duration;

        public float Duration {
            get {
                return duration;
            }
        }

        public virtual float GetDamageGivenMultiplier() {
            return 1;
        }

        public virtual float GetDamageTakenMultiplier() {
            return 1;
        }


        public override void Revert(ICombatant combatant) {
            combatant.StopStatusEffect(this);
        }

        public override void Apply(ICombatant combatant) {
            combatant.StartStatusEffect(this);
        }
    }
}