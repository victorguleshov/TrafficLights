using UnityEngine;

namespace TrafficSystem
{
    public class Crossroad : MonoBehaviour
    {
        [SerializeField] private TrafficLight[] trafficLights;
        [SerializeField] private TrafficLight firstTrafficLight;

        private void Start()
        {
            foreach (var trafficLight in trafficLights)
            {
                if (trafficLight == firstTrafficLight)
                {
                    trafficLight.CurrentState = TrafficLightState.Green;
                    trafficLight.StartCycle();
                }
                else
                {
                    trafficLight.CurrentState = TrafficLightState.Red;
                }
            }
        }
    }
}