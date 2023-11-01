using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BtnEvent : MonoBehaviour
{
    public GameObject stageBtnPanel;

    // Start is called before the first frame update
    void Start()
    {
        BtnInteractive();
    }


    // Update is called once per frame
    void Update()
    {

    }

    //start 씬 로드
    public void LoadStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
    //4*4 씬 로드
    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
    //6*6 씬 로드
    public void LoadHardScene()
    {
        SceneManager.LoadScene("HardScene");
    }

    void BtnInteractive()
    {
        //시작 씬인지 아닌지 확인하기 위한 용도
        if (SceneManager.GetActiveScene().name == "StartScene")
        {
            Button[] StageBtn = stageBtnPanel.transform.GetComponentsInChildren<Button>(); 
            int ClearStage = PlayerPrefs.GetInt("ClearStage");
            //버튼 초기화
            foreach (Button button in StageBtn)
            {
                button.interactable = false;
            }
            //버튼 해금
            for (int i = 0; i <= ClearStage; i++)
            {
                StageBtn[i].interactable = true;
            }
        }
    }
}
