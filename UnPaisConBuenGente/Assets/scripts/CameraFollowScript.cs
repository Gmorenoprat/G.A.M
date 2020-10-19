using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public Transform Follow;
    public Vector3 Offset;

    void LateUpdate()
    {
        if (Follow != null)
            transform.position = Follow.position + Offset;
    }

    internal void SetFollow(GameObject follow)
    {
        Follow = follow.transform;
    }

    internal void SetOffset(Vector3 vector3) => Offset = vector3;
}

