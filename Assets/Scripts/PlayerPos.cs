using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPos : MonoBehaviour
{
    private GameMaster gm;

    void Start() {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        spawnCheckpoint();

    }
    void spawnCheckpoint() {
        transform.position = gm.lastCheckpointPos;
    }
}
