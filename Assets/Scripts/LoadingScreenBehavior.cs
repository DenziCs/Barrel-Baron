using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreenBehavior : MonoBehaviour
{
    [SerializeField] Image blackout;
    private float timer = 8.5f;

    // Start is called before the first frame update
    void Start()
    {
        timer = 8.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0.0f) timer -= Time.deltaTime;
        else
        {
            Color currentColor = blackout.color;
            currentColor.a += Time.deltaTime;
            blackout.color = currentColor;
            if (currentColor.a >= 1.0f)
            {
                SceneManager.LoadScene("GameScene");
            }
        }
    }
}