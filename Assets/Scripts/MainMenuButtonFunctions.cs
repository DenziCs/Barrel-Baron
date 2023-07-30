using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButtonFunctions : MonoBehaviour
{
    [SerializeField] private Image blackout;
    private bool isFadingOut = false;

    // Update is called once per frame
    void Update()
    {
        if (isFadingOut)
        {
            Color currentColor = blackout.color;
            currentColor.a += Time.deltaTime;
            blackout.color = currentColor;
            if(currentColor.a >= 1.0f)
            {
                isFadingOut = false;
                ChangeScene();
            }
        }
    }

    public void StartGame()
    {
        blackout.gameObject.SetActive(true);
        isFadingOut = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToLink(string url)
    {
        Application.OpenURL(url);
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}