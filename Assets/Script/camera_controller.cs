using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_controller : MonoBehaviour
{
    public Transform obj;

    void Update()
    {
        transform.position = new Vector3(obj.position.x, transform.position.y, -10);
    }
}
