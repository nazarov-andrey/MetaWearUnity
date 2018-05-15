using MetaWear.Sensors;
using UnityEngine;

namespace MetaWear.Android
{
    public abstract class Sensor<TSelf, THandler> : ISensor<THandler>
    {
        protected abstract class Handler : AndroidJavaProxy
        {
            protected THandler handler;

            protected Handler (string javaInterface, THandler handler) : base (javaInterface)
            {
                this.handler = handler;
            }
        }

        protected static string TAG = "Android." + typeof (TSelf);
        protected AndroidJavaObject nativeSensor;

        protected Sensor (AndroidJavaObject nativeSensor)
        {
            this.nativeSensor = nativeSensor;
        }

        protected abstract Handler CreateHandler (THandler handler);

        public void Start (THandler handler)
        {
            Debug.unityLogger.Log (TAG, "Start");
            nativeSensor.Call ("Start", CreateHandler (handler));
        }

        public void Stop ()
        {
            Debug.unityLogger.Log (TAG, "Stop");
            nativeSensor.Call ("Stop");
        }
    }

    public class Accelerometer : Sensor<Accelerometer, IAccelerometerHandler>, IAccelerometer
    {
        private class AccelerometerHandler : Sensor<Accelerometer, IAccelerometerHandler>.Handler
        {
            public AccelerometerHandler (IAccelerometerHandler handler) :
                base ("de.horizont.metawearunity.IAccelerometerHandler", handler)
            {
            }

            public void OnNewValue (float x, float y, float z)
            {
                Debug.unityLogger.Log (TAG, $"OnNewValue x: {x}, y: {y}, z: {z}");
                handler.OnNewValue (x, y, z);
            }
        }

        public Accelerometer (AndroidJavaObject nativeSensor) : base (nativeSensor)
        {
        }

        protected override Handler CreateHandler (IAccelerometerHandler handler)
        {
            return new AccelerometerHandler (handler);
        }
    }

    public class Gyro : Sensor<Gyro, IGyroHandler>, IGyro
    {
        private class GyroHandler : Sensor<Gyro, IGyroHandler>.Handler
        {
            public GyroHandler (IGyroHandler handler) :
                base ("de.horizont.metawearunity.IGyroHandler", handler)
            {
            }

            public void OnNewValue (float x, float y, float z)
            {
                Debug.unityLogger.Log (TAG, $"OnNewValue x: {x}, y: {y}, z: {z}");
                handler.OnNewValue (x, y, z);
            }
        }

        public Gyro (AndroidJavaObject nativeSensor) : base (nativeSensor)
        {
        }

        protected override Handler CreateHandler (IGyroHandler handler)
        {
            return new GyroHandler (handler);
        }
    }

    public class Magnetometer : Sensor<Magnetometer, IMagnetometerHandler>, IMagnetometer
    {
        private class MagnetometerHandler : Sensor<Magnetometer, IMagnetometerHandler>.Handler
        {
            public MagnetometerHandler (IMagnetometerHandler handler) :
                base ("de.horizont.metawearunity.IMagnetometerHandler", handler)
            {
            }

            public void OnNewValue (float x, float y, float z)
            {
                Debug.unityLogger.Log (TAG, $"OnNewValue x: {x}, y: {y}, z: {z}");
                handler.OnNewValue (x, y, z);
            }
        }

        public Magnetometer (AndroidJavaObject nativeSensor) : base (nativeSensor)
        {
        }

        protected override Handler CreateHandler (IMagnetometerHandler handler)
        {
            return new MagnetometerHandler (handler);
        }
    }
    
    public class Light : Sensor<Light, ILightHandler>, ILight
    {
        private class LightHandler : Sensor<Light, ILightHandler>.Handler
        {
            public LightHandler (ILightHandler handler) :
                base ("de.horizont.metawearunity.ILightHandler", handler)
            {
            }

            public void OnNewValue (float light)
            {
                Debug.unityLogger.Log (TAG, $"OnNewValue light: {light}");
                handler.OnNewValue (light);
            }
        }

        public Light (AndroidJavaObject nativeSensor) : base (nativeSensor)
        {
        }

        protected override Handler CreateHandler (ILightHandler handler)
        {
            return new LightHandler (handler);
        }
    }
}