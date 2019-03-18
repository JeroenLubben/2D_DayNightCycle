using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCloud : MonoBehaviour {

    public GameObject[] clouds;

    public float posX;
    public float posY;

    public float startTimeBetweenSpawn;
    private float timeBetweenSpawn;

    private bool xcloudy;

    public Camera camera;

    

    public void spawnCloud(bool cloudy) {
        xcloudy = cloudy;
        Update();
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
