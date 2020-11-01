using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fondo_loop : MonoBehaviour
{
    public float MaxSpeed;
    public float speed;

    private void Start()
    {
        speed = Random.Range(-MaxSpeed, MaxSpeed);
    }
    // Update is called once per frame
    void Update()
    {
        GetComponent<MeshRenderer>().material.mainTextureOffset += Vector2.right * speed * Time.deltaTime;
   
    }

    public void ChangeRandomDirectionSpeed()
    {
        speed = Random.Range(-MaxSpeed, MaxSpeed);
    }

    
}