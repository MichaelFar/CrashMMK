using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* Mateo Jimenez
 * 11/4/2024
 * Handles Player lives and respawn
 */
public class PlayerLives : MonoBehaviour
{
    // Start is called before the first frame update

    public int lives = 5;

    public GameObject levelRespawnPoint;

  //checks if player collides with enemy
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Hazards>()){
            levelRespawn();
        }
    }

    //reduces players lives by 1 and teleports player to level respawn point if player still has lives 
    public void levelRespawn()
    {
        lives--;

        if(lives == 0)
        {
            print("Game Over");

            gameObject.GetComponent<MeshRenderer>().enabled = false;
            this.enabled = false;
        }
        else
        {
            transform.position = levelRespawnPoint.transform.position;
        }

    }
}
