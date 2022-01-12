using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectManagerScript : MonoBehaviour
{
    private void Start()
    {
        
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("PlayerSelected") == PlayerPrefs.GetInt("PlayingPersons"))
        {
            for (var i = 0; i < SelectRepository.attackers_num.Length; i++)
            {
                Debug.LogWarning("attack" + i + " is "+SelectRepository.attackers_num[i]);
            }
            for (var i = 0; i < SelectRepository.attackers_num.Length; i++)
            {
                Debug.LogWarning("defence" + i + " is "+SelectRepository.defenders_num[i]);
            }
            SceneManager.LoadScene("MainGame");
        }
    }
}