using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public Transform follow;
    public Vector2 minCamPos, maxCamPos;
    float smoothTimeX, smoothTimeY;
    public float smoothTimeShootX, smoothTimeShootY;
    public float smoothTimeTurnX, smoothTimeTurnY;
    private Vector2 velocity;

    void LateUpdate()
    {
        if (follow != null)
        {
            if (follow.tag == "Player")
            {
                smoothTimeX = smoothTimeTurnX;
                smoothTimeY = smoothTimeTurnY;
            }
            else
            {
                smoothTimeX = smoothTimeShootX;
                smoothTimeY = smoothTimeShootY;
            }

            float posX = Mathf.SmoothDamp(this.transform.position.x, follow.transform.position.x, ref velocity.x, smoothTimeX);
            float posY = Mathf.SmoothDamp(this.transform.position.y, follow.transform.position.y, ref velocity.y, smoothTimeY);

            try
            {
                this.gameObject.transform.position = new Vector3(Mathf.Clamp(posX, minCamPos.x, maxCamPos.x), Mathf.Clamp(posY, minCamPos.y, maxCamPos.y), transform.position.z);
            }
            catch { }
        }
    }

    internal void SetFollow(GameObject follow)
    {
        this.follow = follow.transform;
    }
}

