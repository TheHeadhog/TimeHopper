using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

    public int Health;
    private int Fuel;
    public CameraScript basic_camera;
    public CameraScript alt_camera;



    private GameObject shadow=null, shadowInv=null;

    //u kom timeline-u se trenutno nalazi igrac, korisno za dodavanje i oduzimanje sposobnosti
    public bool isAlternate = false;



    void Start(){
        shadow = this.transform.Find("Shadow").gameObject;
        shadowInv = this.transform.Find("ShadowInv").gameObject;

        if (transform.position.y < 0)
        {
            isAlternate = true;
        }
        hideShadow();

    }

    // Update is called once per frame
    void Update(){

        //Prelazak u suprotni timeline se aktivira tasterom 'C'
        if (Input.GetKeyDown(KeyCode.C))
        {
            changeTimeline();
            hideShadow();
        }
    }

    public void takeDamage(int dmg=1)
    {
        Health -= dmg;
        if (Health <= 0)
        {
            (gameObject.GetComponent<Rigidbody2D>()).simulated=false;
        }
    }


    //Promena timeline-a
    private void changeTimeline()
    {
        transform.position = getAltCoords();
        isAlternate = !isAlternate;
        swapTransforms();
    }


    //Dohvatanje novih koordinata pri promeni iz jednog u drugi timeline
    private Vector3 getAltCoords()
    {
        Vector3 output;
        if (!isAlternate)
        {
            output = shadow.transform.position;
        }
        else
        {
            output = shadowInv.transform.position;
        }
        return output;
    }

    private void hideShadow() 
    {
        if (isAlternate)
        {
            shadowInv.GetComponent<SpriteRenderer>().enabled = true;
            shadow.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            shadowInv.GetComponent<SpriteRenderer>().enabled = false;
            shadow.GetComponent<SpriteRenderer>().enabled = true;
        }
    }


//Zamena targeta za obe kamere
    private void swapTransforms()
    {
        Transform tmp;
        tmp = basic_camera.main_target;
        basic_camera.main_target = basic_camera.alt_target;
        basic_camera.alt_target = tmp;

        //basic_camera.position = basic_camera.main_target.transform.position;

        tmp = alt_camera.main_target;
        alt_camera.main_target = alt_camera.alt_target;
        alt_camera.alt_target = tmp;

        //alt_camera.position = alt_camera.main_target.transform.position;
    }
}
