using System;
using System.Collections;
using UnityCombat.Effects;
using UnityEngine;
using UnityUtilities;
using UnityUtilities.Misc;

namespace UnityCombat.Skills {
    public class Hitbox2DAttack : AbstractHitbox2DAttack {
        public uint Frames;
        public bool StopOnHit = true;

        protected override void ExecuteAttack(ICombatant combatant, uint damage, float multiplier) {
            combatant.StartCoroutine(DoRepeatedAttack(combatant, damage));
        }

        private IEnumerator DoRepeatedAttack(ICombatant combatant, uint damage) {
            for (uint i = 0; i < Frames; i++) {
                if (ExecuteHitbox(combatant, damage) && StopOnHit) {
                    yield break;
                }

                yield return null;
            }
        }
    }

    public abstract class AbstractHitbox2DAttack : Attack {
        public Bounds2D Hitbox;
        public LayerMask HitboxMask;
        public DamageEffect Effect;
        public bool SingleEntity;

        protected bool ExecuteHitbox(ICombatant combatant, uint damage) {
            var hb = Hitbox;
            var xDir = Math.Sign(combatant.FacingDirection.x);
            if (xDir != 0) {
                hb.Center.x *= xDir;
            }

            hb.Center += (Vector2) combatant.Transform.position;
            var s = combatant as IGizmosSchedulable;
            if (s != null) {
                s.ScheduleGizmos(() => DebugUtil.DrawBounds2D(hb, Color.green));
            }

            var success = false;
            var found = Physics2D.OverlapBoxAll(hb.Center, hb.Size, 0, HitboxMask);

            foreach (var hit in found) {
                var e = hit.GetComponentInParent<ICombatant>();
                if (e != null && e.Ignored) {
                    continue;
                }

                if (e == null || e == combatant || !e.CanAttack(combatant)) {
                    continue;
                }

                Effect.Apply(e);
                success = true;
                if (!SingleEntity) {
                    continue;
                }

                return true;
            }

            return success;
        }
    }
}