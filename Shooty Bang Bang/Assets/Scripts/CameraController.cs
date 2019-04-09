using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameController gameController;

    //Gonna hard code some boundaries so the camera doesnt look outside of the world
    float maxX, minX, maxY, minY;

    Transform player;

    private void Awake()
    {
        player = gameController.player.transform;
    }

    void Start()
    {
        //Hard coded world parameters 
        minX = -15.0f;
        maxX = 15.0f;
        minY = -2.0f;
        maxY = 5.76f;
    }

    // Update is called once per frame
    void Update()
    {
        //Update the cameras position based on the player position!
        //Doing some simple checks so that the camera doesnt move off the "world"
        Vector3 targetPos = player.position;
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
