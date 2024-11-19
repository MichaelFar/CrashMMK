using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


/* Mateo Jimenez, Michael farrar
 * 11/4/2024
 * Handles Player lives and respawn
 */
public class PlayerLives : MonoBehaviour
{
    // Start is called before the first frame update

    public int lives = 5;

    public int deathY = -3;


    public GameObject player;

    public GameObject levelRespawnPoint;

    public GameObject LivesUI;

    public Vector3 raycastOrigin;

    public GameObject FinalRatingText;

    public GameObject UIElements;

    /// <summary>
    /// Populates the initial Lives ui
    /// </summary>
    private void Start()
    {
        for (int i = 0; i < lives; i++)
        {
            LivesUI.GetComponent<FrameStars>().ActivateNextStar();
        }
        
    }

    void Update()
    {
        //kills player if falls into void
        if (transform.position.y <= deathY)
        {
            levelRespawn();
        }

    }


    //reduces players lives by 1 and teleports player to level respawn point if player still has lives 
    public void levelRespawn()
    {
        lives--;
        
        LivesUI.GetComponent<FrameStars>().DeactivateLastStar();
        
        

        if (lives == 0)
        {
            //player.GetComponent<PlayerController>().PlayerDeath();
            
            FinalRatingText.GetComponent<TextMeshProUGUI>().text = "You did bad!";

            UIElements.GetComponent<UIElements>().ToggleRoundEndFrame();
        }
        else
        {
            
            transform.position = levelRespawnPoint.transform.position;
        }

    }
   /// <summary>
   /// Adds to lives, updates ui
   /// </summary>
   /// <param name="newLives"></param>
    public void addLives(int newLives = 1 )
    {
        lives += newLives;
        LivesUI.GetComponent<FrameStars>().ActivateNextStar();
    }

   
}
