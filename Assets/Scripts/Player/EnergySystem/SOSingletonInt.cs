using UnityEngine;

namespace Player.EnergySystem {
    [CreateAssetMenu(fileName = "new Singleton Integer", menuName = "Singletons/Integer", order = 0)]
    public class SOSingletonInt : ScriptableObject {
        public int Value;
    }
}