using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.PostProcessing;

public class GameManager : MonoBehaviour
{
    public GameObject StartPosA;
    public GameObject StartPosB;
    public GameObject Finish;
    public int MainFrameHealth;
    public List<GameObject> ActiveViruses = new List<GameObject>();

    [SerializeField] int MaxMainFrameHealth;
    [SerializeField] TextMeshProUGUI mainframeHealth;
    [SerializeField] TextMeshProUGUI nanoPointsDisplay;
    [SerializeField] Color HoverColor;
    public int nanoPoints = 30;
    [SerializeField] float nanoPointsRate = 2f;

    RaycastHit hitData;
    public static GameObject activeBlock;

    public int virusPoints;
    float waitTimer = 3f;
    float timer;
    [SerializeField] GameObject sectorCleared;
    [SerializeField] GameObject sectorCorrupted;

    public static GameManager i;
    private void Awake()
    {
        if (i != this)
        {
            i = this;
        }
    }
    void Start()
    {
        //Time.timeScale = .15f;
        MainFrameHealth = MaxMainFrameHealth;
        StartPosA = GameObject.FindGameObjectWithTag("StartA");
        StartPosB = GameObject.FindGameObjectWithTag("StartB");

        Finish = GameObject.FindGameObjectWithTag("End");
        InvokeRepeating("nanoPointTicker", nanoPointsRate, nanoPointsRate);

    }
    void nanoPointTicker()
    {
        nanoPoints++;
    }
    void Update()
    {
        mainframeHealth.text = MainFrameHealth.ToString();
        nanoPointsDisplay.text = nanoPoints.ToString();
        /// raycast hit object data
        /// https://www.youtube.com/watch?v=p2_X_klweBw
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hitData))
        {
            activeBlock = hitData.collider.gameObject;
            if (GameManager.activeBlock.GetComponent<NanoBlockController>() != null)
            {
                if (GameManager.activeBlock.GetComponent<NanoBlockController>().buildable)
                {
                    MeshRenderer r = activeBlock.GetComponent<MeshRenderer>();
                    r.material.SetColor("_BaseColor", HoverColor);
                }
            }
        }

        SectorCorrupt();
        SectorClear();
    }

    void SectorCorrupt()
    {
        if (MainFrameHealth <= 0)
        {
            timer += Time.deltaTime;
            if (timer > waitTimer)
            {
                Time.timeScale = 0;
                sectorCorrupted.SetActive(true);
            }
        }
    }

    void SectorClear()
    {
        if (virusPoints <= 1 && ActiveViruses.Count <= 0 && MainFrameHealth > 0)
        {
            timer += Time.deltaTime;
            if (timer > waitTimer)
            {

                Time.timeScale = 0;
                sectorCleared.SetActive(true);
            }
        }
    }
}
