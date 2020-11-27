using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;
    public float howSmooth = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        Vector3 newPos = new Vector3(target.position.x, 0, -10);
        transform.position = Vector3.Slerp(transform.position, newPos, howSmooth);
        

    }
}
