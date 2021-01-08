using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowScript : MonoBehaviour
{
    public bool inCollision = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col) {
        inCollision = true;
    }
    void OnTriggerExit2D(Collider2D col) {
        inCollision = false;
    }
}
