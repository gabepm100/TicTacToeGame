using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallScript : MonoBehaviour
{
    float damage;

    public void SetDamage(float amount)
    {
        damage = amount;
    }
   
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "ColiisionSquare")
        {
            // destroy this object
            
            Destroy(gameObject);
        }
        if (collision.gameObject.name == "Ground")
        {
            // destroy this object

            Destroy(gameObject);
        }
    }
 
}

