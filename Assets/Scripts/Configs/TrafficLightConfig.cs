using UnityEngine;

namespace TrafficSystem
{
    [CreateAssetMenu(fileName = "TrafficLightConfig", menuName = "TrafficSystem/TrafficLightConfig")]
    public class TrafficLightConfig : ScriptableObject
    {
        public float redAmberDuration = 1f;
        public float amberDuration = 2f;
        public float greenDuration = 3f;
    }
}