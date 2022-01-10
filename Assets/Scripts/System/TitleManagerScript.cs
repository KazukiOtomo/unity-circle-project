using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManagerScript : MonoBehaviour
{
    private void Start()
    {
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("PlayerSelected") == PlayerPrefs.GetInt("PlayingPersons"))
        {
            SceneManager.LoadScene("MainGame");
        }
    }
}