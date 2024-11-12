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

    public int deathY = -3;


    public GameObject levelRespawnPoint;

   

    public Vector3 raycastOrigin;

    

    
    void Update()
    {
        if (transform.position.y <= deathY)
        {
            levelRespawn();
        }

        raycastOrigin = transform.position - new Vector3(0, 0, 0);
        

        RaycastHit hitInfo;
        if (Physics.Raycast(raycastOrigin, Vector3.down, out hitInfo))
        {
            if (hitInfo.collider.GetComponent<Enemy>() && !hitInfo.collider.GetComponent<Enemy>().isTurtle)
            {
                Destroy(hitInfo.collider.GetComponent<Enemy>().enemyObject);
            }
            
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
   
    public void addLives(int newLives = 1 )
    {
        lives += newLives;


    }

   
}