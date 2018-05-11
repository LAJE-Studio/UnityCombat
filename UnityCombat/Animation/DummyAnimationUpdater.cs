using UnityEngine;

namespace UnityCombat.Animation {
    public class DummyAnimationUpdater : CombatAnimationUpdater {
        public bool Log;

        public override void Trigger(string key) {
            if (Log) {
                Debug.LogFormat("Trigger '{0}' activated", key);
            }
        }

        public override void SetBoolean(string key, bool value) {
            if (Log) {
                Debug.LogFormat("Boolean '{0}' set to {1} @ {2}", name, key, value);
            }
        }

        public override void SetFloat(string key, float value) {
            if (Log) {
                Debug.LogFormat("Float '{0}' set to {1} @ {2}", name, key, value);
            }
        }

        public override void SetInt(string key, int value) {
            if (Log) {
                Debug.LogFormat("Integer '{0}' set to {1} @ {2}", name, key, value);
            }
        }
    }
}