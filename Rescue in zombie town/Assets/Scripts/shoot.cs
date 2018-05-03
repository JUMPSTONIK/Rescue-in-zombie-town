using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour {
    public float Speed = 15f;
    public float posX;
    public float posY;
    public float orientationx;
    public float orientationy;

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
            Debug.Log(orientationx * Vector3.right * Speed);
            if (transform.position.x > posX + 6 || transform.position.x < posX - 6)
            {
                Destroy(gameObject);
            }
        }

        if (orientationy != 0)
        {
            transform.Translate(new Vector2(0, 1) * orientationy * Speed * Time.deltaTime);
            Debug.Log(orientationy * Vector3.up * Speed);
            if (transform.position.y > posY + 6 || transform.position.y < posY - 6)
            {
                Destroy(gameObject);
            }
        }

    }
}
