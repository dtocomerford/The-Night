using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTransition : MonoBehaviour
{

    public Light DayLight;
    public Light MainLight;

    public GameObject moon;
    public GameObject ground;
    public GameObject cliff;

    public Material groundNightMat;
    public Material groundDayMat;

    public Material cliffNightMat;
    public Material cliffDayMat;

    public Material daySkyBox;
    public Material nightSkyBox;

    public GameObject[] leaves;

    public float speed;
    private float t;
    private Renderer m_GroundRend;
    private Renderer m_CliffRend;


    // Start is called before the first frame update
    void Start()
    {
        m_CliffRend = cliff.GetComponentInChildren<Renderer>();
        m_GroundRend = ground.GetComponent<Renderer>();
        RenderSettings.skybox = nightSkyBox;

        leaves = GameObject.FindGameObjectsWithTag("Leaves");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(Transition());
        }
    }

    private void OnApplicationQuit()
    {
        RenderSettings.skybox.SetFloat("_Exposure", 0.1f);
    }


    IEnumerator Transition()
    {
        Material newSky = nightSkyBox;
        t = 0;

        while (t < 1)
        {

            t += Time.deltaTime * speed; 
            Color newGroundColor = Color.Lerp(groundNightMat.color, groundDayMat.color, t);
            Color newCliffColor = Color.Lerp(cliffNightMat.color, cliffDayMat.color, t);

            moon.transform.position = Vector3.Lerp(moon.transform.position, moon.transform.position + Vector3.up * 10, t);


            newSky.SetFloat("_Exposure", Mathf.Lerp(nightSkyBox.GetFloat("_Exposure"), daySkyBox.GetFloat("_Exposure"), t));

            RenderSettings.skybox = newSky;

            MainLight.intensity = Mathf.Lerp(MainLight.intensity, 1, t);
            DayLight.intensity = Mathf.Lerp(0, 1f, t);

            m_CliffRend.material.color = newCliffColor;
            m_GroundRend.material.color = newGroundColor;


            for (int i = 0; i < leaves.Length; i++)
            {
                Vector3 newSize = new Vector3(Mathf.Lerp(leaves[i].transform.localScale.x, 0, t), 1, (Mathf.Lerp(leaves[i].transform.localScale.z, 0, t* .5f)));

                leaves[i].transform.localScale = newSize;
            }
            yield return null;
        }
    }

}
