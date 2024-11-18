using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIElements : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject HUDRoundEndFrame;
    private void Start()
    {
        ToggleRoundEndFrame();
    }

    public void CallNextLevel()
    {
        LevelTransitionSingleton.GoToNextLevel();
    }
    public void CallReplayLevel()
    {
        LevelTransitionSingleton.ReplayLevel();
    }

    public void ToggleRoundEndFrame()
    {
        HUDRoundEndFrame.SetActive(!HUDRoundEndFrame.activeSelf);
    }
}
