using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SearchService;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //싱글톤 관련 변수
    public static GameManager I;

    //시간 관련 변수
    public GameObject card;
    public GameObject TimeCanvas;
    public Text timetxt;
    float time = 60.0f;

    //카드 배치
    public bool sortCompleted = false;
    public CardDealer cardDealer;

    //게임 종료 관련 변수
    public GameObject endcanvas;

    //Match 관련 변수
    public GameObject firstCard;
    public GameObject secondCard;

    //결과 창 점수 관련 변수
    public Text counttxt;
    public Text trytxt;
    int matchCount;
    int matchTry;
    int matchFailed;
    int totalScore;
    int bestScore = 0;

    //MatchUI 관련 변수
    public GameObject matchCanvas;
    public GameObject unMatchCanvas;
    public string ownerName;
    //public Text ownerNameTxt;


    //카드 초기화 관련 타이머
    float PickTime = 0f;

    void Awake()
    {
        I = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadBestScore();
        SpawnUI();

        Time.timeScale = 1.0f;
        Debug.Log(PlayerPrefs.GetInt("ClearStage"));
    }

    // Update is called once per frame
    void Update()
    {
        Timer();

        int childLeft = GameObject.Find("Cards").transform.childCount;
        if (childLeft == 0)
        {
            //44보드 클리어 여부를 저장하기 위한 코드
            PlayerPrefs.SetInt("ClearStage", 1);
            Invoke("EndGame", 1.1f);
        }

        unPickCard();
    }
    public void OnTimer()
    {
        TimeCanvas.SetActive(true);
        sortCompleted = true;
    }

    //Timer..
    void Timer()
    {   

        if (sortCompleted == true)  // true 일때 Timer가 실행 됨..
        {
            time -= Time.deltaTime;
            timetxt.text = time.ToString("N1");

            if (time <= 0.00f)
            {
                Time.timeScale = 0.0f;
                EndGame();
                BGM.instance.SpeedUp(0);
                timetxt.text = "<color=black>" + time.ToString("N1") + "</color>";
            }
            else if (time < 10.00f)
            {
                BGM.instance.SpeedUp(2);
                timetxt.text = "<color=red>" + time.ToString("N1") + "</color>";
            }
            else if (time < 30.00f)
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
        
        string firstCardImage = firstCard.transform.Find("Front").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImage = secondCard.transform.Find("Front").GetComponent<SpriteRenderer>().sprite.name;
        matchTry++;

        if (firstCardImage == secondCardImage)
        {

            //audioManager 에서 받아와서 true 코드 실행
            audioManager.instance.matchPlay();
            

            firstCard.GetComponent<Card>().DestroyCard();
            secondCard.GetComponent<Card>().DestroyCard();
            //Debug.Log(firstCard.GetComponent<Card>().Owner);
            //ownerNameTxt.text = firstCard.GetComponent<Card>().Owner;

            ownerName = GameManager.I.firstCard.GetComponent<Card>().Owner;

<<<<<<< Updated upstream
            //매칭 성공 UI가 나타났다가 사라짐
            matchCanvas.SetActive(true);
            Invoke("HideMatchUI", 1.0f);
=======
            //��Ī ���� UI�� ��Ÿ���ٰ� �����
            Instantiate(matchCanvas);
            
>>>>>>> Stashed changes

            //매치 성공 카드 카운터
            matchCount++;

        }
        else
        {
<<<<<<< Updated upstream
            Debug.Log("UnMatched!");
            //audioManager 에서 받아와서 false 코드 실행
=======
            //audioManager ���� �޾ƿͼ� false �ڵ� ����
>>>>>>> Stashed changes
            audioManager.instance.unmatchPlay();


            firstCard.GetComponent<Card>().CloseCard();
            secondCard.GetComponent<Card>().CloseCard();

<<<<<<< Updated upstream
            //매칭 실패 UI가 나타났다가 사라짐
            unMatchCanvas.SetActive(true);
            Invoke("HideUnMatchUI", 1.0f);
=======
            //��Ī ���� UI�� ��Ÿ���ٰ� �����
            Instantiate(unMatchCanvas);
>>>>>>> Stashed changes

            //시간 2초 감소..
            matchFailed++;
            time -= 1;
        }
        firstCard = null;
        secondCard = null;
    }

<<<<<<< Updated upstream
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
=======
    //��Ī ���� �� UI ����
>>>>>>> Stashed changes
    void EndGame()
    {
        //점수 = 남은 시간("N0") * 10 + 매칭 성공(횟수 * 50) - 매칭 실패(횟수 * 15)
        totalScore = ((int)time * 10) + (matchCount * 50) - (matchFailed * 15);
        
        timetxt.text = $"남은 시간 : {time.ToString("N1")}";
        trytxt.text = $"시도 횟수 : {matchTry}";
        /*counttxt.text = $"점수 : {matchCount}";*/
        counttxt.text = "점수 : " + totalScore.ToString();

        if(bestScore < totalScore)
        {
            SaveBestScore(totalScore);
        }

        Time.timeScale = 0f;
        endcanvas.SetActive(true);
        TimeCanvas.SetActive(false);
        BGM.instance.SpeedUp(0);
    }


    void SpawnUI()
    {
        Instantiate(Resources.Load<GameObject>("UI/BestScore"));
    }

    void LoadBestScore()
    {
        switch(cardDealer.stage)
        {
            case CardDealer.EStage.Card16EA:
                if (PlayerPrefs.HasKey("4by4BestScore"))
                {
                    bestScore = PlayerPrefs.GetInt("4by4BestScore");
                }
                break;

            case CardDealer.EStage.Card36EA:
                if (PlayerPrefs.HasKey("6by6BestScore"))
                {
                    bestScore = PlayerPrefs.GetInt("6by6BestScore");
                }
                break;
        }
    }

    void SaveBestScore(int bestScore)
    {
        switch (cardDealer.stage)
        {
            case CardDealer.EStage.Card16EA:
                PlayerPrefs.SetInt("4by4BestScore", totalScore);
                break;

            case CardDealer.EStage.Card36EA:
                PlayerPrefs.SetInt("6by6BestScore", totalScore);
                break;
        }
    }

    public int GetBestScore()
    {
        return bestScore;
    }
    
    //3초 이상 secondCard를 뒤집지 않으면 firstCard를 초기화 합니다.
    void unPickCard()
    {
        if(firstCard != null &&  secondCard == null)
        {
            PickTime += Time.deltaTime;
        }
        else
        {
            PickTime = 0f;
        }
        if(PickTime > 3.0f)
        {
            firstCard.GetComponent<Card>().CloseCard();
            firstCard = null;
            PickTime = 0f;
        }
    }
}
