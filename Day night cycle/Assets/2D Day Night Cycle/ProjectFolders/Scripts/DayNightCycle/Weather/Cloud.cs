using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {

    private float speed;

	// Use this for initialization
	void Start () {

        speed = Random.Range(0.8F, 1.5f);

    }
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector2.left * speed * Time.deltaTime);

	}

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
