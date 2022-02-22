using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    public TextMeshProUGUI current;
    public TextMeshProUGUI high;

    // Start is called before the first frame update
    void Start()
    {
        current.text = "YOUR SCORE: " + PlayerPrefs.GetInt("currentScore").ToString();
        high.text = "HIGH SCORE: " + PlayerPrefs.GetInt("highScore").ToString();
    }
}
