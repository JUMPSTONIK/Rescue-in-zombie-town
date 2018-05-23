using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class shoot : MonoBehaviour {
    public float Speed = 15f;
    public float posX;
    public float posY;
    public float orientationx;
    public float orientationy;
    public Character player;

    // Use this for initialization
    void Start () {
        posX = Character.rbchara.position.x;
        posY = Character.rbchara.position.y;
        orientationx = Character.dirx;
        orientationy = Character.diry;



    }
	
	// Update is called once per frame
	void Update () {

        if (orientationx != 0)
        {
            transform.Translate(new Vector2(1, 0)* orientationx * Speed * Time.deltaTime);
            
            if (transform.position.x > posX + 6 || transform.position.x < posX - 6)
            {
                Destroy(gameObject);
            }
        }

        if (orientationy != 0)
        {
            transform.Translate(new Vector2(0, 1) * orientationy * Speed * Time.deltaTime);
            
            if (transform.position.y > posY + 6 || transform.position.y < posY - 6)
            {
                Destroy(gameObject);
            }
        }

    }
    public void shooting()
    {
        player.shoot();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "zombie")
        {
            Character.puntos += 10;
            Destroy(gameObject);
        }
    }
    
}
