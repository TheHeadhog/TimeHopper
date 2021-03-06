using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{

    private static bool isSplit = false;
    private static GameMaster instance; //singleton
    public Vector2 lastCheckpointPos; //cuva poziciju aktuelnog checkpoint-a
    private Camera full, basic, alternate;
    public PlayerStatus status;

    public void Start() {
        status = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>();
        full = GameObject.FindGameObjectWithTag("FullCam").GetComponent<Camera>();
        basic = GameObject.FindGameObjectWithTag("BasicCam").GetComponent<Camera>();
        alternate = GameObject.FindGameObjectWithTag("AltCam").GetComponent<Camera>();
        if(isSplit) split();
    }
    
    public void split() {
        //pusti da se prebacuje i podesi kamere
        basic.enabled = true;
        alternate.enabled = true;
        full.enabled = false;
        status.canChange = true;
        isSplit = true;

    }
    public void Awake() {
        if(instance==null) {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else {
            Destroy(gameObject);
        }
    }
}
