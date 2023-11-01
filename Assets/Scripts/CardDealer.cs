// Date : 2023. 10. 30
// Person : ¹ÚÁØ¿í

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardDealer : MonoBehaviour
{
    public GameObject prefab_Card;
    GameObject deck;
    public float placeSpeed;
    
    public enum EStage { Card16EA = 4, Card36EA = 6 };
    public EStage stage = EStage.Card16EA;
    // Start is called before the first frame update
    void Start()
    {
        CreatePattern();        
        deck = new GameObject();
        deck.name = "Cards";
        StartCoroutine(ISpawnCard());
    }

    IEnumerator ISpawnCard()
    {
        int[] cardNumbers = CreatePattern();
       
        for (int i = 0; i < cardNumbers.Length; ++i)
        {
            GameObject go = Instantiate(prefab_Card, transform.position, transform.rotation);
            go.transform.parent = deck.transform;
            Card card = go.GetComponent<Card>();

            string spriteName = "card" + cardNumbers[i].ToString();
            card.Owner = ((Define.EMemberName)(cardNumbers[i] / 4)).ToString();
            card.SetCardImage(Resources.Load<Sprite>(spriteName));

            // 4 by 4 //
            /*
            int x = i % 4;
            int y = i / 4;
            Vector3 pos = new Vector3(-2.1f + 1.4f * x, -3.1f + 1.7f * y, 0);
            yield return new WaitForSeconds(placeSpeed);
            card.Place(pos);
            */
            
            yield return new WaitForSeconds(placeSpeed);
            card.Place(GetPlacePos(i));
        }
        transform.Find("OutLine").gameObject.SetActive(false);

        yield return new WaitForSeconds(1.0f);
        ShowDeck();

        yield return new WaitForSeconds(1.0f);
        CloseDeck();
        yield return new WaitForSeconds(1.0f);
        GameManager.I.OnTimer();
    }

    Vector3 GetPlacePos(int index)
    {
        int x = index % (int)stage;
        int y = index / (int)stage;
        Vector3 pos = Vector3.zero;

        switch (stage)
        {
            case EStage.Card16EA:
                pos = new Vector3(-2.1f + 1.4f * x, -3.1f + 1.7f * y, 0);
                break;

            case EStage.Card36EA:
                pos = new Vector3(-2.35f + 0.95f * x, -3.75f + 1.15f * y, 0);
                break;
        }
        return pos;
    }

    int[] CreatePattern()
    {
        List<int> pattern = new List<int>();
        int[] perCnt = new int[4];
        
        switch (stage)
        {
            case EStage.Card16EA:
                perCnt = new int[] { 2, 2, 2, 2 };
                break;

            case EStage.Card36EA:
                perCnt = new int[] { 5, 4, 5, 4 };
                break;
        }

        // ¼¯À½
        perCnt = perCnt.OrderBy(x => UnityEngine.Random.Range(-1.0f, 1.0f)).ToArray();
       
        // 
        for(int i = 0; i < (int)Define.EMemberName.Max; ++i)
        {
            for (int j = 0; j < perCnt[i]; ++j)
            {                
                int num = 0;
                do
                {
                    num = UnityEngine.Random.Range(i * 5, (i + 1) * 5);
                } while (pattern.Contains(num));
                
                pattern.Add(num);
                pattern.Add(num);
            }
        }

        return pattern.ToArray().OrderBy(x => UnityEngine.Random.Range(-1.0f, 1.0f)).ToArray();
    }
    void ShowDeck()
    {
        for(int i = 0; i < deck.transform.childCount; ++i)
        {
            deck.transform.GetChild(i).GetComponent<Card>().Show();
        }
    }

    void CloseDeck()
    {
        for (int i = 0; i < deck.transform.childCount; ++i)
        {
            deck.transform.GetChild(i).GetComponent<Card>().CloseCard();
        }
    }
}
