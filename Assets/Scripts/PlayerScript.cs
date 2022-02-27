using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private float health = 100f;
    private bool dead = false;
    private Weapon weapon;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0f)
        {
            dead = true;
        }

        if (dead == true)
        {
            Destroy(gameObject);
        }
        if (weapon.name == "Scar")
        {
            Debug.Log("Scar");
        }
    }
}
