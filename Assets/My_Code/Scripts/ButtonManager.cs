using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    public CanvasGroup canvasGroup;

    void Start()
    {
        HideCanvasImage();
    }

    public void StartGameBtn(string gameLevel)
    {
        SceneManager.LoadScene(gameLevel);
    }

    public void ExitGameBtn(string gameLevel)
    {
        SceneManager.LoadScene(gameLevel);
    }

    public void HowToPlayGameBtn(string gameLevel)
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;

    }



    //hide the hoToPlay Image and forbid input events
    public void HideCanvasImage()
    {
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
    }
}
