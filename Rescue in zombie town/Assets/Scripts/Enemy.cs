using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float VisionRadio;
    public float speed = 3f;
    public float speedR = 20;
    public Vector3 target;
    GameObject player;
    private float movetime = 0;
    private Vector2 movimiento;
    Rigidbody2D rb;

    private Animator anim;
    public float animx = 0;
    public float animy = 0;
    public mounsterSpawner MS;

    public float x;
    public float y;
    public Character val;

    // Use this for initialization
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

        //esto es para instanciar en este punto el comportamiendo del movimiento aleatorio que tendra
        if (movetime <0.1)
        {
            x = Random.Range(10, -10);
            y = Random.Range(10, -10);
            //varialbles de control de la animacion
            animx = x/ Mathf.Abs(x);
            animy = y/ Mathf.Abs(y);
            //con esto instancio la variable vector que movera al enemigo
            movimiento = new Vector2(x/Mathf.Abs(x) * Time.deltaTime, y/ Mathf.Abs(y) * Time.deltaTime);

        }
        //Mando parametros a las variables de la animacion
        anim.SetFloat("speedy", animy);
        anim.SetFloat("speedx", animx);

        //variable de distancia entre el enemigo y el personaje principal
        float dist = Vector3.Distance(player.transform.position, transform.position);

        //verifica si la distancia es menor a la de vision de radio donde comenzara a perseguir al enemigo
        if (dist < VisionRadio)
        {
            //obteniendo posicion del jugador
            target = player.transform.position;
            //velocidad para el enemigo
            float fixedspeed = speed * Time.deltaTime;

            //aqui se genera el movimiento de persecucion del enemigo hacia el player
            Vector3 movobjetivo = Vector3.MoveTowards(transform.position, target, fixedspeed);

            
            transform.position = movobjetivo;
            
        }
        else
        {
            //en el caso que no este el player en el rango de vision, pues se genera este movimiento
            if (movetime <3)
            {
                transform.Translate(movimiento * speedR * Time.deltaTime);
            }
            else
            {
                movetime = 0;
            }
            
            
        }
        //variable contador de tiempo
        movetime += Time.deltaTime;

        if (transform.position.x < -28.7 || transform.position.x > 38.5 || transform.position.y < -19.1 || transform.position.y >18.5)
        {
            Destroy(gameObject);
        }
        
	}
    //con esto dibujo el area de vision de mis enemigos
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, VisionRadio);
    }

    //aqui se destruye el enemigo, siempre que algo que sea disparo lo choque
    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Shoot1")
        {
            mounsterSpawner.contEnemies -= 1;
            
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "limitizq" || collision.gameObject.tag == "limitright")
        {
            movimiento = new Vector2(-1*x/ Mathf.Abs(x) * Time.deltaTime, y/ Mathf.Abs(y) * Time.deltaTime);
            transform.Translate(movimiento * speedR * Time.deltaTime);
        }
        if (collision.gameObject.tag == "limitup" || collision.gameObject.tag == "limitdown")
        {
            movimiento = new Vector2(x/ Mathf.Abs(x) * Time.deltaTime, -1*y/ Mathf.Abs(y) * Time.deltaTime);
            transform.Translate(movimiento * speedR * Time.deltaTime);
        }
        if (collision.gameObject.tag == "Player")
        {
            Character.life -= 5;
        }
    }
}
