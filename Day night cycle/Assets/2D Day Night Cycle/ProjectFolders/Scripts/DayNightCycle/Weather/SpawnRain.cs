using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRain : MonoBehaviour {

    private bool rainSpawn;
    private Cycle cycle;

    public ParticleSystem rain;

    // Use this for initialization
    void Start () {

        cycle = GetComponent<Cycle>();

	}

    public void spawnRain(bool spawn)
    {
        rainSpawn = spawn;
    }
	
	// Update is called once per frame
	void Update () {
		
        if (rainSpawn)
        {
            cycle.camera.backgroundColor = Color.Lerp(cycle.skyCycleColors.Evaluate(cycle.intensity), cycle.rainSky, 0.5f);

            cycle.fog.color = Color.Lerp(cycle.fogColors.Evaluate(cycle.intensity), cycle.rainFog, 2);

            rain.Play();
        }
        else
        {
            cycle.camera.backgroundColor = Color.Lerp(cycle.rainSky, cycle.skyCycleColors.Evaluate(cycle.intensity), 0.5f);

            cycle.fog.color = Color.Lerp(cycle.rainFog, cycle.fogColors.Evaluate(cycle.intensity), 0.5f);
            rain.Stop();
        }

	}
}