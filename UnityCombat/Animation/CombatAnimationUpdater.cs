using UnityEngine;

namespace UnityCombat.Animation {
    public abstract class CombatAnimationUpdater : MonoBehaviour {
        [SerializeField]
        private Animator animator;

        public Animator Animator {
            get {
                return animator;
            }
        }
    }
}