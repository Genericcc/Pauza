using System;

using UnityEngine;

namespace Clock
{
    public class ClockManager : MonoBehaviour
    {
        [SerializeField]
        public GameObject minutePivot;
        
        [SerializeField]
        public GameObject hourPivot;

        [SerializeField]
        private float minuteSpeed;
        
        [SerializeField]
        private float hourSpeed;

        [SerializeField]
        private bool counterClockwise;

        private void Update()
        {
            minutePivot.transform.Rotate(counterClockwise ? Vector3.forward : Vector3.back, Time.deltaTime * minuteSpeed);
            hourPivot.transform.Rotate(counterClockwise ? Vector3.forward : Vector3.back, Time.deltaTime * hourSpeed);
        }
    }
}