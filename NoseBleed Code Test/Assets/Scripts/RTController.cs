using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        float newHeight = Camera.main.orthographicSize * 0.2f;
        float newWidth = newHeight * Screen.width / Screen.height;

        //Fit the rendered texture to the screen size...
        transform.localScale = new Vector3(newWidth, 1.0f, newHeight);
    }
}
