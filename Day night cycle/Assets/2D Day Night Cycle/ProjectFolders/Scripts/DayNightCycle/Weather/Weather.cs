using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weather : MonoBehaviour {

    private SpawnCloud cloud;
    private SpawnRain spawnRain;

    private Cycle cycle;
    public Text currenWeatherTxt;

    private void Start()
    {
        cloud = GetComponent<SpawnCloud>();

        cycle = GetComponent<Cycle>();

        spawnRain = GetComponent<SpawnRain>();
    }

    public void executeWeather(string weatherType)
    {

        if(weatherType == "cloudy")
        {
            executeCloudy();
        }
        else if(weatherType == "raining")
        {
            executeRaining();
        }
        else if(weatherType == "snowing")
        {
            executeSnowing();
        }
        else
        {
            executeSunny();
        }
        
    }

    private void executeCloudy()
    {
        cycle.raining = false;
        cloud.spawnCloud(true);
        spawnRain.spawnRain(false);

    }

    private void executeRaining()
    {
        cycle.raining = true;

        cloud.spawnCloud(true);
        spawnRain.spawnRain(true);

    }

    private void executeSunny()
    {
        cycle.raining = false;

        cloud.spawnCloud(false);
        spawnRain.spawnRain(false);
    }

    private void executeSnowing()
    {
        cycle.raining = false;

        spawnRain.spawnRain(false);
    }

}
