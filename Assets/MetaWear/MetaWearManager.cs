﻿using MetaWear.Sensors;
using UnityEngine;

namespace MetaWear
{
    public class MetaWearManager : IMetaWearManager
    {
        private IMetaWearManager metaWearManager;

        public MetaWearManager ()
        {
            if (Application.platform == RuntimePlatform.Android)
                metaWearManager = new Android.MetaWearManager ();
            else
                metaWearManager = new Stub.MetaWearManager();
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