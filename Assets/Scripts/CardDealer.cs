// Date : 2023. 10. 30
// Person : ¹ÚÁØ¿í

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardDealer : MonoBehaviour
{
    public GameObject prefab_Card;
    GameObject deck;
    public float placeSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        deck = new GameObject();
        deck.name = "Cards";
        StartCoroutine(ISpawnCard());
    }

    IEnumerator ISpawnCard()
    {
        int[] cardNumbers = { 0, 0, 1, 1, 4, 4, 5, 5, 8, 8, 9, 9, 12, 12, 13, 13 };
        cardNumbers = cardNumbers.OrderBy(x => UnityEngine.Random.Range(-1.0f, 1.0f)).ToArray();

        for (int i = 0; i < cardNumbers.Length; ++i)
        {
            GameObject go = Instantiate(prefab_Card, transform.position, transform.rotation);
            go.transform.parent = deck.transform;
            Card card = go.GetComponent<Card>();

            string spriteName = "card" + cardNumbers[i].ToString();
            // cardNumbers[i] / 4 -> to Enum -> Set Name 
            card.SetCardImage(Resources.Load<Sprite>(spriteName));

            int x = i % 4;
            int y = i / 4;
            Vector3 pos = new Vector3(-2.1f + 1.4f * x, -3.1f + 1.7f * y, 0);
            yield return new WaitForSeconds(placeSpeed);
            card.Place(pos);
        }
        transform.Find("OutLine").gameObject.SetActive(false);

        yield return new WaitForSeconds(1.0f);
        ShowDeck();

        yield return new WaitForSeconds(1.0f);
        CloseDeck();
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
