using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
public class Timer : MonoBehaviour
{
    float timeLeft = 60.0f;
    public Text txt;
    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        txt.text = "Tiempo: " + timeLeft;
        if (timeLeft < 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}