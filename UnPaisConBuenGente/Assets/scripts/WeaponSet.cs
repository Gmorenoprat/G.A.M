using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSet : MonoBehaviour
{
    public GameObject bullet, bulletSpawn;
    public float ammo;
    public string commandShoot;

    public void Shoot()
    {
        if(ammo >= 1)
        {
            GameObject newBullet = GameObject.Instantiate(bullet);
            newBullet.transform.position = bulletSpawn.transform.position;
            newBullet.transform.up = this.transform.up;
            ammo--;
        }
    }
}
