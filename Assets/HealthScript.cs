using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{

    public Sprite[] hearts=new Sprite[4];
    private GameObject healthBarImage;
    // Start is called before the first frame update
    void Start()
    {
        healthBarImage=transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setHealth(int Health) {
        if(Health>-1 && Health<4) 
            (healthBarImage.GetComponent<Image>()).sprite = hearts[Health];
    }
}
