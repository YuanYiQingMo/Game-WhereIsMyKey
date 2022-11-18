using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private GameObject openDoor, closedDoor;
    [SerializeField]
    private Vector2 doorCheck;
    private Player player;

    [SerializeField]
    private LayerMask WhatIsPlayer;

    [SerializeField]
    private float doorCheckDirection;

    private bool stopCheck = false;

    private void Start() {
        openDoor.SetActive(false);
        closedDoor.SetActive(true);
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, doorCheck,doorCheckDirection, WhatIsPlayer);
        if (hit && !stopCheck)
        {
            player = hit.collider.GetComponent<Player>();
            if (player != null && player.hasKey())
            {
                OpenDoor();
            }
        }
    }

    private void OpenDoor(){
        Debug.Log(stopCheck);
        closedDoor.SetActive(false);
        openDoor.SetActive(true);
        stopCheck = true;
    }

    //Gizmos
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, doorCheck);
    }

}
