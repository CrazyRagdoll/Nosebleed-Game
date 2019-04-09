using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
#if UNITY_STANDALONE
        gameObject.SetActive(false);
#endif
#if UNITY_ANDROID || UNITY_IOS
        gameObject.SetActive(true);
#endif
    }
}
