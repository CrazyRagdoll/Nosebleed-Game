using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelInfoText : MonoBehaviour
{
    public GameController gameInfo;
    public Text text;

    // Update is called once per frame
    void Update()
    {
        if (gameInfo.levelTimer > 0)
        {
            GetComponent<Text>().enabled = true;
            text.text = "NEXT LEVEL IN " + (5 - (int)gameInfo.levelTimer);
        } else
        {
            GetComponent<Text>().enabled = false;
        }
    }
}
