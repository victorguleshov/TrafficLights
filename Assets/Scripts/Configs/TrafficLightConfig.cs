using UnityEngine;

namespace TrafficSystem
{
    [CreateAssetMenu(fileName = "TrafficLightConfig", menuName = "TrafficSystem/TrafficLightConfig")]
    public class TrafficLightConfig : ScriptableObject
    {
        [SerializeField] private float redAmberDuration = 1f;
        [SerializeField] private float amberDuration = 2f;
        [SerializeField] private float greenDuration = 3f;
        
        public float RedAmberDuration => redAmberDuration;
        public float AmberDuration => amberDuration;
        public float GreenDuration => greenDuration;
    }
}