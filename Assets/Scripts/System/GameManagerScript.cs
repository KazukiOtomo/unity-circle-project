using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Object = System.Object;

public class GameManagerScript : MonoBehaviour
{ 
    public GameObject[] penguin=new GameObject[8];
    public GameObject[] ghost=new GameObject[8];

    private void Awake()
    {
        Debug.LogWarning(SelectRepository.attackers_num);
        Debug.LogWarning(SelectRepository.defenders_num);
        for (var i = 0; i < SelectRepository.attackers_num.Length; i++)
        {
            if (SelectRepository.attackers_num[i] == -1)
            {
                Destroy(penguin[i]);
            }
            else
            {
                penguin[i].GetComponent<InputController>().jc_ind = SelectRepository.attackers_num[i];
            }
            if (SelectRepository.defenders_num[i] == -1)
            {
                Destroy(ghost[i]);
            }
            else
            {
               ghost[i].GetComponent<InputController>().jc_ind = SelectRepository.defenders_num[i];
            }
        }
    }

    private void Update()
    {

    }
}
