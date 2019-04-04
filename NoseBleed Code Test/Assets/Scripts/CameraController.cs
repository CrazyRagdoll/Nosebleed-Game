using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    GameObject CameraTarget;

    // Update is called once per frame
    void Update()
    {
        //Simple follow the player for now
        transform.position = new Vector3(CameraTarget.GetComponent<Transform>().position.x, 
                                        CameraTarget.GetComponent<Transform>().position.y, 
                                        -10.0f);
    }
}
