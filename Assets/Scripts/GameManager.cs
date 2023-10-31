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

    void Awake()
    {
        I = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;

    }

    // Update is called once per frame
    void Update()
    { 

    }

    public void testMatched()
    {
        
    }
    //��ġ �õ� �Լ�
    public void IsMatched()
    {
        string firstCardImage = firstCard.transform.Find("Front").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImage = secondCard.transform.Find("Front").GetComponent<SpriteRenderer>().sprite.name;
        matchTry++;
        if (firstCardImage == secondCardImage)
        {
            //audioManager ���� �޾ƿͼ� true �ڵ� ����
            //firstCard.GetComponent<card>().DestroyCard();
            //secondCard.GetComponent<card>().DestroyCard();

            //��ġ ���� �� Text ��ȯ switch�� ����


            //��Ī ���� UI�� ��Ÿ���ٰ� ����� ���� ����
            matchCanvas.SetActive(true);
            Invoke("hideMatchUI", 0.5f);

            //��ġ ���� ī�� ī����
            matchCount++;

            int childLeft = GameObject.Find("Cards").transform.childCount;
            if (childLeft == 2)
            {
                Invoke("EndGame", 1.1f);
            }
        }
        else
        {
            //audioManager ���� �޾ƿͼ� false �ڵ� ����
            //firstCard.GetComponent<card>().closeCard();
            //secondCard.GetComponent<card>().closeCard();

            //��Ī ���� UI�� ��Ÿ���ٰ� ����� ���� ����
            unMatchCanvas.SetActive(true);
            Invoke("hideUnmatchUI", 0.5f);
        }
        firstCard = null;
        secondCard = null;
    }

    //��Ī��� UI Hide
    public void hideMatchUI()
    {
        matchCanvas.gameObject.SetActive(false);
    }
    public void hideUnmatchUI()
    {
        unMatchCanvas.SetActive(false);
    }

    //��Ī ���� �� UI ����
    void EndGame()
    {
        trytxt.text = $"�õ� Ƚ�� : {matchTry}";
        counttxt.text = $"���� : {matchCount}";
        //Time.timeScale = 0f;
        endcanvas.SetActive(true);
    }

}
