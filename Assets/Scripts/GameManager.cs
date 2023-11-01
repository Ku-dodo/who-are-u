using UnityEngine;
using UnityEngine.SearchService;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //�̱��� ���� ����
    public static GameManager I;

    //�ð� ���� ����
    public GameObject card;
    public GameObject TimeCanvas;
    public Text timetxt;
    float time = 60.0f;

    //ī�� ��ġ
    public bool sortCompleted = false;
    public CardDealer cardDealer;

    //���� ���� ���� ����
    public GameObject endcanvas;

    //Match ���� ����
    public GameObject firstCard;
    public GameObject secondCard;

    //��� â ���� ���� ����
    public Text counttxt;
    public Text trytxt;
    int matchCount;
    int matchTry;
    int matchFailed;
    int totalScore;
    int bestScore = 0;

    //MatchUI ���� ����
    public GameObject matchCanvas;
    public GameObject unMatchCanvas;
    public Text ownerNameTxt;

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
            //44���� Ŭ���� ���θ� �����ϱ� ���� �ڵ�
            PlayerPrefs.SetInt("ClearStage", 1);
            Invoke("EndGame", 1.1f);
        }
    }
    public void OnTimer()
    {
        TimeCanvas.SetActive(true);
        sortCompleted = true;
    }

    //Timer..
    void Timer()
    {   

        if (sortCompleted == true)  // true �϶� Timer�� ���� ��..
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


    //��ġ �õ� �Լ�
    public void IsMatched()
    {
        
        string firstCardImage = firstCard.transform.Find("Front").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImage = secondCard.transform.Find("Front").GetComponent<SpriteRenderer>().sprite.name;
        matchTry++;

        if (firstCardImage == secondCardImage)
        {
            Debug.Log("Matched!");


            //audioManager ���� �޾ƿͼ� true �ڵ� ����
            audioManager.instance.matchPlay();
            

            firstCard.GetComponent<Card>().DestroyCard();
            secondCard.GetComponent<Card>().DestroyCard();
            //Debug.Log(firstCard.GetComponent<Card>().Owner);
            ownerNameTxt.text = firstCard.GetComponent<Card>().Owner;


            //��Ī ���� UI�� ��Ÿ���ٰ� �����
            matchCanvas.SetActive(true);
            Invoke("HideMatchUI", 1.0f);

            //��ġ ���� ī�� ī����
            matchCount++;

        }
        else
        {
            Debug.Log("UnMatched!");
            //audioManager ���� �޾ƿͼ� false �ڵ� ����
            audioManager.instance.unmatchPlay();


            firstCard.GetComponent<Card>().CloseCard();
            secondCard.GetComponent<Card>().CloseCard();

            //��Ī ���� UI�� ��Ÿ���ٰ� �����
            unMatchCanvas.SetActive(true);
            Invoke("HideUnMatchUI", 1.0f);

            //�ð� 2�� ����..
            matchFailed++;
            time -= 1;
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
        //���� = ���� �ð�("N0") * 10 + ��Ī ����(Ƚ�� * 50) - ��Ī ����(Ƚ�� * 15)
        totalScore = ((int)time * 10) + (matchCount * 50) - (matchFailed * 15);
        
        timetxt.text = $"���� �ð� : {time.ToString("N1")}";
        trytxt.text = $"�õ� Ƚ�� : {matchTry}";
        /*counttxt.text = $"���� : {matchCount}";*/
        counttxt.text = "���� : " + totalScore.ToString();

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
}
