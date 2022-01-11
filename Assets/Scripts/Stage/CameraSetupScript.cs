using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSetupScript : MonoBehaviour
{
    private CinemachineTargetGroup cinemachineTarget;
    private GameObject[] players;

    private void Start()
    {
        cinemachineTarget = GetComponent<CinemachineTargetGroup>();
        players = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject p in players)
        {
            var t = p.transform;
            cinemachineTarget.AddMember(t, 1.2f, 12);
        }
        players = GameObject.FindGameObjectsWithTag("Ghost");

        foreach (GameObject p in players)
        {
            var t = p.transform;
            cinemachineTarget.AddMember(t, 1.2f, 12);
        }
    }
}
