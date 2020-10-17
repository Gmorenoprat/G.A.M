using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSet : MonoBehaviour
{
    public GameObject bullet, bulletSpawn;
    public float ammo;
    public string commandShoot;

    public void Shoot(float shootForce)
    {
        if(ammo >= 1)
        {
            GameObject newBullet = GameObject.Instantiate(bullet);
            if(newBullet.GetComponent<bulletSet>() != null)
            {
                bulletSet bulls = newBullet.GetComponent<bulletSet>();
                newBullet.transform.position = bulletSpawn.transform.position;
                newBullet.transform.up = this.transform.up;
                bulls.shootForce = shootForce;
                ammo--;
            } 
            else if (newBullet.GetComponent<granada>() != null)
            {
                granada bulls = newBullet.GetComponent<granada>();
                newBullet.transform.position = bulletSpawn.transform.position;
                newBullet.transform.up = this.transform.up;
                bulls.shootForce = shootForce;
                ammo--;
            }
            else if(newBullet.GetComponent<rayoSet>() != null)
            {
                rayoSet bulls = newBullet.GetComponent<rayoSet>();
                newBullet.transform.position = bulletSpawn.transform.position;
                newBullet.transform.up = this.transform.up;
                ammo--;
            }
        }
    }
}
