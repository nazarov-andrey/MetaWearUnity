using MetaWear.Sensors;
using UnityEngine;
using UnityEngine.Assertions;

namespace MetaWear.Android
{
    public class MetaWearManager : IMetaWearManager
    {
        private static string TAG = "Android.MetaWearManager";
        private AndroidJavaObject manager;

        public MetaWearManager ()
        {
            AndroidJavaClass jc = new AndroidJavaClass ("de.horizont.metawearunity.MetaWearManager");
            manager = jc.CallStatic<AndroidJavaObject> ("GetInstance");
        }

        public IBoard GetBoard (BluetoothDevice bluetoothDevice)
        {
            return GetBoard (bluetoothDevice.MacAddress);
        }

        public IBoard GetBoard (string macAddress)
        {
            Debug.unityLogger.Log (TAG, "GetBoard");
            return new Board (manager.Call<AndroidJavaObject> ("GetBoard", macAddress));
        }

        public void ConnectoToTheBoard (IBoard board)
        {
            Debug.unityLogger.Log (TAG, "ConnectoToTheBoard");

            Board androidBoard = GetBoard (board);

            manager.Call (
                "ConnectToTheBoard",
                androidBoard.NativeBoard,
                androidBoard);
        }

        public IAccelerometer GetAccelerometer (IBoard board)
        {
            Debug.unityLogger.Log (TAG, "GetAccelerometer");

            return new Accelerometer (
                manager.Call<AndroidJavaObject> ("GetAcceleromenter", GetBoard (board).NativeBoard));
        }

        public IMagnetometer GetMagnetometer (IBoard board)
        {
            return new Magnetometer (
                manager.Call<AndroidJavaObject> ("GetMagnetometer", GetBoard (board).NativeBoard));
        }

        public IGyro GetGyro (IBoard board)
        {
            return new Gyro (
                manager.Call<AndroidJavaObject> ("GetGyro", GetBoard (board).NativeBoard));
        }

        public ILight GetLight (IBoard board)
        {
            return new Light (
                manager.Call<AndroidJavaObject> ("GetLight", GetBoard (board).NativeBoard));
        }

        private Board GetBoard (IBoard board)
        {
            var androidBoard = board as Board;
            Assert.IsNotNull (androidBoard);

            return androidBoard;
        }
    }
}