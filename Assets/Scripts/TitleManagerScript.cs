using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TitleManagerScript : MonoBehaviour
{
    [SerializeField] private int playerCount = 4;

    //---------------------------------------------//

    //Playerごとの名前
    [SerializeField] private string[] playerNames = new string[8];

    //Playerごとのチーム分け
    [SerializeField] private static int[] playerTeam = new int[8];

    //
    [SerializeField] List<Toggle> playerRolls;

    //Playerごとのコントローラー
    [SerializeField] private static int[] playerController = new int[8];

    //---------------------------------------------//

    public GameObject[] playerSlots = new GameObject[8];

    [SerializeField] private GameObject playerCounterUI;
    private Text playerNumber = null;

    public int blueCaptureCount;
    public int blueSabotageCount;

    private bool[] roll = new bool[8];
    private Toggle[] toggle = new Toggle[8];

    private void Start()
    {
        playerNumber = playerCounterUI.GetComponent<Text>();
        for (int i = 0; i < 8; i++)
        {
            playerNames[i] = "Player" + (i + 1);
        }

        /*
        for (int i = 0; i < 8; i++)
        {
            toggle[i] = playerRolls[i].GetToggles().First();
            Debug.Log(toggle[i].);
        }
        */

        foreach (var item in playerRolls[0].GetToggles())
        {
            //Debug.Log(item.name);
        }
    }

    private void Update()
    {
        playerNumber.text = playerCount.ToString();
        //Debug.Log(playerRolls[0].GetComponent<ToggleGroup>().ActiveToggles().FirstOrDefault());
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
        if(playerCount <= 4)
        {
            playerCount = 4;
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