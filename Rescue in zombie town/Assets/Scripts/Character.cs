using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    private float moveSpeed = 5f;
    private float speedbala = 3f;

    public static Rigidbody2D rbchara;
    private Vector2 movement;

    public Rigidbody2D rbbalax;
    public GameObject balax;

    public Rigidbody2D rbbalay;
    public GameObject balay;

    public Rigidbody2D rbbaladiagxy;
    public GameObject baladiagxy;

    public Rigidbody2D rbbaladiagyx;
    public GameObject baladiagyx;

    private float lh;
    private float lv;

    public static float dirx = -1;
    public static float diry = 0;


    // Use this for initialization
    void Start()
    {
        rbchara = GetComponent<Rigidbody2D>();
        rbbalax = GetComponent<Rigidbody2D>();
        rbbalay = GetComponent<Rigidbody2D>();
        rbbaladiagxy = GetComponent<Rigidbody2D>();
        rbbaladiagyx = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //capturando el movimiento
        lh = Input.GetAxis("Horizontal");
        lv = Input.GetAxis("Vertical");

        //comprobando ultima direccion que ha visto para disparar
        //estos funcionan para los disparos horizontales
        if (lh > 0 && lv == 0)
        {
            dirx = 1;
            diry = 0;
        }
        if (lh < 0 && lv == 0)
        {
            dirx = -1;
            diry = 0;
        }
        //esto funciona para los disparos verticales
        if (lv > 0 && lh == 0)
        {
            dirx = 0;
            diry = 1;
        }
        if (lv < 0 && lh == 0)
        {
            dirx = 0;
            diry = -1;
        }
        //esto funciona para las diagonales /
        if (lh >= 0.5 && lv >= 0.5)
        {
            dirx = 1;
            diry = 1;
        }
        if (lh < -0.5 && lv < -0.5)
        {
            dirx = -1;
            diry = -1;
        }
        // esto funciona para las diagonales \
        if (lv >= 0.5 && lh <= -0.5)
        {
            dirx = -1;
            diry = 1;
        }
        if (lv <= -0.5 && lh >= 0.5)
        {
            dirx = 1;
            diry = -1;
        }



        //movimiento del personaje en X y Y
        movement = new Vector2(lh, lv);
        rbchara.transform.Translate(movement * moveSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump"))
        {
            if (dirx == 1 && diry == 0)
            {
                Instantiate(balax, new Vector3(rbchara.position.x, rbchara.position.y, 0), Quaternion.identity);
                rbbalax.transform.Translate(movement * speedbala * Time.deltaTime);
            }
            if (dirx == -1 && diry == 0)
            {
                Instantiate(balax, new Vector3(rbchara.position.x, rbchara.position.y, 0), Quaternion.identity);
                rbbalax.transform.Translate(movement * speedbala * Time.deltaTime);
            }
            if (diry == 1 && dirx == 0)
            {
                Instantiate(balay, new Vector3(rbchara.position.x, rbchara.position.y, 0), Quaternion.identity);
                rbbalay.transform.Translate(movement * speedbala * Time.deltaTime);
            }
            if (diry == -1 && dirx == 0)
            {
                Instantiate(balay, new Vector3(rbchara.position.x, rbchara.position.y, 0), Quaternion.identity);
                rbbalay.transform.Translate(movement * speedbala * Time.deltaTime);
            }
            if (diry == 1 && dirx == 1)
            {
                Instantiate(baladiagxy, new Vector3(rbchara.position.x, rbchara.position.y, 0), Quaternion.identity);
                rbbaladiagxy.transform.Translate(movement * speedbala * Time.deltaTime);
            }
            if (diry == -1 && dirx == -1)
            {
                Instantiate(baladiagxy, new Vector3(rbchara.position.x, rbchara.position.y, 0), Quaternion.identity);
                rbbaladiagxy.transform.Translate(movement * speedbala * Time.deltaTime);
            }
            if (dirx == -1 && diry == 1 )
            {
                Instantiate(baladiagyx, new Vector3(rbchara.position.x, rbchara.position.y, 0), Quaternion.identity);
                rbbaladiagyx.transform.Translate(movement * speedbala * Time.deltaTime);
            }
            if (diry == -1 && dirx == 1)
            {
                Instantiate(baladiagyx, new Vector3(rbchara.position.x, rbchara.position.y, 0), Quaternion.identity);
                rbbaladiagyx.transform.Translate(movement * speedbala * Time.deltaTime);
            }
        }

    }
}
