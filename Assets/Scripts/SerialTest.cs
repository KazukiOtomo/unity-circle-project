using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SerialTest : MonoBehaviour
{
    private SerialPortUtility.SerialPortUtilityPro _serialPort;
    private string _on = "relay on 0";
    private string _off = "relay off 0";
    
    void Start()
    {
        _serialPort = this.GetComponent<SerialPortUtility.SerialPortUtilityPro>();
    }

    public void RelayOn()
    {
        if (_serialPort != null)
        {
            if (_serialPort.IsOpened())
            {
                _serialPort.WriteCR(_on);
            }
        }
    }

    public void RelayOff()
    {
        if (_serialPort != null)
        {
            if (_serialPort.IsOpened())
            {
                _serialPort.WriteCR(_off);
            }
        }
    }
}
