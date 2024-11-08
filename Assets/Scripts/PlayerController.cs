using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

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

    private enum PlayerStates {Moving,Jumping,Attacking}

    private PlayerStates CurrentState;

    // Update is called once per frame
    private void Update()
    {
        grounded = IsGrounded();

        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 450 * 3);
        }
        if(Input.GetKeyDown(KeyCode.Mouse0) && !(AttackParticle.isPlaying))
        {
            AttackParticle.Play();
            CurrentState = PlayerStates.Attacking;
            
        }
        
    }
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

    private bool IsGrounded()
    {
        var raycast = Physics.Raycast(transform.position, Vector3.down, 1.2f);

        return raycast;
    }

    
    
}
