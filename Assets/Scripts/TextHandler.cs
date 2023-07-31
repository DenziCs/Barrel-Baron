using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class TextHandler : MonoBehaviour
{
    private Text textbox;
    private string filepath;
    private string option1path;
    private string option2path;
    private string targetText;
    private float letterPause = 0.05f;

    // which dialouge tree we're in
    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        textbox = this.gameObject.GetComponent<Text>();
        textbox.text = "";

        filepath = Application.dataPath + "/Text/Speech1.txt";

        targetText = File.ReadAllText(filepath);

        StartCoroutine(AutoText());
    }

    void ChooseOption(int option)
    {

    }

    IEnumerator AutoText()
    {
        foreach (char letter in targetText.ToCharArray())
        {
            textbox.text += letter;

            yield return new WaitForSeconds (letterPause);
        }
        
        yield return null;
    }
}
