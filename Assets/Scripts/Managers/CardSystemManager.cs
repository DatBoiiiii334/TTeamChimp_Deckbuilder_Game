using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardSystemManager : MonoBehaviour
{
    public static CardSystemManager _instance;
    public List<GameObject> CardsInScene = new List<GameObject>();

    public GameObject CardPilePos, CardDiscardPilePos, CardDeckPos, CardSpawnPoint;
    public int AmountCardsInPLayerHand, CardPileChildAmount, DiscardChildAmount;
    public float cardMoveSpeed;
    public TextMeshProUGUI CardPileText, DiscardPileText;
    private float timer;

    public void _MoveCardsSpawnedCards()
    {
        StartCoroutine(MoveCards(CardPilePos.transform, CardSpawnPoint));
    }

    public void _MoveCardsToDiscard(GameObject _card)
    {
        StartCoroutine(MoveToDiscard(_card));
    }

    public void _MoveCardsToPile(GameObject _card)
    {
        StartCoroutine(MoveCardsToPile(_card));
    }

    public void _MoveCardsToDeck()
    {
        StartCoroutine(MoveToDeck());
    }

    public void ResetCards()
    {
        StartCoroutine(ResetPile());
    }

    public IEnumerator MoveCardsToPile(GameObject _card)
    {
        StartCoroutine(LerpCardPosition(CardPilePos.transform, 0.3f, _card.transform));
       // _card.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        _card.transform.SetParent(CardPilePos.transform);
       // _card.SetActive(false);

        UpdateChildCountUI();
        // CardPileChildAmount = CardPilePos.transform.childCount;
    }

    public IEnumerator MoveToDiscard(GameObject _card)
    {
        StartCoroutine(LerpCardPosition(CardDiscardPilePos.transform, 0.3f, _card.transform));
        //_card.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        _card.transform.SetParent(CardDiscardPilePos.transform);
        //_card.SetActive(false);
        UpdateChildCountUI();
        // DiscardChildAmount = CardDiscardPilePos.transform.childCount;
    }

    public IEnumerator ResetPile(){
        for (int i = 0; i < CardDiscardPilePos.transform.childCount; i++)
        {
            print("ResetPile Activated");
            StartCoroutine(LerpCardPosition(CardPilePos.transform, 0.1f, CardDiscardPilePos.transform.GetChild(i)));
            yield return new WaitForSeconds(0.1f);
            //CardDiscardPilePos.transform.GetChild(i).SetParent(CardPilePos.transform);
            yield return null;
        }
    }

    public IEnumerator MoveToDeck()
    {
        for (int i = 0; i < AmountCardsInPLayerHand; i++)
        {
            int randomVar = Random.Range(0, CardPilePos.transform.childCount);
            StartCoroutine(LerpCardPosition(CardDeckPos.transform, 0.3f, CardPilePos.transform.GetChild(randomVar)));
            //CardPilePos.transform.GetChild(randomVar).gameObject.SetActive(true);
            yield return new WaitForSeconds(0.3f);
            CardPilePos.transform.GetChild(randomVar).SetParent(CardDeckPos.transform);
            yield return null;
            UpdateChildCountUI();
        }
    }

    public IEnumerator MoveCards(Transform tragetPos, GameObject currentPos)
    {
        for (int i = 0; i < currentPos.transform.childCount; i++)
        {
             //currentPos.transform.GetChild(i).gameObject.SetActive(true);
            StartCoroutine(LerpCardPosition(tragetPos, 0.3f, currentPos.transform.GetChild(i)));
            yield return new WaitForSeconds(0.3f);
            UpdateChildCountUI();
            //currentPos.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public IEnumerator LerpCardPosition(Transform targetPosition, float duration, Transform currentCardPosition)
    {
        float time = 0;
        Vector2 startPosition = currentCardPosition.position;

        while (time < duration)
        {
            currentCardPosition.position = Vector2.Lerp(startPosition, targetPosition.transform.position, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        currentCardPosition.position = targetPosition.transform.position;
        //currentCardPosition.SetParent(targetPosition.transform);
    }

    public void UpdateChildCountUI(){
        CardPileChildAmount = CardPilePos.transform.childCount;
        CardPileText.text = CardPileChildAmount.ToString();
        
        DiscardChildAmount = CardDiscardPilePos.transform.childCount;
        DiscardPileText.text = DiscardChildAmount.ToString();
        print("Done");
    }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }
}
