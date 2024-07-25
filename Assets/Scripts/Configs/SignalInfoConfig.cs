using System;
using UnityEngine;

namespace TrafficSystem
{
    [CreateAssetMenu(fileName = "SignalInfoConfig", menuName = "TrafficSystem/SignalInfoConfig")]
    public class SignalInfoConfig : ScriptableObject
    {
        [SerializeField] private SignalInfo[] signalDescriptions;

        public string GetDescriptionByState(TrafficLightState state)
        {
            foreach (var signalDescription in signalDescriptions)
            {
                if (signalDescription.state == state)
                {
                    return signalDescription.description;
                }
            }

            return string.Empty;
        }

        public bool CanDriveByState(TrafficLightState state)
        {
            foreach (var signalDescription in signalDescriptions)
            {
                if (signalDescription.state == state)
                {
                    return signalDescription.canDrive;
                }
            }

            return false;
        }
    }

    [Serializable] public class SignalInfo
    {
        public TrafficLightState state;
        [TextArea] public string description;
        public bool canDrive;
    }
}