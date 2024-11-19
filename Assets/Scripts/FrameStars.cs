using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FrameStars : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] hearts;

    public Sprite ActivatedStar;

    public Sprite DeactivatedStar;

    public int StarIndexToActivate = 0;

    public void ActivateNextStar()
    {
        hearts[StarIndexToActivate].GetComponent<Image>().sprite = ActivatedStar;
        StarIndexToActivate++;
        Mathf.Clamp(StarIndexToActivate, 0, hearts.Length - 1);
    }
    public void DeactivateLastStar()
    {
        print("Deactivating next star");
        hearts[StarIndexToActivate - 1].GetComponent<Image>().sprite = DeactivatedStar;
        StarIndexToActivate--;
        Mathf.Clamp(StarIndexToActivate, 0, hearts.Length - 1);
    }
}
