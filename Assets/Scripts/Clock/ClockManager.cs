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

        private void Update()
        {
            minutePivot.transform.Rotate(Vector3.up, Time.deltaTime * minuteSpeed);
            hourPivot.transform.Rotate(Vector3.up, Time.deltaTime * hourSpeed);
        }
    }
}