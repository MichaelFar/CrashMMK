using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlatform : MonoBehaviour
{
    public float breaktime = .75f;

    public Material stage1;
    public Material stage2;
    public Material stage3;

    private bool breaking = false;

    public GameObject Platform;
    private void OnCollisionEnter(Collision collision)
    { 
        if (collision.gameObject.GetComponent<PlayerController>() && !breaking)
        {
            breaking = true;
            StartCoroutine(WaitToDestroy());

            
        }
    }

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
