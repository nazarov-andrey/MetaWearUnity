using UnityEngine;
using UnityEngine.Assertions;

namespace MetaWear.Android
{
    public class MetaWearManager : IMetaWearManager
    {
        private static string TAG = "Android.MetaWearManager";

        class DeviceCallback : AndroidJavaProxy
        {
            private IDeviceHandler deviceHandler;

            public DeviceCallback (IDeviceHandler deviceHandler) : base ("de.horizont.metawearunity.IDeviceHandler")
            {
                this.deviceHandler = deviceHandler;
            }

            public void OnNewDevice (AndroidJavaObject device)
            {
                Debug.unityLogger.Log (TAG, "OnNewDevice");
                deviceHandler.OnNewDevice (
                    new BluetoothDevice (
                        device.Call<string> ("getAddress"),
                        device.Call<string> ("getName")));
            }
        }

        private AndroidJavaObject activity;

        public MetaWearManager ()
        {
            AndroidJavaClass jc = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
            activity = jc.GetStatic<AndroidJavaObject> ("currentActivity");
        }

        public void ScanDevices (IDeviceHandler deviceHandler, long timeout)
        {
            Debug.unityLogger.Log (TAG, "ScanDevices");
            activity.Call ("ScanDevices", true, new DeviceCallback (deviceHandler), timeout);
        }

        public IBoard GetBoard (BluetoothDevice bluetoothDevice)
        {
            return GetBoard (bluetoothDevice.MacAddress);
        }

        public IBoard GetBoard (string macAddress)
        {
            Debug.unityLogger.Log (TAG, "GetBoard");
            return new Board (activity.Call<AndroidJavaObject> ("GetBoard", macAddress));
        }

        public void ConnectoToTheBoard (IBoard board)
        {
            Debug.unityLogger.Log (TAG, "ConnectoToTheBoard");

            Board androidBoard = GetBoard (board);

            activity.Call (
                "ConnectToTheBoard",
                androidBoard.NativeBoard,
                androidBoard);
        }

        public IAccelerometer GetAccelerometer (IBoard board)
        {
            Debug.unityLogger.Log (TAG, "GetAccelerometer");

            return new Accelerometer (
                activity.Call<AndroidJavaObject> ("GetAcceleromenter", GetBoard (board).NativeBoard));
        }

        private Board GetBoard (IBoard board)
        {
            var androidBoard = board as Board;
            Assert.IsNotNull (androidBoard);

            return androidBoard;
        }
    }
}