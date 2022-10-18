using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneUI : MonoBehaviour
{
    // Start is called before the first frame update

    public RectTransform loadingPanel;
    public GameObject EventSystem;

    void Start()
    {
        loadingPanel.sizeDelta = new Vector2(Screen.width, Screen.height);
    }
    public void LoadLevel1()
    {
        DontDestroyOnLoad(EventSystem);
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
