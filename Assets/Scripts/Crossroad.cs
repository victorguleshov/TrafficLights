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

        public TrafficLight GetTrafficLightByDirection(Vector3 characterForward)
        {
            var minDotProduct = 1f;
            TrafficLight result = null;
            
            foreach (var trafficLight in trafficLights)
            {
                var dotProduct = Vector3.Dot(trafficLight.transform.forward, characterForward);
                if (dotProduct < minDotProduct && dotProduct < -0.5f)
                {
                    minDotProduct = dotProduct;
                    result = trafficLight;
                }
            }
            
            return result;
        }
    }
}