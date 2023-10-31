using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnEvent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //start ¾À ·Îµå
    public void LoadStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
    //main ¾À ·Îµå
    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
