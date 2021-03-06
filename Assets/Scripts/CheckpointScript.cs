using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{

    private GameMaster gm;

    void Start() {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player") {
            if(gameObject.tag == "Splitter") gm.split();
            
            gm.lastCheckpointPos = this.transform.position;
        }
    }
    
}
