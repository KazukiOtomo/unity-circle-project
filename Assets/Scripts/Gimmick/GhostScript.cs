using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostScript : MonoBehaviour
{
    [SerializeField] private float speed = 0f;
    [SerializeField] private GameObject[] players = new GameObject[4];

    private GameObject nearPlayer;

    private void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    private void Update()
    {
        nearPlayer = FindNearPlayer(players);

        transform.LookAt(nearPlayer.transform);
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private GameObject FindNearPlayer(GameObject[] players)
    {
        GameObject near = players[0];
        Vector3 ghost = this.gameObject.transform.position;
        float dist, minDist = float.MaxValue;

        foreach(GameObject p in players)
        {
            Vector3 player = p.transform.position;
            dist = Vector3.Distance(ghost, player);
            if(dist < minDist)
            {
                minDist = dist;
                near = p;
            }
        }

        return near;
    }
}
