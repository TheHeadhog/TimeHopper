using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

    public int Health;
    private int Fuel;
    // Start is called before the first frame update
    void Start(){

    }

    // Update is called once per frame
    void Update(){
        takeDamage();
    }

    public void takeDamage(int dmg=1)
    {
        Health -= dmg;
        if (Health <= 0)
        {
            (gameObject.GetComponent<Rigidbody2D>()).simulated=false;
        }
    }
}
