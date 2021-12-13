using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultManagerScript : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) ReturnMainGameScene();
    }

    private void ReturnMainGameScene()
    {
        SceneManager.LoadScene("MainGame");
    }
}
