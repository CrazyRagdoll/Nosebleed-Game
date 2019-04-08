using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthInfoText : MonoBehaviour
{
    public GameController gameInfo;
    public Text text;

    // Update is called once per frame
    void Update()
    {
        text.text = "HEALTH: " + gameInfo.player.GetComponent<PlayerController>().health;
    }
}
