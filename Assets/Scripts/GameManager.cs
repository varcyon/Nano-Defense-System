using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameObject StartPos;
    public static GameObject Finish;
    public static int MainFrameHealth;
    [SerializeField] int MaxMainFrameHealth;
    [SerializeField] TextMeshProUGUI mainframeHealth;
    public Color HoverColor;
    public static GameManager i;
    RaycastHit hitData;
    public static GameObject activeBlock;

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
        StartPos = GameObject.FindGameObjectWithTag("Start");
        Finish = GameObject.FindGameObjectWithTag("End");

    }

    void Update()
    {
        mainframeHealth.text = MainFrameHealth.ToString();
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
                    r.material.color = HoverColor;
                }
            }
        }
    }
}
