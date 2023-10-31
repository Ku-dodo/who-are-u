using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //�̱��� ���� ����
    public static GameManager I;

    //�ð� ���� ����
    public GameObject card;
    public Text timetxt;
    float time = 30.0f;

    //ī�� ��ġ
    public bool sortCompleted = false;

    //���� ���� ���� ����
    public GameObject endcanvas;

    //Match ���� ����
    public GameObject firstCard;
    public GameObject secondCard;

    //��� â ���� ���� ����
    public Text counttxt;
    public Text trytxt;
    int matchCount = 333;
    int matchTry = 400;

    //MatchUI ���� ����
    public GameObject matchCanvas;
    public GameObject unMatchCanvas;
    public Text cardNameTxt;
    
    string[] teamName = new string[4] {"������", "���ؿ�", "����", "�Ͻ±�"};
    int resourseDirFile = Directory.GetFiles("./Assets/Resources").Length / 2;
    


    void Awake()
    {
        I = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        Invoke("Update()", 3);

    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        /*if (sortCompleted == true)
        {
            Timer();
        }*/
    }

    //Timer..
    void Timer()
    {
        sortCompleted = true;   //test��

        if (sortCompleted == true)  // true �϶� Timer�� ���� ��..
        {
            time -= Time.deltaTime;
            timetxt.text = time.ToString("N1");

            if (time <= 0.00f)
            {
                Time.timeScale = 0.0f;
                endcanvas.SetActive(true);
                BGM.instance.SpeedUp(0);
                timetxt.text = "<color=black>" + time.ToString("N1") + "</color>";
            }
            else if (time < 10.00f)
            {
                BGM.instance.SpeedUp(2);
                timetxt.text = "<color=red>" + time.ToString("N1") + "</color>";
            }
            else if (time < 20.00f)
            {
                BGM.instance.SpeedUp(1);
                timetxt.text = "<color=orange>" + time.ToString("N1") + "</color>";
            }
            else
            {
                timetxt.text = "<color=white>" + time.ToString("N1") + "</color>";
            }
        }
    }


    //��ġ �õ� �Լ�
    public void IsMatched()
    {
        //
        string firstCardImage = firstCard.transform.Find("Front").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImage = secondCard.transform.Find("Front").GetComponent<SpriteRenderer>().sprite.name;
        matchTry++;

        if (firstCardImage == secondCardImage)
        {



            //audioManager ���� �޾ƿͼ� true �ڵ� ����
            //audioManager.instance.PMSPaly();


            firstCard.GetComponent<Card>().DestroyCard();
            secondCard.GetComponent<Card>().DestroyCard();

            //��ġ ���� �� Text ��ȯ switch�� ����
            cardNameTxt.text = (resourseDirFile / teamName.Length) switch
            {
                4 => teamName[3],
                3 => teamName[2],
                2 => teamName[1],
                _ => teamName[0]
            };
            
            //��Ī ���� UI�� ��Ÿ���ٰ� ����� ���� ����
            matchCanvas.SetActive(true);
            Invoke("HideMatchUI", 0.5f);

            //��ġ ���� ī�� ī����
            matchCount++;

            int peopleName = int.Parse(firstCardImage.Substring(4));


            int childLeft = GameObject.Find("Cards").transform.childCount;
            if (childLeft == 2)
            {
                Invoke("EndGame", 1.1f);
            }
        }
        else
        {
            //audioManager ���� �޾ƿͼ� false �ڵ� ����
            //audioManager.instance.PUMSPaly();


            firstCard.GetComponent<Card>().CloseCard();
            secondCard.GetComponent<Card>().CloseCard();

            //��Ī ���� UI�� ��Ÿ���ٰ� ����� ���� ����
            unMatchCanvas.SetActive(true);
            Invoke("HideUnMatchUI", 0.5f);
        }
        firstCard = null;
        secondCard = null;
    }

    //��Ī��� UI Hide
    public void HideMatchUI()
    {
        matchCanvas.gameObject.SetActive(false);
    }
    public void HideUnMatchUI()
    {
        unMatchCanvas.SetActive(false);
    }

    //��Ī ���� �� UI ����
    void EndGame()
    {
        trytxt.text = $"�õ� Ƚ�� : {matchTry}";
        counttxt.text = $"���� : {matchCount}";
        Time.timeScale = 0f;
        endcanvas.SetActive(true);
    }

}
