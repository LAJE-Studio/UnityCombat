using System.Collections;
using System.Collections.Generic;
using UnityCombat.Animation;
using UnityCombat.Effects;
using UnityCombat.Skills;
using UnityEngine;

namespace UnityCombat {
    public interface ICombatant {
        Transform Transform {
            get;
        }

        CombatAnimationUpdater AnimationUpdater {
            get;
        }

        uint Health {
            get;
            set;
        }

        uint MaxHealth {
            get;
            set;
        }


        IEnumerable<StatusEffect> GetActiveStatusEffects();

        Vector3 FacingDirection {
            get;
            set;
        }

        bool Ignored {
            get;
            set;
        }

        bool CanAttack(ICombatant combatant);
        void StartStatusEffect(StatusEffect effect, bool infinite = false);
        void StopStatusEffect(StatusEffect effect);
        void ExecuteSkill(ActiveSkill skill);
        void ExecuteSkill(string skillName);
        void StartCoroutine(IEnumerator enumerator);
        void StopCoroutine(Coroutine coroutine);
    }
}