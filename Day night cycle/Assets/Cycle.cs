﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Cycle : MonoBehaviour {


    public float seconds;
    public float minutes;
    public float hours;
    public float days;
    private int season;

    public string[] seasonsArray;

    public float time_increment;
    private float intensity;

    public GameObject earth;

    public Weather weather;

    public Light sunLight;
    public Light sunFlare;

    public float startTimeBetweenWeather;
    private float timeBetweenWeather;

    public ParticleSystem stars;

    //UI
    public Text seasonTxt;
    public Text daysTxt;
    public Text timeTxt;


    //Colors
    public Gradient skyCycleColors;

    public SpriteRenderer fog;
    public Gradient fogColors;

    public SpriteRenderer ambient;

    public Color ambientRise;
    public Color ambientNoon;

    




    public Camera camera;

    private void Start()
    {  
        //Get Camera and clear colors
        camera = camera.GetComponent<Camera>();
        camera.clearFlags = CameraClearFlags.SolidColor;

        seconds = 0;
        minutes = 0;
        hours = 0;
        days = 0;
        season = 0;

    }

    private void Update()
    {
        cycle();


        //Change weather when timer runs out;
        if (timeBetweenWeather <= 0)
        {
            //Execute the weather determined in function.
            weather.executeWeather(determineWeather());

            //Reset timer.
            timeBetweenWeather = startTimeBetweenWeather;
        }
        else
        {
            //Decrease time.
            timeBetweenWeather -= Time.deltaTime;
        }

    }

    private void cycle()
    //Continously adds seconds to make minutes, hours, days and season.
    //Rotates earth object on its own x axis.
    {
        //Set time to speed of cycle
        float time = 1 / time_increment;

        //Increment time
        seconds += time;
        minutes = seconds / 60;
        hours = minutes / 60;

        //Rotate earth gameObject
        earth.transform.eulerAngles = new Vector3(0, 0, (-(hours / 24) * 360) + 90);

        //Reset cycle

        if (hours >= 24)
        {
            seconds = 0;
            days++;
        }

        //Every season has 30 days
        if (days >= 30)
        {
            days = 0;
            season++;
        }

        //There are 4 seasons in a year
        if (season >= 4)
        {
            season = 0;
        }

        seasonTxt.text = "Season: " + seasonsArray[season];
        daysTxt.text = "Day: " + days.ToString();
        timeTxt.text = string.Format("{0} : {1} : {2}", Mathf.Floor(hours).ToString(), Mathf.Floor(minutes).ToString(), 
                                     Mathf.Floor(seconds).ToString());

        changeColors();
        changeIntensity();

    }

    private void changeColors()
    //Changes cameraBackground, ambient and fog colors based on the suns intensity.
    {
        camera.backgroundColor = skyCycleColors.Evaluate(intensity);
        fog.color = fogColors.Evaluate(intensity);

        ambient.color = Color.Lerp(ambientRise, ambientNoon, intensity);
    }


    private void changeIntensity()
    //Changes suns intensite based on the time(in hours).
    {
        if (hours < 12)
        {
            intensity = (1 - (12 - hours) / 12);
        }
        else
        {
            intensity = (1 - ((12 - hours) / 12 * -1));
        }

        if (hours == 20)
        {
            stars.Play();
        }
        else if(hours == 1)
        {
            stars.Stop();

        }



        sunLight.intensity = intensity;
        sunFlare.intensity = intensity;
    }

    string determineWeather()
    //Determines the current weather and executes it on screen.
    //Returns string value of the determined weather.
    {
        //Pick a random number.
        float weatherIndex = Random.Range(0, 11);

        //Check current season.
        if (seasonsArray[season] == "Summer")
        {

            //During the summer the chances of rain are slim.
            if (weatherIndex <= 6)
            {
                //There is a 60% chance of sun.
                return "sunny";
            }
            else if(weatherIndex > 6 && weatherIndex <= 9)
            {
                //There is a 30% chance of clouds.
                return "cloudy";
            }
            else
            {
                //There is a 10% change of rain.
                return "raining";
            }

        }

        //Check current season.
        else if (seasonsArray[season] == "Fall")
        {

            //During fall the chances of rain are greater.
            if (weatherIndex <= 2)
            {
                //There is a 20% chance of sun.
                return "sunny";
            }
            else if (weatherIndex > 2 && weatherIndex <= 5)
            {
                //There is a 30% chance of clouds.
                return "cloudy";
            }
            else
            {
                //There is a 50% change of rain.
                return "raining";
            }


        }

        //Check current season.
        else if (seasonsArray[season] == "Winter")
        {
            //During winter the chances of rain are greater.
            //When it rains during winter the snow(); function is called
            //Because it snows during winter.
            if (weatherIndex <= 3)
            {
                //There is a 30% chance of sun.
                return "sunny";
            }
            else if (weatherIndex > 3 && weatherIndex <= 5)
            {
                //There is a 20% chance of clouds.
                return "cloudy";
            }
            else
            {
                //There is a 50% change of rain.
                return "snowing";
            }

        }

        //Check current season.
        //If nothing is true season is Spring.
        else
        {
            //During spring the chances are about evenly split.
            if (weatherIndex <= 4)
            {
                //There is a 40% chance of sun.
                return "sunny";
            }
            else if (weatherIndex > 4 && weatherIndex <= 7)
            {
                //There is a 30% chance of clouds.
                return "cloudy";
            }
            else
            {
                //There is a 30% change of rain.
                return "raining";
            }
        }
    }

    public void changeSeason(int newSeason)
    {
        Debug.Log("Changing season");
        season = newSeason;
    }
}


