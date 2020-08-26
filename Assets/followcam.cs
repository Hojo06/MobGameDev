//Holton Johnson
//follow the player's x position,
//but not anything else


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followcam : MonoBehaviour
{
    [Tooltip("The object you want to follow.")]
    public Transform target;

    // the starting position of the camera
    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        //save the starting position of the camera
        startPos = this.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // get the position of the target but keep the starting y and z positions.
        Vector3 newPos = new Vector3(target.position.x, startPos.y, startPos.z);

        // assign the new position to this camera.
        this.transform.position = newPos;
    }
}
