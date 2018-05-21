using System;
using MetaWear;
using MetaWear.Sensors;
using UnityEngine;
using UnityEngine.UI;

public class EntryPoint : MonoBehaviour, IAccelerometerHandler
{
    private static string TAG = "EntryPoint";

    private MetaWearManager manager;

    [SerializeField]
    private InputField macAddress;

    [SerializeField]
    private Text accelerometerText;

    [SerializeField]
    private Text devicesText;

    private void Awake ()
    {
        manager = new MetaWearManager (false);
    }

    public void Connect ()
    {
        Debug.unityLogger.Log (TAG, "Connect button click " + macAddress.text);
        IBoard board = manager.GetBoard (macAddress.text);
        board.Connected += BoardOnConnected;
        board.Failed += BoardOnFailed;
        board.UnexpectedDisconnect += BoardOnUnexpectedDisconnect;

        manager.ConnectoToTheBoard (board);
    }

    private void BoardOnUnexpectedDisconnect (object sender, EventArgs e)
    {
        Debug.unityLogger.Log (TAG, "BoardOnUnexpectedDisconnect");
    }

    private void BoardOnFailed (object sender, EventArgs e)
    {
        Debug.unityLogger.Log (TAG, "BoardOnFailed");
    }

    private void BoardOnConnected (object sender, EventArgs e)
    {
        Debug.unityLogger.Log (TAG, "BoardOnConnected");

        IAccelerometer accelerometer = manager.GetAccelerometer (sender as IBoard);
        accelerometer.Start (this);
    }

    public void OnNewValue (float x, float y, float z)
    {
        Debug.unityLogger.Log (TAG, "OnNewValue");
        accelerometerText.text = $"x: {x}; y: {y}; z: {z};";
    }
}