using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{
    // Start is called before the first frame update

    public TextMeshProUGUI kills;
    public TextMeshProUGUI score;
    public TextMeshProUGUI health;
    public TextMeshProUGUI message;
    public TextMeshProUGUI mission;

    private bool showMission = true;
    private float showMissionTimer;

    void Start()
    {
        showMissionTimer = Time.time;
        //Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (showMission && (Time.time - showMissionTimer) > 4)
        {
            mission.gameObject.SetActive(false);
            showMission = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //if (Time.timeScale == 0)
            //    Time.timeScale = 1;
            //else
            //    Time.timeScale = 0;

            GetComponent<Transform>().GetChild(1).gameObject.SetActive(!GetComponent<Transform>().GetChild(1).gameObject.activeSelf);
        }

    }
}
