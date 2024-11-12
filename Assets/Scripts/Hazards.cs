using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazards : MonoBehaviour
{
   /* Mateo Jimenez
    * 11/7/2024
    * handles Hazard killing and respawning 
    */

    //checks if player collides with enemy
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerLives>())
        {
            collision.gameObject.GetComponent<PlayerLives>().levelRespawn();
        }
    }
}
