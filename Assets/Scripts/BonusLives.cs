using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using Unity.VisualScripting;

[System.Serializable]
public class MyIntEvent : UnityEvent<int>
{
}

public class BonusLives : MonoBehaviour
{
    /* Mateo Jimenez
     * 11/7/2024
     * player will get a bomus life if player collects 100 fruit
     */

    //displayed player score
    public int totalFruit = 0;

    //count for adding lives after reaching 100
    public int countFruit = 0;

    public int fruitValue = 1;

    public MyIntEvent updatedScore;
    public MyIntEvent updatedLives;

    public GameObject ScoreText;

    

    public TextMeshPro UI;

    

    private void Start()
    {
        ScoreText.GetComponent<TextMeshProUGUI>().text = "" + totalFruit;

    }
    //player picks up fruit, adds to score and checks if has collected 100
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<WumpaFruit>())
        {
            Destroy(collision.gameObject);

            addScore();
            addCount();

            //if player reraches 100 add one life and reset the count
            if (countFruit == 100)
            {
                gameObject.GetComponent<PlayerLives>().addLives(1);
                countFruit = 0;
                updatedLives.Invoke(1);
            }

        }
    }

    public void addScore()
    {
        totalFruit += fruitValue;
        ScoreText.GetComponent<TextMeshProUGUI>().text = "" + totalFruit;
    }

    public void addCount()
    {
        countFruit += fruitValue;
    }


}
