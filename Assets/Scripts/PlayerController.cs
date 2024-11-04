using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10.0f;

    public GameObject PlayerModel;

    public Rigidbody rb;

    private float alpha = 0.0f;

    // Update is called once per frame
    void Update()
    {
        Vector3 inputVector = transform.position;

        bool grounded = IsGrounded();

        float tempSpeed = speed;

        float speedMod = tempSpeed / 3;

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

        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 450);
        }

        

        alpha = Mathf.Clamp(alpha, 0.0f, 1.0f);

        alpha += Time.deltaTime;

        PlayerModel.transform.LookAt(new Vector3(inputVector.x * alpha, inputVector.y, inputVector.z * alpha));

        if (!Input.anyKey)
        {
            alpha = 0.0f;
            PlayerModel.transform.LookAt(inputVector);
        }
        else
        {
            
        }
        

        transform.position = inputVector;
        
    }

    private bool IsGrounded()
    {
        var raycast = Physics.Raycast(transform.position, Vector3.down, 2.3f);

        return raycast;
    }

    
    
}
