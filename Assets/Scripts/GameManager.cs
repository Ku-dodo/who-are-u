using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //싱글톤 관련 변수
    public static GameManager I;

    //시간 관련 변수
    public GameObject card;
    public Text timetxt;
    float time = 30.0f;

    //카드 배치
    public bool sortCompleted = false;

    //게임 종료 관련 변수
    public GameObject endcanvas;

    //Match 관련 변수
    public GameObject firstCard;
    public GameObject secondCard;

    //결과 창 점수 관련 변수
    public Text counttxt;
    public Text trytxt;
    int matchCount = 333;
    int matchTry = 400;

    //MatchUI 관련 변수
    public GameObject matchCanvas;
    public GameObject unMatchCanvas;
    public Text cardNameTxt;
    
    string[] teamName = new string[4] {"구도현", "박준욱", "윤희성", "하승권"};
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
        sortCompleted = true;   //test용

        if (sortCompleted == true)  // true 일때 Timer가 실행 됨..
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


    //매치 시도 함수
    public void IsMatched()
    {
        //
        string firstCardImage = firstCard.transform.Find("Front").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImage = secondCard.transform.Find("Front").GetComponent<SpriteRenderer>().sprite.name;
        matchTry++;

        if (firstCardImage == secondCardImage)
        {



            //audioManager 에서 받아와서 true 코드 실행
            //audioManager.instance.PMSPaly();


            firstCard.GetComponent<Card>().DestroyCard();
            secondCard.GetComponent<Card>().DestroyCard();

            //매치 성공 시 Text 변환 switch문 예정
            cardNameTxt.text = (resourseDirFile / teamName.Length) switch
            {
                4 => teamName[3],
                3 => teamName[2],
                2 => teamName[1],
                _ => teamName[0]
            };
            
            //매칭 성공 UI가 나타났다가 사라짐 넣을 예정
            matchCanvas.SetActive(true);
            Invoke("HideMatchUI", 0.5f);

            //매치 성공 카드 카운터
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
            //audioManager 에서 받아와서 false 코드 실행
            //audioManager.instance.PUMSPaly();


            firstCard.GetComponent<Card>().CloseCard();
            secondCard.GetComponent<Card>().CloseCard();

            //매칭 실패 UI가 나타났다가 사라짐 넣을 예정
            unMatchCanvas.SetActive(true);
            Invoke("HideUnMatchUI", 0.5f);
        }
        firstCard = null;
        secondCard = null;
    }

    //매칭결과 UI Hide
    public void HideMatchUI()
    {
        matchCanvas.gameObject.SetActive(false);
    }
    public void HideUnMatchUI()
    {
        unMatchCanvas.SetActive(false);
    }

    //매칭 성공 시 UI 노출
    void EndGame()
    {
        trytxt.text = $"시도 횟수 : {matchTry}";
        counttxt.text = $"점수 : {matchCount}";
        Time.timeScale = 0f;
        endcanvas.SetActive(true);
    }

}
