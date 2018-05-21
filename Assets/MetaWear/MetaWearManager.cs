using System;
using MetaWear.Sensors;
using UnityEngine;

namespace MetaWear
{
    public class MetaWearManager : IMetaWearManager
    {
        private IMetaWearManager metaWearManager;

        public MetaWearManager (bool loggable)
        {
            if (Application.platform == RuntimePlatform.Android)
                metaWearManager = new Android.MetaWearManager (loggable);
            else
                metaWearManager = new Stub.MetaWearManager();
        }

        public void Init (Action initializedCallback)
        {
            metaWearManager.Init (initializedCallback);
        }

        public IBoard GetBoard (BluetoothDevice bluetoothDevice)
        {
            return metaWearManager.GetBoard (bluetoothDevice);
        }

        public IBoard GetBoard (string macAddress)
        {
            return metaWearManager.GetBoard (macAddress);    
        }

        public void ConnectoToTheBoard (IBoard board)
        {
            metaWearManager.ConnectoToTheBoard (board);
        }

        public IAccelerometer GetAccelerometer (IBoard board)
        {
            return metaWearManager.GetAccelerometer (board);
        }

        public IMagnetometer GetMagnetometer (IBoard board)
        {
            return metaWearManager.GetMagnetometer (board);
        }

        public IGyro GetGyro (IBoard board)
        {
            return metaWearManager.GetGyro (board);
        }

        public ILight GetLight (IBoard board)
        {
            return metaWearManager.GetLight (board);
        }
    }
}