using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingHandler : MonoBehaviour
{
    [SerializeField] private bool isWinScene;
    [SerializeField] private Image blackout;
    [SerializeField] private Text textbox;
    [SerializeField] private GameObject button1;
    [SerializeField] private Text endText;
    [SerializeField] private GameObject theEnd;
    [SerializeField] private GameObject endButton;
    [SerializeField] private GameObject popup;

    private bool isFadingIn = false;
    private bool isFadingOut = false;

    private string winDialogue = "So, you've just finished your first year as CEO. The Board of Directors believes you've been doing a fine job. Keep up the good work.";
    private string lossDialogue = "So, you've just finished your first year as CEO. Unfortunately, the Board of Directors has not been impressed by your performance. You are being demoted.";
    private string endDialogueW = "You managed to keep your job as CEO! Congratulations!";
    private string endDialogueL = "You disappointed the Board and got demoted. Game Over.";
    private float letterPause = 0.05f;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        FadeIn();
        button1.SetActive(false);
        theEnd.SetActive(false);
        endButton.SetActive(false);
        popup.SetActive(false);

        audioSource = this.gameObject.GetComponent<AudioSource>();

        StartCoroutine(AutoText());
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

    public void FadeIn()
    {
        isFadingIn = true;
    }

    public void FadeOut()
    {
        blackout.gameObject.SetActive(true);
        popup.SetActive(true);
        isFadingOut = true;
        StartCoroutine(AutoTextEnd());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    IEnumerator AutoText()
    {
        textbox.text = "";

        if (isWinScene)
        {
            foreach (char letter in winDialogue.ToCharArray())
            {
                textbox.text += letter;

                audioSource.PlayOneShot(audioSource.clip);

                if (letter == '.' || letter == '?' || letter == '!')
                {
                    yield return new WaitForSeconds (1.2f);
                }

                yield return new WaitForSeconds(letterPause);
            }
        }

        else
        {
            foreach (char letter in lossDialogue.ToCharArray())
            {
                textbox.text += letter;

                audioSource.PlayOneShot(audioSource.clip);

                if (letter == '.' || letter == '?' || letter == '!')
                {
                    yield return new WaitForSeconds (1.2f);
                }

                yield return new WaitForSeconds(letterPause);
            }
        }

        button1.SetActive(true);

        yield return null;
    }

    IEnumerator AutoTextEnd()
    {
        endText.text = "";

        if (isWinScene)
        {
            foreach (char letter in endDialogueW.ToCharArray())
            {
                endText.text += letter;

                audioSource.PlayOneShot(audioSource.clip);

                if (letter == '.' || letter == '?')
                {
                    yield return new WaitForSeconds(1.2f);
                }

                yield return new WaitForSeconds(letterPause);
            }
        }

        else
        {
            foreach (char letter in endDialogueL.ToCharArray())
            {
                endText.text += letter;

                audioSource.PlayOneShot(audioSource.clip);

                if (letter == '.' || letter == '?')
                {
                    yield return new WaitForSeconds(1.2f);
                }

                yield return new WaitForSeconds(letterPause);
            }
        }

        theEnd.SetActive(true);
        endButton.SetActive(true);

        yield return null;
    }
}