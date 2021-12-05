using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleManagerScript : MonoBehaviour
{
    //---------------------------------------------//

    //Playerごとの名前
    [SerializeField] private string[] playerNames = new string[8];

    //Playerごとのチーム分け
    [SerializeField] private static int[] playerTeam = new int[8];

    //Playerごとのコントローラー
    [SerializeField] private static int[] playerController = new int[8];

    //---------------------------------------------//

    [SerializeField] private int playerCount = 4;

    [SerializeField] private GameObject PlayerNumber;
    private Text playerNumber = null;

    private void Start()
    {
        playerNumber = PlayerNumber.GetComponent<Text>();
        for (int i = 0; i < 8; i++)
        {
            playerNames[i] = "Player" + i;
        }
    }

    private void Update()
    {
        playerNumber.text = playerCount.ToString();
    }

    private void PlayerSave()
    {
        PlayerPrefs.SetInt("PLAYER", playerCount);
    }

    //ボタン用【PlayerUp】
    public void PlayerCountUp()
    {
        if(playerCount >= 8)
        {
            playerCount = 8;
            return;
        }
        playerCount++;
    }

    //ボタン用【PlayerDown】
    public void PlayerCountDown()
    {
        if(playerCount <= 2)
        {
            playerCount = 2;
            return;
        }
        playerCount--;
    }
}