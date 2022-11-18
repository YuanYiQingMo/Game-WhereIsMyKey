using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextStage : MonoBehaviour
{
    private Player player;

    private void OnTriggerEnter2D(Collider2D other) {
        player = other.GetComponent<Player>();
        if(player != null){
            ClearStage();
        }
    }

    private void ClearStage(){
        //TODO 下一关
        Debug.Log("下一关");
    }
}
