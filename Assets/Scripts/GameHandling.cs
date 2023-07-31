using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandling : MonoBehaviour
{
    [SerializeField] private Image blackout;
    [SerializeField] private Image resultPopup;

    [SerializeField] private Image moneyMeter;
    [SerializeField] private Image boardMeter;

    private bool isFadingIn = false;
    private bool isFadingOut = false;

    // Start is called before the first frame update
    void Start()
    {
        resultPopup.gameObject.SetActive(false);
        FadeIn();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFadingIn)
        {
            Color currentColor = blackout.color;
            currentColor.a -= Time.deltaTime;
            blackout.color = currentColor;
            if (currentColor.a <= 0.0f)
            {
                blackout.gameObject.SetActive(false);
                isFadingIn = false;
            }
        }

        if (isFadingOut)
        {
            Color currentColor = blackout.color;
            currentColor.a += Time.deltaTime;
            blackout.color = currentColor;
            if (currentColor.a >= 1.0f)
            {
                isFadingOut = false;
            }
        }
    }

    public void AddMoney()
    {
        moneyMeter.fillAmount += 0.25f;
    }

    public void AddBoard()
    {
        boardMeter.fillAmount += 0.25f;
    }

    public void ReduceMoney()
    {
        moneyMeter.fillAmount -= 0.25f;
    }

    public void ReduceBoard()
    {
        boardMeter.fillAmount -= 0.25f;
    }

    public void FadeIn()
    {
        isFadingIn = true;
    }

    public void FadeOut()
    {
        blackout.gameObject.SetActive(true);
        resultPopup.gameObject.SetActive(true);
        isFadingOut = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}