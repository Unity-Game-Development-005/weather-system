using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using TMPro;

public class WeatherSystem : MonoBehaviour
{
    [Header("Global")]
    public Material globalMaterial;
    public Light sunLight;
    public Material skyboxMaterial;
    public GameObject snowFX;
    public GameObject rainFX;
    public TMP_Text weatherText;

    [Header("Winter Assets")]
    public ParticleSystem winterParticleSystem;
    public Volume winterVolume;

    [Header("Rain Assets")]
    public ParticleSystem rainParticleSystem;
    public Volume rainVolume;

    [Header("Autumn Assets")]
    public ParticleSystem autumnParticleSystem;
    public Volume autumnVolume;

    [Header("Summer Assets")]
    public ParticleSystem summerParticleSystem;
    public Volume summerVolume;


    private const int AUTUMN = 0;
    private const int SPRING = 1;
    private const int SUMMER = 2;
    private const int WINTER = 3;

    


    private void Start()
    {
        Summer();
    }

    public void Winter()
    {
        weatherText.text = "WINTER";

        ChangeSeason(WINTER);
    }

    public void Rain()
    {
        weatherText.text = "SPRING";

        ChangeSeason(SPRING);
    }

    public void Autumn()
    {
        weatherText.text = "AUTUMN";

        ChangeSeason(AUTUMN);
    }

    public void Summer()
    {
        weatherText.text = "SUMMER";

        ChangeSeason(SUMMER);
    }


    private void ChangeSeason(int season)
    {
        // disable to the snow/rain effects
        globalMaterial.SetFloat("_SnowFade", 0);

        snowFX.gameObject.SetActive(false);
        rainFX.gameObject.SetActive(false);

        // reset the season global volume priorities
        autumnVolume.priority = 0;
        rainVolume.priority = 0;
        summerVolume.priority = 0;
        winterVolume.priority = 0;
       

        // select which season to show
        switch (season)
        {
            case AUTUMN:

                autumnVolume.priority = 1;

                break;

            case SPRING:

                rainVolume.priority = 1;

                rainFX.SetActive(true);

                break;

            case SUMMER:

                summerVolume.priority = 1;

                break;

            case WINTER:

                winterVolume.priority = 1;

                globalMaterial.SetFloat("_SnowFade", 1);

                snowFX.SetActive(true);

                break;
        }
    }

}
