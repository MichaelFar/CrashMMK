using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryBox : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject UIElements;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<PlayerController>();

        if (player)
        {
            print("Reached victory box");
            UIElements.GetComponent<UIElements>().ToggleRoundEndFrame();
            Destroy(player);
        }
    }
}
    

