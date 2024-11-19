using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Name: Michael Farrar
/// Description: Displays the victory ui
/// Date: 11/18/24
/// </summary>
public class VictoryBox : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject UIElements;
    void Start()
    {
        
    }

    // Update is called once per frame
    /// <summary>
    /// Displays the final score for the level
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<PlayerController>();

        if (player)
        {
            print("Reached victory box");
            UIElements.GetComponent<UIElements>().ToggleRoundEndFrame();
            
        }
    }
}
    

