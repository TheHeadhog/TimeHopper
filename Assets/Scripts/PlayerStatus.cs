using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

    public int Health;
    private int Fuel;
    public CameraScript basic_camera;
    public CameraScript alt_camera;
    public Rigidbody2D character_body;

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

    private bool checkCollision() {
        GameObject altSelf;
        if(isAlternate)
            altSelf = shadowInv;
        else
            altSelf = shadow;

        //ako se altSelf poklapa sa necim onda se ne dozvoljava prelazak!
        Debug.Log(altSelf.GetComponent<ShadowScript>().inCollision);
        return altSelf.GetComponent<ShadowScript>().inCollision;
    }

    // Update is called once per frame
    void Update(){

        //Prelazak u suprotni timeline se aktivira tasterom 'C'
        if (Input.GetKeyDown(KeyCode.C))
        {
            if(!checkCollision()) {
                changeTimeline();
                hideShadow();
            }
        }
        if (persistant > 0) { --persistant; if (persistant == 0) { Debug.Log(persistant); } }

    }

    // Collision with objects
    private int persistant = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Hazzard" && persistant == 0)
        {
            persistant = 100;
            takeDamage();
            int way = (new System.Random()).Next(0, 1);
            if (way == 0) way = -1;
            character_body.AddForce(new Vector2(UnityEngine.Random.Range(0, 100f) * way, UnityEngine.Random.Range(700f, 1000f)));  //Random knockoff charachter

            if (collision.rigidbody != null) collision.rigidbody.AddForce(new Vector2(UnityEngine.Random.Range(100f, 200f) * (-way), 0));

        }
        else if (collision.collider.tag == "FallDeath") die();
    }

    public void takeDamage(int dmg=1)
    {
        Health -= dmg;
        if (Health <= 0) die();
    }

    private void die()
    {
        (gameObject.GetComponent<Rigidbody2D>()).simulated = false;
        Time.timeScale = 0;
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
