using MetaWear.Sensors;
using UnityEngine;
using UnityEngine.Assertions;

namespace MetaWear.Android
{
    public class MetaWearManager : IMetaWearManager
    {
        private static string TAG = "Android.MetaWearManager";
        private AndroidJavaObject activity;

        public MetaWearManager ()
        {
            AndroidJavaClass jc = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
            activity = jc.GetStatic<AndroidJavaObject> ("currentActivity");
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

        public IMagnetometer GetMagnetometer (IBoard board)
        {
            return new Magnetometer (
                activity.Call<AndroidJavaObject> ("GetMagnetometer", GetBoard (board).NativeBoard));
        }

        public IGyro GetGyro (IBoard board)
        {
            return new Gyro (
                activity.Call<AndroidJavaObject> ("GetGyro", GetBoard (board).NativeBoard));
        }

        public ILight GetLight (IBoard board)
        {
            return new Light (
                activity.Call<AndroidJavaObject> ("GetLight", GetBoard (board).NativeBoard));
        }

        private Board GetBoard (IBoard board)
        {
            var androidBoard = board as Board;
            Assert.IsNotNull (androidBoard);

            return androidBoard;
        }
    }
}