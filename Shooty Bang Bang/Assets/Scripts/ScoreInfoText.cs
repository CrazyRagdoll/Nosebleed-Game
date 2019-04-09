using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreInfoText : MonoBehaviour
{
    public GameController gameInfo;
    public Text text;

    // Update is called once per frame
    void Update()
    {
        text.text = "LEVEL : " + gameInfo.level +
        "\nSCORE: " + gameInfo.score + 
        "\nENEMIES: " + gameInfo.enemyController.enemies.Count;
    }
}
