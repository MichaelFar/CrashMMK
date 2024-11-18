using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FrameStars : MonoBehaviour
{
    // Start is called before the first frame update

    private object[] hearts;
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            print(transform.GetChild(i).gameObject);
            hearts.Append<object>(transform.GetChild(i).gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
