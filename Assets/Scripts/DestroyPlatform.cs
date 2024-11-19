using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Name: Mateo Jimenez
/// Description: Breakable platform with visible stage changing for player feedback
/// Date: 11/18/24
/// </summary>
public class DestroyPlatform : MonoBehaviour
{
    public float breaktime = .75f;

    public Material stage1;
    public Material stage2;
    public Material stage3;

    private bool breaking = false;

    public GameObject Platform;
    /// <summary>
    /// Calls the coroutine for stage changing, checks if already doing so
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    { 
        if (collision.gameObject.GetComponent<PlayerController>() && !breaking)
        {
            breaking = true;
            StartCoroutine(WaitToDestroy());

            
        }
    }
    /// <summary>
    /// Progresses through 3 stages then is destroyed
    /// </summary>
    /// <returns></returns>
    private IEnumerator WaitToDestroy()
    {

        

        Platform.GetComponent<MeshRenderer>().material = stage1;

        yield return new WaitForSeconds(breaktime);

        Platform.GetComponent<MeshRenderer>().material = stage2;

        yield return new WaitForSeconds(breaktime);

        Platform.GetComponent<MeshRenderer>().material = stage3;

        yield return new WaitForSeconds(breaktime);

        Destroy(gameObject);
    }
}
