using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsFunction : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void arriba()
    {
        Character.lvymas = true;
    }

    public void izquierda()
    {
        Character.lhxmen = true;
    }

    public void derecha()
    {
        Character.lhxmas = true;
    }

    public void abajo()
    {
        Character.lvymen = true;
    }

    public void fire()
    {
        Character.fire = true;
    }
}
