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
        Green = 1 << 2
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
                if (currentState == value) return;

                currentState = value;
                SetLights(value);

                OnStateChanged?.Invoke(value);
            }
        }

        public event Action<TrafficLightState> OnStateChanged;

        public void ToGreen()
        {
            CurrentState = TrafficLightState.Red | TrafficLightState.Yellow;
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
                    case TrafficLightState.Red | TrafficLightState.Yellow:
                        yield return new WaitForSeconds(config.RedAmberDuration);
                        CurrentState = TrafficLightState.Green;
                        break;
                    case TrafficLightState.Green:
                        yield return new WaitForSeconds(config.GreenDuration);
                        CurrentState = TrafficLightState.Yellow;
                        break;
                    case TrafficLightState.Yellow:
                        yield return new WaitForSeconds(config.AmberDuration);
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