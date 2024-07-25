using UnityEngine;
using UnityEngine.UI;

namespace TrafficSystem.UI
{
    public class SignalInfoWidget : MonoBehaviour
    {
        private const string CAN_DRIVE = "Can drive";
        private const string CAN_T_DRIVE = "Can't drive";

        [SerializeField] private Text signalInfoText;
        [SerializeField] private Text canDriveText;

        public SignalInfoConfig signalInfoConfig;
        public CrossroadChecker crossroadChecker;

        private TrafficLight actualTrafficLight;

        private void Awake()
        {
            signalInfoText.text = string.Empty;
            canDriveText.text = string.Empty;
        }

        private void Start()
        {
            crossroadChecker.OnCrossroadEnter += OnCrossroadEnter;
            crossroadChecker.OnCrossroadExit += OnCrossroadExit;
        }

        private void OnDestroy()
        {
            crossroadChecker.OnCrossroadEnter -= OnCrossroadEnter;
            crossroadChecker.OnCrossroadExit -= OnCrossroadExit;
        }

        private void OnCrossroadEnter()
        {
            actualTrafficLight = crossroadChecker.ActualCrossroad.GetTrafficLightByDirection(crossroadChecker.transform.forward);

            if (!actualTrafficLight) return;

            UpdateSignalInfo(actualTrafficLight.CurrentState);

            actualTrafficLight.OnStateChanged += UpdateSignalInfo;
        }

        private void UpdateSignalInfo(TrafficLightState state)
        {
            var description = signalInfoConfig.GetDescriptionByState(state);
            signalInfoText.text = description;
            canDriveText.text = string.Empty;
        }

        private void OnCrossroadExit()
        {
            if (!actualTrafficLight) return;

            actualTrafficLight.OnStateChanged -= UpdateSignalInfo;
            signalInfoText.text = string.Empty;
            canDriveText.text = string.Empty;
        }

        public void UpdateCanDriveStatus()
        {
            if (!actualTrafficLight) return;

            if (signalInfoConfig.CanDriveByState(actualTrafficLight.CurrentState))
            {
                canDriveText.color = Color.green;
                canDriveText.text = CAN_DRIVE;
            }
            else
            {
                canDriveText.color = Color.red;
                canDriveText.text = CAN_T_DRIVE;
            }
        }
    }
}