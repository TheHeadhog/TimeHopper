using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

    public int Health;
    private int Fuel;
    public CameraScript main_camera;
    public CameraScript alt_camera;


    public float levelHeight = 18f;

    private SpriteRenderer shadow=null, shadowInv=null;

    //u kom timeline-u se trenutno nalazi igrac, korisno za dodavanje i oduzimanje sposobnosti
    public bool isAlternate = false;



    void Start(){
        shadow = (this.transform.Find("Shadow").gameObject).GetComponent<SpriteRenderer>();
        shadowInv = (this.transform.Find("ShadowInv").gameObject).GetComponent<SpriteRenderer>();

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
        var output = this.transform.position;
        if (!isAlternate)
            output.y -= levelHeight;
        else
            output.y += levelHeight;
        return output;
    }

    private void hideShadow() 
    {
        if (!isAlternate)
        {
            shadowInv.enabled = true;
            shadow.enabled = false;
        }
        else
        {
            shadowInv.enabled = false;
            shadow.enabled = true;
        }
    }

    private void swapTransforms()
    {
        Transform tmp;
        tmp = main_camera.main_target;
        main_camera.main_target = main_camera.alt_target;
        main_camera.alt_target = tmp;

        tmp = alt_camera.main_target;
        alt_camera.main_target = alt_camera.alt_target;
        alt_camera.alt_target = tmp;
    }
}
