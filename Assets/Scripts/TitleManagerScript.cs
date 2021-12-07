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

    public GameObject[] playerSlots = new GameObject[8];

    [SerializeField] private GameObject PlayerNumber;
    private Text playerNumber = null;

    public int blueCaptureCount;
    public int blueSabotageCount;

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
         //for(int i = 2;i <= playerCount)
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
        playerSlots[playerCount - 1].SetActive(true);
    }

    //ボタン用【PlayerDown】
    public void PlayerCountDown()
    {
        if(playerCount <= 2)
        {
            playerCount = 2;
            return;
        }
        playerSlots[playerCount - 1].SetActive(false);
        playerCount--;
    }

    

    private string Horizontal(int i)
    {
        string c = "Horizontal " + i;
        return c;
    }
}