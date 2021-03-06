using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform main_target;
    public Transform alt_target;
    public float howSmooth = 0.5f;
    public float offset=2.5f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(main_target.position.x, main_target.position.y+offset, -10);
        //transform.position = Vector3.Slerp(transform.position, newPos, howSmooth);
         transform.position = newPos;
    }

    void LateUpdate()
    {
        
        

    }
}
