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

    //start �� �ε�
    public void LoadStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
    //main �� �ε�
    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
