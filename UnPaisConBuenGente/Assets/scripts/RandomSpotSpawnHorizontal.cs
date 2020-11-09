using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpotSpawnHorizontal : MonoBehaviour
{
    public List<Vector3> positionSpawns;

    private void Start()
    {
        positionSpawns.Add(new Vector3(-45.5f, 8.30f, 0f));
        positionSpawns.Add(new Vector3(-40f,  0f, 0f));
        positionSpawns.Add(new Vector3(-34f, -11f, 0f));
        positionSpawns.Add(new Vector3(-30f, 1f,0f));
        positionSpawns.Add(new Vector3(-23f, 1.5f, 0f));
        positionSpawns.Add(new Vector3(-18f, 3.7f, 0f));
        positionSpawns.Add(new Vector3(-12.5f, -7f, 0f));
        positionSpawns.Add(new Vector3(-3f, -4.5f, 0f));
        positionSpawns.Add(new Vector3(5f, 2.5f, 0f));
        positionSpawns.Add(new Vector3(9.5f, 10.5f, 0f));
        positionSpawns.Add(new Vector3(15.5f, 5.5f, 0f));
    }

    public Vector3 getSpawn()
    {
        int rand = Random.Range(0, positionSpawns.Count);
        Vector3 vect = positionSpawns[rand];
        positionSpawns.Remove(positionSpawns[rand]);
        return vect;
    }

}
