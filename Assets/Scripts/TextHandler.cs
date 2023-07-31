using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class TextHandler : MonoBehaviour
{
    private Text textbox;
    [SerializeField] private GameObject option1Text;
    [SerializeField] private GameObject option2Text;
    [SerializeField] private GameObject quarterObject;
    [SerializeField] private GameObject resultsQuarterObject;
    [SerializeField] private GameHandling gameHandler;

    private string filepath;
    private string option1Path;
    private string option2Path;
    private string targetText;
    private float letterPause = 0.05f;

    // which dialouge tree we're in
    private int index = 1;

    // Start is called before the first frame update
    void Start()
    {
        textbox = this.gameObject.GetComponent<Text>();
        textbox.text = "";

        filepath = Application.dataPath + "/Text/Speech1.txt";
        option1Path = Application.dataPath + "/Text/Options1-1.txt";
        option2Path = Application.dataPath + "/Text/Options1-2.txt";

        targetText = File.ReadAllText(filepath);

        quarterObject.GetComponent<Text>().text = "Q" + index + " 20XX";

        option1Text.GetComponentInChildren<Text>().text = File.ReadAllText(option1Path);
        option2Text.GetComponentInChildren<Text>().text = File.ReadAllText(option2Path);

        option1Text.SetActive(false);
        option2Text.SetActive(false);

        StartCoroutine(AutoText());
    }

    public void ChooseOption(int option)
    {
        option1Text.SetActive(false);
        option2Text.SetActive(false);

        filepath = Application.dataPath + "/Text/Speech" + index + "-" + option + ".txt";
        targetText = File.ReadAllText(filepath);

        StartCoroutine(AutoTextNoOptions());
    }

    public void AdvanceQuarter()
    {
        index += 1;
        if (index > 4)
        {
            index = 4;
        }

        filepath = Application.dataPath + "/Text/Speech" + index + ".txt";
        targetText = File.ReadAllText(filepath);

        quarterObject.GetComponent<Text>().text = "Q" + index + " 20XX";
        resultsQuarterObject.GetComponent<Text>().text = "Q" + index + " 20XX REVIEW";
                
        option1Path = Application.dataPath + "/Text/Options" + index + "-1.txt";
        option2Path = Application.dataPath + "/Text/Options" + index + "-2.txt";

        option1Text.GetComponentInChildren<Text>().text = File.ReadAllText(option1Path);
        option2Text.GetComponentInChildren<Text>().text = File.ReadAllText(option2Path);
    }

    IEnumerator AutoText()
    {
        foreach (char letter in targetText.ToCharArray())
        {
            textbox.text += letter;

            yield return new WaitForSeconds (letterPause);
        }
        
        option1Text.SetActive(true);
        option2Text.SetActive(true);

        yield return null;
    }

    IEnumerator AutoTextNoOptions()
    {
        textbox.text = "";

        foreach (char letter in targetText.ToCharArray())
        {
            textbox.text += letter;

            yield return new WaitForSeconds (letterPause);
        }

        gameHandler.FadeOut();

        yield return null;
    }
}
