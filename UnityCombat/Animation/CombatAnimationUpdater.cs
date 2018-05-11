using UnityEngine;

namespace UnityCombat.Animation {
    public abstract class CombatAnimationUpdater : MonoBehaviour {
        public abstract void Trigger(string key);
        public abstract void SetBoolean(string key, bool value);
        public abstract void SetFloat(string key, float value);
        public abstract void SetInt(string key, int value);
    }
}