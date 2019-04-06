using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject CameraTarget;

    //Gonna hard code some boundaries so the camera doesnt look outside of the world
    float maxX, minX, maxY, minY;

    void Start()
    {
        minX = -13.8f;
        maxX = 13.8f;
        minY = -1.97f;
        maxY = 5.76f;
    }

    // Update is called once per frame
    void Update()
    {
        //Update the cameras position based on the player position!
        //Doing some simple checks so that the camera doesnt move off the "world"
        Vector3 targetPos = CameraTarget.GetComponent<Transform>().position;
        Vector3 newPos = targetPos + new Vector3(0.0f, 0.0f, -10.0f);

        //boundary checks
        if (targetPos.x < minX) newPos.x = minX;
        if (targetPos.x > maxX) newPos.x = maxX;
        if (targetPos.y < minY) newPos.y = minY;
        if (targetPos.y > maxY) newPos.y = maxY;

        //Update camera pos!
        transform.position = newPos;
    }
}
