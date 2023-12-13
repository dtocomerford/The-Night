using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTransition : MonoBehaviour
{

    public Light dayLight;
    public Light mainLight;
    [Space]
    public GameObject sun;
    public GameObject moon;
    public GameObject ground;
    public GameObject cliff;
    [Space]
    public Material groundNightMat;
    public Material groundDayMat;
    [Space]
    public Material cliffNightMat;
    public Material cliffDayMat;
    [Space]
    public Material daySkyBoxMaterial;
    public Material nightSkyBoxMaterial;
    [Space]
    public GameObject[] leavesObjects;
    [Space]

    private Vector3 moonNightPosition;
    private Vector3 moonDayPosition;
    
    private Vector3 sunNightPosition;
    private Vector3 sunDayPosition;

    [Space]
    [Tooltip("The speed of the transition for day to night and vice versa")]
    public float speed;
    
    private float m_T;
    
    private Renderer m_GroundRend;
    private Renderer m_CliffRend;
    private Material m_NewSky;

    //Coroutine reference to track if a coroutine is currently being executed
    private Coroutine m_Coroutine;
    


    // Start is called before the first frame update
    void Start()
    {
        m_Coroutine = null;
        m_CliffRend = cliff.GetComponentInChildren<Renderer>();
        m_GroundRend = ground.GetComponent<Renderer>();
        RenderSettings.skybox = nightSkyBoxMaterial;
        m_NewSky = nightSkyBoxMaterial;

        leavesObjects = GameObject.FindGameObjectsWithTag("Leaves");

        moonNightPosition = moon.transform.position;
        moonDayPosition = moonNightPosition + Vector3.up * 50;

        sunDayPosition = sun.transform.position;
        sunNightPosition = sunDayPosition + Vector3.up * 50;

        //Put the sun into the night position to star tthe game 
        sun.transform.position = MoveObject(1, sunDayPosition, sunNightPosition);

        //Sets the leaves to disapear at the start of the game
        ChangeLeavesScale(1, true);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && m_Coroutine == null)
        {
            m_Coroutine = StartCoroutine(TransitionToDay());
        }
        if (Input.GetKeyDown(KeyCode.Space) && m_Coroutine == null)
        {
            m_Coroutine = StartCoroutine(TransitionToNight());
        }
    }


    /// <summary>
    /// When the game closes set the exposure back to the night setting
    /// </summary>
    private void OnApplicationQuit()
    {
        RenderSettings.skybox.SetFloat("_Exposure", 0.1f);
    }


    void ChangeLeavesScale(float t, bool toShrink)
    {
        Vector3 newSize;
        for (int i = 0; i < leavesObjects.Length; i++)
        {
            Leaves leavesScript = leavesObjects[i].GetComponent<Leaves>();
            if (toShrink)
            {
                 newSize = new Vector3(Mathf.Lerp(leavesObjects[i].transform.localScale.x, 0, t), 1, (Mathf.Lerp(leavesObjects[i].transform.localScale.z, 0, t * .05f)));
            }
            else
            {
                newSize = new Vector3(Mathf.Lerp(leavesObjects[i].transform.localScale.x, leavesScript.startScale.x, t), 1, (Mathf.Lerp(leavesObjects[i].transform.localScale.z, leavesScript.startScale.z, t * .05f)));
            }
            leavesObjects[i].transform.localScale = newSize;
        }
    }


    Vector3 MoveObject(float t, Vector3 from, Vector3 to)
    {
        Vector3 newPosition = Vector3.Lerp(from, to, t);
        return newPosition;
    }


    float ChangeLighting(float t, float from, float to)
    {
        float intensity = Mathf.Lerp(from, to, t);
        return intensity;
    }


    Color ChangeMaterialColor(float t, Material from, Material to)
    {
        Color newColor = Color.Lerp(from.color, to.color, t);
        return newColor;
    }


    void ChangeSkyboxExposure(float t, Material from, Material to)
    {
        m_NewSky.SetFloat("_Exposure", Mathf.Lerp(from.GetFloat("_Exposure"), to.GetFloat("_Exposure"), t));
        RenderSettings.skybox = m_NewSky;
    }


    IEnumerator TransitionToDay()
    {
        m_T = 0;

        while (m_T < 1)
        {
            m_T += Time.deltaTime * speed;

            sun.transform.position = MoveObject(m_T, sun.transform.position, sunDayPosition);
            moon.transform.position = MoveObject(m_T, moon.transform.position, moonDayPosition);
            dayLight.intensity = ChangeLighting(m_T, 0, 1);
            mainLight.intensity = ChangeLighting(m_T, mainLight.intensity, 1);
            m_CliffRend.material.color = ChangeMaterialColor(m_T, cliffNightMat, cliffDayMat);
            m_GroundRend.material.color = ChangeMaterialColor(m_T, groundNightMat, groundDayMat);

            
            RenderSettings.skybox.SetFloat("_Exposure", ChangeLighting(m_T, 0.1f, 2));

            ChangeLeavesScale(m_T, false);
            
            yield return null;
        }
        m_Coroutine = null;
    }


    IEnumerator TransitionToNight()
    {
        m_T = 0;

        while (m_T < 1)
        {
            m_T += Time.deltaTime * speed;

            sun.transform.position = MoveObject(m_T, sun.transform.position, sunNightPosition);
            moon.transform.position = MoveObject(m_T, moon.transform.position, moonNightPosition);
            dayLight.intensity = ChangeLighting(m_T, 1, 0);
            mainLight.intensity = ChangeLighting(m_T, 1, 0.75f);
            m_CliffRend.material.color = ChangeMaterialColor(m_T, cliffDayMat, cliffNightMat);
            m_GroundRend.material.color = ChangeMaterialColor(m_T, groundDayMat, groundNightMat);

            RenderSettings.skybox.SetFloat("_Exposure", ChangeLighting(m_T, 2, 0.1f));

            ChangeLeavesScale(m_T, true);

            yield return null;
        }
        m_Coroutine = null;
    }
}
