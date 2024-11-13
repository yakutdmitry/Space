using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    public Transform CamPosition;

    void Update()
    {
        transform.position = CamPosition.position;
    }
}
