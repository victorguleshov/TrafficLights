using System;
using UnityEngine;

namespace TrafficSystem
{
    public class CrossroadChecker : MonoBehaviour
    {
        public Crossroad ActualCrossroad { get; private set; }
        
        public event Action OnCrossroadEnter;
        public event Action OnCrossroadExit;

        private void OnTriggerEnter(Collider other)
        {
            var crossroad = other.GetComponent<Crossroad>();
            if (crossroad)
            {
                ActualCrossroad = crossroad;
                OnCrossroadEnter?.Invoke();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<Crossroad>())
            {
                ActualCrossroad = null;
                OnCrossroadExit?.Invoke();
            }
        }
    }
}