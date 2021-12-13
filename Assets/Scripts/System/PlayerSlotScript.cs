using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSlotScript : MonoBehaviour
{
    [SerializeField] private Toggle[] playerRollToggle = new Toggle[2];
    [SerializeField] private bool capture = false;
    [SerializeField] private bool sabotage = false;

    private void Start()
    {
        if(playerRollToggle[0].isOn == true)
        {
            capture = true;
            sabotage = false;
        }
        else if (playerRollToggle[1].isOn == true)
        {
            sabotage = true;
            capture = false;
        }
    }

    public void OnRollToggled()
    {
        if (playerRollToggle[0].isOn == true)
        {
            capture = true;
            sabotage = false;
        }
        else if (playerRollToggle[1].isOn == true)
        {
            sabotage = true;
            capture = false;
        }
    }
}
