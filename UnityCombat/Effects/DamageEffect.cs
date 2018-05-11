using UnityEngine;

namespace UnityCombat.Effects {
    public sealed class DamageEffect : CombatEffect {
        [SerializeField]
        private uint damage;

        public string DamagedKey = UnityCombatConstants.DefaultDamagedKey;

        public uint Damage {
            get {
                return damage;
            }
        }

        public override void Revert(ICombatant combatant) {
            combatant.Health += Damage;
            combatant.AnimationUpdater.Trigger(DamagedKey);
        }

        public override void Apply(ICombatant combatant) {
            combatant.Health -= Damage;
        }
    }
}