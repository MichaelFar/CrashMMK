using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Name: Michael Farrar
/// Description: Helper script that controls logic for displaying final score and lives
/// Date: 11/18/24
/// </summary>
public class FrameStars : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] hearts;

    public Sprite ActivatedStar;

    public Sprite DeactivatedStar;

    public int StarIndexToActivate = 0;

    /// <summary>
    /// Activates the star at the end of the list that is deactivated, increments the index that tracks this
    /// </summary>
    public void ActivateNextStar()
    {
        hearts[StarIndexToActivate].GetComponent<Image>().sprite = ActivatedStar;
        StarIndexToActivate++;
        Mathf.Clamp(StarIndexToActivate, 0, hearts.Length - 1);
    }
    /// <summary>
    /// Deactivates that last activated star and decrements the index that tracks this
    /// </summary>
    public void DeactivateLastStar()
    {
        print("Deactivating next star");
        hearts[StarIndexToActivate - 1].GetComponent<Image>().sprite = DeactivatedStar;
        StarIndexToActivate--;
        Mathf.Clamp(StarIndexToActivate, 0, hearts.Length - 1);
    }
}
