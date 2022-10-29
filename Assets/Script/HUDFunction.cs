using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class HUDFunction : MonoBehaviour
{
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textTime;
    public TextMeshProUGUI textGhost;

    public GameObject Health1;
    public GameObject Health2;
    public GameObject Health3;

    private float Starttime;

    public void ExitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false; 
    }

    void Start()
    {
        Starttime = Time.time;   
    }

    void Update()
    {
        float timepassed = Time.time - Starttime;
        

        string minutes = ((int) timepassed / 60).ToString("f0");
        string seconds = (timepassed % 60).ToString("f0");
        string hours = (timepassed / 3600).ToString("f0");

        textTime.text = hours + ":" + minutes + ":" + seconds; 

    }

    public int score { get; private set; }
    public int time { get; private set; }




}
