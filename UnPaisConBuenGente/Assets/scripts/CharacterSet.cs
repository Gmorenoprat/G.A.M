using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterSet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed, horizontal, jumpForce, maxJump, avJump;
    public Vector3 face;
    public bool onAir;
    public GameObject weaponSpawn, weapon, currentWeapon;
    public DestroyableComp destroyable;
    public Animator Anim_Pinguin;
    public SpriteRenderer MainSprite;
    public Transform Head;
    public TextMeshPro nombreCharacter;

    public GameObject[] arrayWeapons;
    public Buitre buitre;

    public bool permission;

    void Start()
    {
        MainSprite = this.GetComponent<SpriteRenderer>();
        Head = this.GetComponent<Transform>();
        Anim_Pinguin = this.GetComponent<Animator>();
        destroyable = this.GetComponent<DestroyableComp>();
        rb = this.GetComponent<Rigidbody2D>();
        face = this.transform.right;

        currentWeapon = GameObject.Instantiate(arrayWeapons[0]);
        currentWeapon.transform.position = weaponSpawn.transform.position;
        currentWeapon.transform.parent = this.transform;

        permission = false;
    }

    public void Update()
    {
        if (horizontal < 0)
        {
            MainSprite.flipX = true;
        }
        else if (horizontal > 0)
        {
            MainSprite.flipX = false;
        }

        Anim_Pinguin.SetFloat("walk speed", Mathf.Abs(horizontal));
        Anim_Pinguin.SetFloat("jump", rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameObject.Destroy(currentWeapon.gameObject);
            InvokeWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameObject.Destroy(currentWeapon.gameObject);
            InvokeWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GameObject.Destroy(currentWeapon.gameObject);
            InvokeWeapon(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (permission == true)
            {
                GameObject.Destroy(currentWeapon.gameObject);
                InvokeWeapon(3);
            }
            else
            {
                Debug.Log("todavia faltan " + gameObject.GetComponent<SpecialCoolDown>().coolDown + " turnos, " + nombreCharacter.text);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            try
            {
                ActivarDesactivarBuitre(!buitre.gameObject.activeSelf);
            }
            catch
            {
                Debug.Log("BuitreNotFOund");
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            GameObject.Destroy(currentWeapon.gameObject);
            InvokeWeapon(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            GameObject.Destroy(currentWeapon.gameObject);
            InvokeWeapon(5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            GameObject.Destroy(currentWeapon.gameObject);
            InvokeWeapon(6);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            GameObject.Destroy(currentWeapon.gameObject);
            InvokeWeapon(7);
        }
    }

    void InvokeWeapon(int variable)
    {
        currentWeapon = GameObject.Instantiate(arrayWeapons[variable]);
        currentWeapon.transform.position = weaponSpawn.transform.position;
        currentWeapon.transform.up = this.transform.up;
        currentWeapon.transform.parent = this.transform;
    }

    public void ActivarDesactivarBuitre(bool activar)
    {
        if (!buitre) return;
        buitre.gameObject.SetActive(activar);//!buitre.gameObject.activeSelf);
    }

    public void Die()
    {
        Anim_Pinguin.Play("die");
        FindObjectOfType<conditionWiner>().lifeDown(gameObject);
        GameObject.Destroy(this.gameObject);
    }

    public void Move(float dirX)
    {
        horizontal = dirX;

        Vector3 realVelocity;
        realVelocity.x = speed * horizontal;
        realVelocity.y = rb.velocity.y;
        realVelocity.z = 0;

        rb.velocity = realVelocity;
    }

    public void Jump()
    {
        if (avJump > 0 && onAir == false)
        {
            Anim_Pinguin.Play("jump");
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.up * jumpForce * rb.gravityScale * rb.mass, ForceMode2D.Impulse);
            avJump--;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor" || collision.gameObject.tag == "Player")
        {
            avJump = maxJump;
            onAir = false;
            this.transform.parent = collision.transform;
            Anim_Pinguin.Play("movement");
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            onAir = true;
            this.transform.parent = null;
        }
    }
}
