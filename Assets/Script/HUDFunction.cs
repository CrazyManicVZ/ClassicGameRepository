using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUDFunction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ExitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
