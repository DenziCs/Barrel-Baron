using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandling : MonoBehaviour
{
    [SerializeField] private Image blackout;

    [SerializeField] private Image speechBubbleStem;
    [SerializeField] private Text speechBubble;
    // [SerializeField] private Text dialogueOption1;
    // [SerializeField] private Text dialogueOption2;

    [SerializeField] private GameObject button1;
    [SerializeField] private GameObject button2;

    // private Text bubbleText;
    // filepath of text
    //private string[] filePath;
    //private int lineIndex = 0;
    //private int dialogueID = 0;

    private bool isFadingIn = false;
    private bool isFadingOut = false;
    private bool isTalking = false;

    // Start is called before the first frame update
    void Start()
    {
        /*
        for (int i = 0; i < 12; i++)
        {
            filePath[i] = Application.dataPath + "/Text/Speech" + (i + 1) + ".txt";
        }
        */
        speechBubble = GameObject.Find("Speech Bubble").GetComponent<Text>();
        Debug.Log("Found gameObject with name " + speechBubble.gameObject.name);
        //speechBubble.gameObject.SetActive(false);
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
                //speechBubbleStem.gameObject.SetActive(true);
                speechBubble.gameObject.SetActive(true);
                isTalking = true;
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

        /*if (isTalking)
        {
            Color currentColor = speechBubbleStem.color;
            currentColor.a += Time.deltaTime;
            speechBubbleStem.color = currentColor;
            //speechBubble1.color = currentColor;
            if (currentColor.a >= 1.0f)
            {
                isTalking = false;
                button1.SetActive(true);
                button2.SetActive(true);
            }
        }*/
    }

    public void ChangeDialogue(bool isOption1)
    {
        
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
}