using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    private Player player;
    private void Start() {
    }
    private void OnTriggerEnter2D(Collider2D other) {
        player = other.GetComponent<Player>();
        if(player != null){
            player.GetKey();
            Destroy(gameObject);
        }
    }
}
