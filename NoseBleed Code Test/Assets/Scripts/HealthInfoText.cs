using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthInfoText : MonoBehaviour
{
    public PlayerController playerInfo;
    public Text text;

    // Update is called once per frame
    void Update()
    {
        text.text = "HEALTH: " + playerInfo.Health;
    }
}
