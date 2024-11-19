using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelTransitionSingleton
{
    // Start is called before the first frame update
    //public static LevelTransitionSingleton LevelTransition {get; private set;}

    private static int NextLevelIndex = 1;

    public static void GoToNextLevel()
    {
        
        SceneManager.LoadScene(NextLevelIndex);

        NextLevelIndex += 1;

        if(NextLevelIndex == 4)
        {
            NextLevelIndex = 0;
        }
    }

    public static void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
