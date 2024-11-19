using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
/// <summary>
/// Name: Michael Farrar
/// Description: Handles the camera movement in relation to the player
/// Date: 11/18/24
/// </summary>
public class CameraLerpTrigger: MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;

    public float CameraSpeed = 0.1f;

    private float alpha = 0.0f;

    private Vector3 OriginalPositionOfCamera;
    void Start()
    {
        OriginalPositionOfCamera = transform.position;
    }

    // Update is called once per frame
    /// <summary>
    /// Linearly interpolates the camera towards a certain offset based on the player's z position
    /// </summary>
    private void FixedUpdate()
    {
        
        var AlphaSlope = Time.deltaTime * 1.0f/20.0f;

        var DestinationVector = new Vector3(0.0f, transform.position.y, player.transform.position.z - 5.0f);

        alpha += AlphaSlope;

        transform.position = Vector3.Lerp(transform.position, DestinationVector, alpha);
        
        alpha = Math.Clamp(alpha, 0.0f, 1.0f);

        if(Vector3.Distance(transform.position, DestinationVector) < 0.8f)
        {
            alpha -= AlphaSlope;
        }

    }
    /// <summary>
    /// Unused, a type of easing
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    private double easeOutQuart(double x)
    {
        return 1.0 - Math.Pow(1.0 - x, 4.0);
    }

}
