using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float VisionRadio;
    public float speed = 3f;
    public float speedR = 30;
    public Vector3 target;
    GameObject player;
    private float movetime = 0;
    private Vector2 movimiento;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
		
	}
	
	// Update is called once per frame
	void Update () {
        if (movetime <0.1)
        {
            float x = Random.Range(5, -5);
            float y = Random.Range(5, -5);
            movimiento = new Vector2(x * Time.deltaTime, y * Time.deltaTime);
        }
        
        Vector3 target = new Vector3(transform.localPosition.x, transform.localPosition.y);

        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist < VisionRadio)
        {
            target = player.transform.position;
            float fixedspeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, fixedspeed);
        }
        else
        {
            if (movetime <1)
            {
                transform.Translate(movimiento * speedR * Time.deltaTime);
            }
            else
            {
                movetime = 0;
            }
            
            
        }
        movetime += Time.deltaTime;

        
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, VisionRadio);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("me han dado");
        if (collision.gameObject.tag == "Shoot1")
        {
            Debug.Log("me destruyo");
            Destroy(gameObject);
        }
    }
}
