using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace TrafficSystem
{
    [Flags]
    public enum TrafficLightState
    {
        Red = 1 << 0,
        Yellow = 1 << 1,
        Green = 1 << 2,
        RedAmber = Red | Yellow
    }

    public class TrafficLight : MonoBehaviour
    {
        public TrafficLightConfig config;
        public GameObject redLight;
        public GameObject yellowLight;
        public GameObject greenLight;

        public UnityEvent onTurnRed;

        private TrafficLightState currentState;
        private Coroutine trafficLightCoroutine;
        public TrafficLightState CurrentState
        {
            get => currentState;
            set
            {
                currentState = value;
                SetLights(value);
            }
        }


        public void ToGreen()
        {
            CurrentState = TrafficLightState.RedAmber;
            StartCycle();
        }

        public void StartCycle()
        {
            if (trafficLightCoroutine != null) StopCoroutine(trafficLightCoroutine);
            trafficLightCoroutine = StartCoroutine(TrafficLightCycle());
        }

        private IEnumerator TrafficLightCycle()
        {
            while (true)
            {
                switch (CurrentState)
                {
                    case TrafficLightState.RedAmber:
                        yield return new WaitForSeconds(config.redAmberDuration);
                        CurrentState = TrafficLightState.Green;
                        break;
                    case TrafficLightState.Green:
                        yield return new WaitForSeconds(config.greenDuration);
                        CurrentState = TrafficLightState.Yellow;
                        break;
                    case TrafficLightState.Yellow:
                        yield return new WaitForSeconds(config.amberDuration);
                        CurrentState = TrafficLightState.Red;
                        break;
                    case TrafficLightState.Red:
                        onTurnRed.Invoke();
                        yield break;
                }
            }
        }

        private void SetLights(TrafficLightState state)
        {
            redLight.SetActive((state & TrafficLightState.Red) != 0);
            yellowLight.SetActive((state & TrafficLightState.Yellow) != 0);
            greenLight.SetActive((state & TrafficLightState.Green) != 0);
        }
    }
}