using UnityEngine;

namespace UnityCombat.Effects {
    public abstract class CombatEffect : ScriptableObject {
        public abstract void Revert(ICombatant combatant);
        public abstract void Apply(ICombatant combatant);
    }
}