using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Name: Michael Farrar
/// Description: Hooks into the UI buttons and activates the end screen
/// Date: 11/18/24
/// </summary>
public class UIElements : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject HUDRoundEndFrame;

    public GameObject player;

    public GameObject FinalScoreStars;
    private void Start()
    {
        //ToggleRoundEndFrame();
    }
    /// <summary>
    /// Calls the LevelTransitionSingleton to go to the next level
    /// </summary>
    public void CallNextLevel()
    {
        LevelTransitionSingleton.GoToNextLevel();
    }
    /// <summary>
    /// Calls the LevelTransitionSingleton to repeat the level
    /// </summary>
    public void CallReplayLevel()
    {
        LevelTransitionSingleton.ReplayLevel();
    }
    /// <summary>
    /// Toggles the end screen
    /// </summary>
    public void ToggleRoundEndFrame()
    {
        HUDRoundEndFrame.SetActive(!HUDRoundEndFrame.activeSelf);
    }
    
}
