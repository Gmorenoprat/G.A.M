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
        currentWeapon.transform.up = this.transform.up;
        currentWeapon.transform.parent = this.transform;
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

        if (destroyable.life <= 0)
        {
            GameObject.Destroy(this.gameObject);
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
            GameObject.Destroy(currentWeapon.gameObject);
            InvokeWeapon(3);
        }
    }

    void InvokeWeapon(int variable)
    {
        currentWeapon = GameObject.Instantiate(arrayWeapons[variable]);
        currentWeapon.transform.position = weaponSpawn.transform.position;
        currentWeapon.transform.up = this.transform.up;
        currentWeapon.transform.parent = this.transform;
    }

    public void Die()
    {
        Anim_Pinguin.Play("die");
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
        if (collision.gameObject.tag == "floor")
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
