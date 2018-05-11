using UnityEngine;

namespace UnityCombat.Skills {
    public abstract class ActiveSkill : ScriptableObject {
        public abstract void Execute(ICombatant combatant);
    }
}