using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroHandler : MonoBehaviour
{
    [SerializeField] private Image blackout;
    [SerializeField] private Text textbox;
    [SerializeField] private GameObject button1;
    [SerializeField] private GameObject button2;

    private AudioSource audioSource;

    private bool isFadingIn = false;
    private bool isFadingOut = false;

    private string introDialogue = "Welcome to your first day as CEO of BarrelCo, sir! The board will be checking in with you every quarter to judge your decisions.";
    private float letterPause = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        FadeIn();
        button1.SetActive(false);
        button2.SetActive(false);
        
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
                SceneManager.LoadScene("GameScene");
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
        isFadingOut = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator AutoText()
    {
        textbox.text = "";

        foreach (char letter in introDialogue.ToCharArray())
        {
            textbox.text += letter;

            audioSource.PlayOneShot(audioSource.clip);

            if (letter == '.' || letter == '?' || letter == '!')
            {
                yield return new WaitForSeconds (1.2f);
            }

            yield return new WaitForSeconds(letterPause);
        }

        button1.SetActive(true);
        button2.SetActive(true);

        yield return null;
    }
}