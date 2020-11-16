using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSet : MonoBehaviour
{
    public GameObject bullet, bulletSpawn;
    public float ammo, alturaSpawn;
    public string commandShoot;
    public bool teledirigido = false;
    public bool noChargable = false;
    Vector3 mousePosInWorld;
    Vector3 mouseWorldPosition;
    Vector3 mousePosition;

    public void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition.z = 100;
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mouseWorldPosition.z = 0;
    }

    public void Shoot(float shootForce)
    {
        if(ammo >= 1)
        {
            GameObject newBullet = GameObject.Instantiate(bullet);
            if (newBullet.GetComponent<bulletSet>() != null)
            {
                if(teledirigido == true)
                {
                    bulletSet fals = newBullet.GetComponent<bulletSet>();
                    mousePosInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Vector3 falconSpawnPos = new Vector3(mousePosInWorld.x, mousePosInWorld.y + alturaSpawn, 0);
                    newBullet.transform.position = falconSpawnPos;
                    newBullet.transform.up = mousePosInWorld - falconSpawnPos;
                    fals.shootForce = shootForce;
                    ammo--;
                }
                else if (teledirigido == false)
                {
                    bulletSet bulls = newBullet.GetComponent<bulletSet>();
                    newBullet.transform.position = bulletSpawn.transform.position;
                    newBullet.transform.up = this.transform.up;
                    bulls.shootForce = shootForce;
                    ammo--;
                }
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
            else if(newBullet.GetComponent<GatoVolador>() != null)
            {
                GatoVolador bulls = newBullet.GetComponent<GatoVolador>();
                newBullet.transform.position = bulletSpawn.transform.position;
                newBullet.transform.up = this.transform.up;
                bulls.shootForce = shootForce;
                ammo--;
            }
            else if(newBullet.tag=="Domo" && teledirigido == true)
            {
                mousePosInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 falconSpawnPos = new Vector3(mousePosInWorld.x, mousePosInWorld.y + alturaSpawn, 0);
                newBullet.transform.position = falconSpawnPos;
                newBullet.transform.up = gameObject.GetComponentInParent<CharacterSet>().transform.up *-1;
                ammo--;
            }
            else if (newBullet.GetComponent<Botella>() != null)
            {
                newBullet.transform.position = bulletSpawn.transform.position;
                newBullet.transform.up = this.transform.up;
                ammo--;
            }
            else if (newBullet.GetComponent<Manifestantes>() != null)
            {
                newBullet.transform.position = bulletSpawn.transform.position;
                newBullet.transform.up = gameObject.GetComponentInParent<CharacterSet>().transform.up;
                if ((mouseWorldPosition - transform.position).x <= 0)
                {
                    newBullet.GetComponent<Manifestantes>().direction = -1;
                }
                else newBullet.GetComponent<Manifestantes>().direction = 1;
                ammo--;
            }

            Camera.main.GetComponent<CameraFollowScript>().SetFollow(newBullet);
        }
        ammo++;
    }
}
