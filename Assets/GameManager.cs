using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject[] gimmick = new GameObject[12];
    public Vector3 point;

    private Transform 

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var distance = Vector3.Distance(player.transform.position, mainCamera.transform.position);
            var mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);

            currentPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        }

    }

    private void SetGimmick(int i ,Vector3 point)
    {
        Instantiate(gimmick[i]).transform.position = point;
    }
}
