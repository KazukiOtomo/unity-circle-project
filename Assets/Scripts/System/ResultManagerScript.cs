using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultManagerScript : MonoBehaviour
{
    public Image defeat;
    public Text defeat_text;

    private void Awake()
    {
        if (GameManagerScript.IsDefeated)
        {
            defeat.color = new Color(1, 1, 1, 0);
            defeat_text.color= new Color(1, 1, 1, 0);
        }
        else
        {
            defeat.color = new Color(1, 1, 1, 1);
            defeat_text.color= new Color(1, 1, 1, 1);
        }
    }

    private void Update()
    {
        Invoke(nameof(ReturnSelectScene),5f);
    }

    private void ReturnSelectScene()
    {
        SceneManager.LoadScene("Select");
    }
}
