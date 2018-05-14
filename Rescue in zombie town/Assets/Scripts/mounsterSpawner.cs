using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mounsterSpawner : MonoBehaviour {

    public GameObject Zombie1;
    public Vector2 center;
    public Vector2 size;
    public float spawnTime = 0;
    public static int contEnemies = 0;


	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        spawnTime += Time.deltaTime;
        if (spawnTime > 5)
        {
            if (contEnemies <30)
            {
                contEnemies++;
                SpawnMounster();
                spawnTime = 0;
            }
        }
	}
    public void SpawnMounster()
    {
        Vector2 SpawnPosition = center + new Vector2(Random.Range(-size.x/2, size.x/2), Random.Range(-size.y / 2, size.y / 2));
        Instantiate(Zombie1, SpawnPosition, Quaternion.identity);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);

        center = new Vector2(transform.localPosition.x, transform.localPosition.y);


        Gizmos.DrawCube(center,size);
    }

}
