using System.Collections.Generic;
using UnityCombat.Animation;
using UnityCombat.Skills;

namespace UnityCombat {
    public interface ICombatant {
        IList<DamageCause> LastDamageCauses {
            get;
        }

        CombatAnimationUpdater AnimationUpdater {
            get;
        }

        void Damage(DamageCause cause);
        void ExecuteSkill(ActiveSkill skill);
        void ExecuteSkill(string skillName);
    }
}