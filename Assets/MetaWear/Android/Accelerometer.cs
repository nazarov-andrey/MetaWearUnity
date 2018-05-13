using UnityEngine;

namespace MetaWear.Android
{
    public class Accelerometer : IAccelerometer
    {
        private static string TAG = "Android.Accelerometer";

        class AcceleromenterHandler : AndroidJavaProxy
        {
            private IAccelerometerHandler handler;

            public AcceleromenterHandler (IAccelerometerHandler handler) : base (
                "de.horizont.metawearunity.IAccelerometerHandler")
            {
            }

            public void OnNewValue (float x, float y, float z)
            {
                Debug.unityLogger.Log (TAG, $"OnNewValue x: {x}, y: {y}, z: {z}");
                handler.OnNewValue (x, y, z);
            }
        }

        private AndroidJavaObject nativeAccelerometer;

        public Accelerometer (AndroidJavaObject nativeAccelerometer)
        {
            this.nativeAccelerometer = nativeAccelerometer;
        }

        public void Start (IAccelerometerHandler handler)
        {
            Debug.unityLogger.Log (TAG, "Start");
            nativeAccelerometer.Call ("Start", new AcceleromenterHandler (handler));
        }

        public void Stop ()
        {
            Debug.unityLogger.Log (TAG, "Stop");
            nativeAccelerometer.Call ("Stop");
        }
    }
}