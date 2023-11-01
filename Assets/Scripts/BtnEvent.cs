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

    //start �� �ε�
    public void LoadStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
    //4*4 �� �ε�
    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
    //6*6 �� �ε�
    public void LoadHardScene()
    {
        SceneManager.LoadScene("HardScene");
    }

    void BtnInteractive()
    {
        //���� ������ �ƴ��� Ȯ���ϱ� ���� �뵵
        if (SceneManager.GetActiveScene().name == "StartScene")
        {
            Button[] StageBtn = stageBtnPanel.transform.GetComponentsInChildren<Button>(); 
            int ClearStage = PlayerPrefs.GetInt("ClearStage");
            //��ư �ʱ�ȭ
            foreach (Button button in StageBtn)
            {
                button.interactable = false;
            }
            //��ư �ر�
            for (int i = 0; i <= ClearStage; i++)
            {
                StageBtn[i].interactable = true;
            }
        }
    }
}
