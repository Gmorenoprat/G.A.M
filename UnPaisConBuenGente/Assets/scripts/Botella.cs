using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botella : MonoBehaviour
{
    public bool picked;
    public Rigidbody2D rb;
    static public Vector3 mousePositionInWorld;
    public float durationTime = 4.5f;
    private Color alphaColor;
    private float timeToFade = 5f;
    private float timeToDestroy = 2f;
    public int damage = 2 ;

    public int makeDaño = 14;

    public GameObject mira;
    public AudioSource pow;

    // Start is called before the first frame update

    private void Awake()
    {
        this.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

        mira = GameObject.FindWithTag("Mira");
        mira.GetComponent<Mira>().desactivarPorSegundos(durationTime);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mousePositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePositionInWorld.z = 0;

        picked = true;

        if (picked == true)
        {
            rb.velocity = (mousePositionInWorld - this.transform.position) * 15;
        }

        durationTime -= Time.deltaTime;
        if (durationTime <= 0)
        {
            this.GetComponent<SpriteRenderer>().color = Color.Lerp(this.GetComponent<SpriteRenderer>().color, alphaColor, timeToFade * Time.deltaTime);
            timeToDestroy -= Time.deltaTime;
            if (timeToDestroy <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnMouseDown()
    {
        picked = true;
    }

    private void OnMouseUp()
    {
        picked = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != makeDaño) return; //daño
        collision.gameObject.GetComponent<DestroyableComp>().getDamage(damage);
        pow.Play(0);
    }
}
