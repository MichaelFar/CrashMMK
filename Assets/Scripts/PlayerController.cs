using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;
/// <summary>
/// Name: Michael Farrar
/// Description: Controls player movement
/// Date: 11/18/24
/// </summary>
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10.0f;

    public GameObject PlayerModel;

    public ParticleSystem AttackParticle;

    public Rigidbody rb;

    private float alpha = 0.0f;

    private Transform retainedVector;

    private bool grounded = true;

    /// <summary>
    /// Unused enum for player state
    /// </summary>
    public enum PlayerStates {Moving,Jumping,Attacking}

    public PlayerStates CurrentState;

    // Update is called once per frame
    /// <summary>
    /// contains logic for player jumping and attacking
    /// </summary>
    private void Update()
    {
        grounded = IsGrounded();

        var raycastOrigin = transform.position - new Vector3(0, 0.2f, 0);

        RaycastHit hitInfo;

        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 450 * 3);
            
        }
        if(Input.GetKeyDown(KeyCode.E) && !(AttackParticle.isPlaying))
        {
            AttackParticle.Play();
            CurrentState = PlayerStates.Attacking;

        }
        

        if (Physics.Raycast(raycastOrigin, Vector3.down, out hitInfo))
        {

            if (hitInfo.collider.GetComponent<Enemy>() && !hitInfo.collider.GetComponent<Enemy>().isTurtle)
            {
                var Stomp = hitInfo.collider.GetComponent<Enemy>();

                if (Stomp != null)
                {
                    Stomp.EnemyDeath();

                }
                rb.AddForce(Vector3.up * 450 * 3);

            }
            else if (hitInfo.collider.GetComponent<Crates>())
            {
                var Stomp = hitInfo.collider.GetComponent<Crates>();

                if (Stomp != null)
                {
                    Stomp.CrateDestroy();

                }
                rb.AddForce(Vector3.up * 450 * 3);

            }
        }

    }
    /// <summary>
    /// Controls logic for player movement, in FixedUpdate due to camera needing to be as well
    /// </summary>
    void FixedUpdate()
    {
        Vector3 inputVector = transform.position;

        

        float tempSpeed = speed;

        float speedMod = tempSpeed / 2;

        if(!grounded)
        {
            tempSpeed = speedMod;
        }

        if (Input.GetKey(KeyCode.W))
        {
            inputVector.z += tempSpeed * Time.deltaTime;
            alpha += Time.deltaTime;
            
            //LerpToDirection(alpha);
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.z -= tempSpeed * Time.deltaTime;
            alpha += Time.deltaTime;

            //LerpToDirection(alpha);
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x += tempSpeed * Time.deltaTime;
            alpha += Time.deltaTime;

            //LerpToDirection(alpha);
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x -= tempSpeed * Time.deltaTime;
            alpha += Time.deltaTime;

            //LerpToDirection(alpha);
        }

        if(alpha >= 0.0f)
        {
            PlayerModel.transform.LookAt(inputVector);
        }
            

        transform.position = inputVector;
        
    }
    /// <summary>
    /// Checks if grounded with raycast
    /// </summary>
    /// <returns></returns>
    private bool IsGrounded()
    {
        var raycast = Physics.Raycast(transform.position, Vector3.down, 1.2f);
        
        return raycast;
    }
    /// <summary>
    /// Called from playerlives
    /// </summary>
    public void PlayerDeath()
    {
        print("Game Over");

        //PlayerModel.SetActive(false);
    

    }



}
