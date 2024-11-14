using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Mateo Jimenez
 * 11/14/2024
 * handles crate desctruction and spawning
 */

public class Crates : MonoBehaviour
{

    public int dropCount = 1;

    public GameObject dropFruit;

    
    // Start is called before the first frame update

    //crate is destroyed and spawns the amount of fruit from dropcount
    public void CrateDestroy()
    {

        Destroy(gameObject);

        for (int i = 0; i < dropCount; i++)
        {
            Instantiate(dropFruit, transform.position, Quaternion.identity);
        }
    }
    
   
}
