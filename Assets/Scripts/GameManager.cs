using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.PostProcessing;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public int score;
    [HideInInspector] public GameObject StartPosA;
    [HideInInspector] public GameObject StartPosB;
    [HideInInspector] public GameObject Finish;
    public int MainFrameHealth;
    [HideInInspector] public List<GameObject> ActiveViruses = new List<GameObject>();
    [HideInInspector] public Material NormalBlock;
    [HideInInspector] public Material HoverMaterial;
    [HideInInspector] [SerializeField] GameObject pauseMenu;
    [SerializeField] int MaxMainFrameHealth;
    [HideInInspector] [SerializeField] TextMeshProUGUI mainframeHealth;
    [HideInInspector] [SerializeField] TextMeshProUGUI nanoPointsDisplay;
    [HideInInspector] [SerializeField] Color HoverColor;
    public int nanoPoints = 30;
    [SerializeField] float nanoPointsRate = 2f;

    RaycastHit hitData;
    [HideInInspector] public static GameObject activeBlock;

    public int virusPoints;
    float waitTimer = 3f;
    float timer;
    [HideInInspector] [SerializeField] GameObject sectorCleared;
    [HideInInspector] [SerializeField] GameObject sectorCorrupted;
    public int subroutineCost;
    public int nanoInjectorCost;
    public int nanoBomberCost;
    public int quarentinerCost;
    public int virusScannerCost;

    [SerializeField] float startViruses = 10f;
    [HideInInspector] [SerializeField] TextMeshProUGUI startVirusesDisplay;
    [HideInInspector] [SerializeField] TextMeshProUGUI scoreDisplay;
    [HideInInspector] public bool virusesStart;
    bool cleared;

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
        startViruses -= Time.deltaTime;
        startVirusesDisplay.text = startViruses.ToString("0.00");
        if (startViruses <= 0)
        {
            startVirusesDisplay.gameObject.SetActive(false);
            virusesStart = true;
        }
        else
        {
            startVirusesDisplay.gameObject.SetActive(true);
            virusesStart = false;
        }
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
                    r.material = HoverMaterial;
                }
            }
        }
        //////////////////////
        SectorCorrupt();
        SectorClear();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause();
        }
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
        
        if (virusPoints <= 2 && ActiveViruses.Count <= 0 && MainFrameHealth > 0)
        {
            timer += Time.deltaTime;
            if (timer > waitTimer && cleared == false)
            {
                cleared = true;
                Time.timeScale = 0;
                score += MainFrameHealth + nanoPoints;
                scoreDisplay.text = score.ToString();
                sectorCleared.SetActive(true);
            }
        }
    }

    public void SetTowerBlockMaterial()
    {
        activeBlock.GetComponent<NanoBlockController>().activeBlock = true;
        activeBlock.GetComponent<MeshRenderer>().material = HoverMaterial;
    }

    public void pause()
    {
        if (pauseMenu.activeSelf)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

}
