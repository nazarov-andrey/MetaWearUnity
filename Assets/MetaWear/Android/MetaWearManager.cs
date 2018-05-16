using System;
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
            Debug.unityLogger.Log (TAG, "MetaWearManager.ctor");
        }
        
        private void AssetInitialized ()
        {
            Assert.IsNotNull (manager, "Call Init first");
        }

        public void Init (Action initializedCallback)
        {
            Debug.unityLogger.Log (TAG, "MetaWearManager.Init");
            
            AndroidJavaClass jc = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
            AndroidJavaObject activity = jc.GetStatic<AndroidJavaObject> ("currentActivity");
            manager = new AndroidJavaObject (
                "de.horizont.metawearunity.MetaWearManager",
                activity,
                new AndroidJavaRunnable (initializedCallback));
        }

        public IBoard GetBoard (BluetoothDevice bluetoothDevice)
        {
            return GetBoard (bluetoothDevice.MacAddress);
        }

        public IBoard GetBoard (string macAddress)
        {
            AssetInitialized ();
            
            Debug.unityLogger.Log (TAG, "GetBoard");
            return new Board (manager.Call<AndroidJavaObject> ("GetBoard", macAddress));
        }

        public void ConnectoToTheBoard (IBoard board)
        {
            AssetInitialized ();
            
            Debug.unityLogger.Log (TAG, "ConnectoToTheBoard");

            Board androidBoard = GetBoard (board);

            manager.Call (
                "ConnectToTheBoard",
                androidBoard.NativeBoard,
                androidBoard);
        }

        public IAccelerometer GetAccelerometer (IBoard board)
        {
            AssetInitialized ();
            
            Debug.unityLogger.Log (TAG, "GetAccelerometer");

            return new Accelerometer (
                manager.Call<AndroidJavaObject> ("GetAcceleromenter", GetBoard (board).NativeBoard));
        }

        public IMagnetometer GetMagnetometer (IBoard board)
        {
            AssetInitialized ();
            
            return new Magnetometer (
                manager.Call<AndroidJavaObject> ("GetMagnetometer", GetBoard (board).NativeBoard));
        }

        public IGyro GetGyro (IBoard board)
        {
            AssetInitialized ();
            
            return new Gyro (
                manager.Call<AndroidJavaObject> ("GetGyro", GetBoard (board).NativeBoard));
        }

        public ILight GetLight (IBoard board)
        {
            AssetInitialized ();
            
            return new Light (
                manager.Call<AndroidJavaObject> ("GetLight", GetBoard (board).NativeBoard));
        }

        private Board GetBoard (IBoard board)
        {
            AssetInitialized ();
            
            var androidBoard = board as Board;
            Assert.IsNotNull (androidBoard);

            return androidBoard;
        }
    }
}