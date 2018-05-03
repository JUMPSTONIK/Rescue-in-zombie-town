using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    private float moveSpeed = 5f;
    private float speedbala = 3f;

    public static Rigidbody2D rbchara;
    private Vector2 movement;

    public Rigidbody2D rbbalax;
    public GameObject balax;

    public Rigidbody2D rbbalay;
    public GameObject balay;

    public static bool lhxmas = false;
    public static bool lhxmen = false;
    public static bool lvymas = false;
    public static bool lvymen = false;
    public static bool fire = false;


    public static float dirx = -1;
    public static float diry = 0;


    // Use this for initialization
    void Start()
    {
        rbchara = GetComponent<Rigidbody2D>();
        rbbalax = GetComponent<Rigidbody2D>();
        rbbalay = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //comprobando ultima direccion que ha visto para disparar
        if (lhxmas == true)
        {
            dirx = 1;
            diry = 0;
            
        }
        if (lhxmen == true)
        {
            dirx = -1;
            diry = 0;
            
        }
        if (lvymas == true)
        {
            dirx = 0;
            diry = 1;
            
        }
        if (lvymen == true)
        {
            dirx = 0;
            diry = -1;
            
        }

        //movimiento del personaje en X y Y

        if (lhxmas == true || lhxmen == true || lvymas == true || lvymen == true)
        {
            movement = new Vector2(dirx, diry);
            rbchara.transform.Translate(movement * moveSpeed * Time.deltaTime);
        }
        //disparo de la bala en el eje x

        if (fire == true)
        {
            if (dirx > 0 || dirx < 0)
            {
                    Instantiate(balax, new Vector3(rbchara.position.x, rbchara.position.y, 0), Quaternion.identity);
                    rbbalax.transform.Translate(movement * speedbala * Time.deltaTime);
            }
            fire = false;
        }

        //disparo de la bala en el eje y
        if (fire == true)
        {
            if (diry > 0 || diry < 0)
            {
                Instantiate(balay, new Vector3(rbchara.position.x, rbchara.position.y, 0), Quaternion.identity);
                rbbalay.transform.Translate(movement * speedbala * Time.deltaTime);
            }
            fire = false;
        }

        lvymen = false;
        lvymas = false;
        lhxmen = false;
        lhxmas = false;

    }
}
