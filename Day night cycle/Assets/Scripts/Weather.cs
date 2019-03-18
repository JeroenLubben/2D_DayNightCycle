using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weather : MonoBehaviour {

    public SpawnCloud cloud;
    public ParticleSystem rain;

    public Text currenWeatherTxt;


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
        rain.Stop();
        cloud.spawnCloud(true);
       
        
        currenWeatherTxt.text = ("Weather: cloudy");
    }

    private void executeRaining()
    {
        cloud.spawnCloud(true);
        rain.Play();
        currenWeatherTxt.text = ("Weather: raining");
    }

    private void executeSunny()
    {
        cloud.spawnCloud(false);
        rain.Stop();
        currenWeatherTxt.text = ("Weather: sunny");
    }

    private void executeSnowing()
    {
        currenWeatherTxt.text = ("Weather: snowing");
    }

}
