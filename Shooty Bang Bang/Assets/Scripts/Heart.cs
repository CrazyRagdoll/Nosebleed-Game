using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    float anim;

    // Update is called once per frame
    void Update()
    {
        anim += 0.05f;
        transform.localPosition += new Vector3(0.0f, (Mathf.Cos(anim) / 50), 0.0f);
    }
}
