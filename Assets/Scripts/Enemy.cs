using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/* Mateo Jimenez
 * 11/12/2024
 * handles enemy movement and death
 */


public class Enemy : MonoBehaviour
{
    public int moveSpeed = 10;

    public bool movingRight;

    public bool sideToSide;

    public bool forwardToBack;


    //enemy types
    public bool isShielded;

    public bool isTurtle;


    public GameObject enemyObject;

    public Vector3 raycastEn;

   
    



    //toggles between front to back or side to side direction
    void Update()
    {
        raycastEn = transform.position - new Vector3(0, 0, 0);

        RaycastHit hitInfo;
        if (movingRight && !Physics.Raycast(raycastEn, Vector3.down, out hitInfo))
        {
            movingRight = false;
        }
        else if(!movingRight && !Physics.Raycast(raycastEn, Vector3.down, out hitInfo))
        {
            movingRight = true;
        }


        if (sideToSide)
        {
            EnemySideMove();
        }
        else if (forwardToBack)
        {
            EnemyFrontMove();
        }

    
    }

    //detects if enemy has collided with a wall and switches direction
    private void OnCollisionEnter(Collision collision)
    {
        
        if (movingRight && !collision.gameObject.GetComponent<PlayerLives>())
        {
            movingRight = false;
        }
        else if (!movingRight && !collision.gameObject.GetComponent<PlayerLives>())
        {
            movingRight = true;
        }
    }

    // enemy will move side to side or forwards and backward, switching directions when colliding with a wall
    public void EnemySideMove()
    {

       
        if (movingRight)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;

        }
        else
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
    }

    public void EnemyFrontMove()
    {


        if (movingRight)
        {
            transform.position += Vector3.forward * moveSpeed * Time.deltaTime;

        }
        else
        {
            transform.position += Vector3.back * moveSpeed * Time.deltaTime;
        }
    }
    //kills enemy
    public void EnemyDeath()
    {
        Destroy(gameObject);
    }

    


}
