using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreReset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("z"))
        {
            PlayerPrefs.SetInt("highScore", 0);
        }
    }
}
