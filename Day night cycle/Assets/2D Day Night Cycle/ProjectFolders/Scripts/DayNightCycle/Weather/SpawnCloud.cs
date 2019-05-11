using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCloud : MonoBehaviour {

    public GameObject[] clouds;

    private float posX;
    private float posY;

    public float startTimeBetweenSpawn;
    private float timeBetweenSpawn;

    private bool xcloudy;

    public GameObject camera;

    private void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    public void spawnCloud(bool cloudy) {
        xcloudy = cloudy;
    }

    // Update is called once per frame
    private void Update()
    {

        if (xcloudy)
        {

            if (timeBetweenSpawn <= 0)
            {
                int cloudIndex = Random.Range(0, clouds.Length);

                posX = Random.Range(camera.transform.position.x + 10, camera.transform.position.x + 15);
                posY = Random.Range(3.5f, 5);

                Instantiate(clouds[cloudIndex], new Vector3(posX, posY), Quaternion.identity);

                timeBetweenSpawn = startTimeBetweenSpawn;
            }
            else
            {
                timeBetweenSpawn -= Time.deltaTime;
            }
        }
 
    }

}
