using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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

    private Animator anim;

    private float lh;
    private float lv;

    public static float dirx = -1;
    public static float diry = 0;

    public float animx = 0;
    public float animy = 0;

    protected Joystick joystick;

    // Use this for initialization
    void Start()
    {
        rbchara = GetComponent<Rigidbody2D>();
        rbbalax = GetComponent<Rigidbody2D>();
        rbbalay = GetComponent<Rigidbody2D>();
        rbbaladiagxy = GetComponent<Rigidbody2D>();
        rbbaladiagyx = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        joystick = FindObjectOfType<Joystick>();


    }

    // Update is called once per frame
    void Update()
    {
        //capturando el movimiento
        lh = joystick.Horizontal + Input.GetAxis("Horizontal");
        lv = joystick.Vertical + Input.GetAxis("Vertical");

        //comprobando ultima direccion que ha visto para disparar
        //esto funciona para las diagonales /
        if (lh >= 0.5 && lv >= 0.5)
        {
            dirx = 1;
            diry = 1;
        }
        else
        {
            if (lh < -0.5 && lv < -0.5)
            {
                dirx = -1;
                diry = -1;
            }
            else
            {
                // esto funciona para las diagonales \
                if (lv >= 0.5 && lh <= -0.5)
                {
                    dirx = -1;
                    diry = 1;
                }
                else
                {
                    if (lv <= -0.5 && lh >= 0.5)
                    {
                        dirx = 1;
                        diry = -1;
                    }
                    else
                    {
                        //estos funcionan para los disparos horizontales
                        if (lh > 0 && lh >= Mathf.Abs(lv))
                        {
                            dirx = 1;
                            diry = 0;
                        }
                        else
                        {
                            if (lh < 0 && Mathf.Abs(lh) >= Mathf.Abs(lv))
                            {
                                dirx = -1;
                                diry = 0;
                            }
                            else
                            {
                                //esto funciona para los disparos verticales
                                if (lv > 0 && lv >= Mathf.Abs(lh))
                                {
                                    dirx = 0;
                                    diry = 1;
                                }
                                else
                                {
                                    if (lv < 0 && Mathf.Abs(lv) >= Mathf.Abs(lh))
                                    {
                                        dirx = 0;
                                        diry = -1;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        
        animy = diry;
        animx = dirx;

        if (lv == 0 && lh == 0)
        {

            animy = 0;
            animx = 0;
        }

        anim.SetFloat("speedy", animy);

        //movimiento del personaje en X y Y
        movement = new Vector2(lh, lv);
        rbchara.transform.Translate(movement * moveSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump"))
        {
            shoot();
        }


        animy = 0;
        animx = 0;

    }

    public void shoot()
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
        if (dirx == -1 && diry == 1)
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
