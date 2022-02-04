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

    [Header("Testing size lerp")]
    public float CardSizeLerp;

    public void _MoveCardsSpawnedCards()
    {
        StartCoroutine(MoveCards(CardPilePos.transform, CardSpawnPoint));
    }

    public void _MoveCardsToDiscard(Transform _card)
    {
        StartCoroutine(MoveToDiscard(_card));
        //StartCoroutine(LerpCardSize(_card, CardSizeLerp));
    }

    public void _MoveCardsToPile(Transform _card)
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

    public IEnumerator MoveCardsToPile(Transform _card)
    {
        StartCoroutine(LerpCardPosition(CardPilePos.transform, 0.3f, _card.transform));
        _card.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        _card.transform.SetParent(CardPilePos.transform);
        _card.gameObject.SetActive(false);

        UpdateChildCountUI();
        // CardPileChildAmount = CardPilePos.transform.childCount;
    }

    public IEnumerator MoveToDiscard(Transform _card)
    {
        StartCoroutine(LerpCardPosition(CardDiscardPilePos.transform, 0.3f, _card.transform));
        _card.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        _card.transform.SetParent(CardDiscardPilePos.transform);
        _card.gameObject.SetActive(false);
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
            CardPilePos.transform.GetChild(randomVar).gameObject.SetActive(true);
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
            //print(i);
            currentPos.transform.GetChild(i).gameObject.SetActive(true);
            StartCoroutine(LerpCardPosition(tragetPos, 0.3f, currentPos.transform.GetChild(i)));
            UpdateChildCountUI();
            // currentPos.transform.GetChild(i).gameObject.SetActive(false);
            yield return new WaitForSeconds(0.1f);//DO NOT CHANGE DURATION OR IT WILL GET FUCKY

            // currentPos.transform.GetChild(i).gameObject.SetActive(false);
            // UpdateChildCountUI();
        }
    }

    public IEnumerator LerpCardSize(Transform _card, float durationCardSize){
        print("LerpCardSize is activated");
        float time = 0;
        Vector3 initialScale = _card.transform.localScale;
        //Vector3 oldSize = _card.transform.GetComponent<RectTransform>().sizeDelta;
        Vector3 newSize = new Vector3(initialScale.x / 2.5f, initialScale.y / 2.5f);
        

        while(time <= 1){
            _card.transform.localScale = Vector3.Lerp(initialScale, newSize, time);
            time += Time.deltaTime * 0.5f;
            yield return null;
        }
        transform.localScale = newSize;

        // while (time < durationCardSize)
        // {   print("size: "+_card.transform.GetComponent<RectTransform>().sizeDelta);
        //     _card.transform.GetComponent<RectTransform>().sizeDelta = Vector2.Lerp(oldSize, newSize, time / durationCardSize);
        //     time += Time.deltaTime;
        //     yield return null;
        // }
        print("LerpCardSize is done");
        print("NewSize: " + _card.transform.localScale);
        //currentCardPosition.position = targetPosition.transform.position;
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

    public IEnumerator CardSizeChanger( GameObject _card,float seconds){
        
        RectTransform rt = _card.GetComponent<RectTransform>();
        yield return new WaitForSeconds(seconds);
    }

    public void UpdateChildCountUI(){
        CardPileChildAmount = CardPilePos.transform.childCount;
        CardPileText.text = CardPileChildAmount.ToString();
        
        DiscardChildAmount = CardDiscardPilePos.transform.childCount;
        DiscardPileText.text = DiscardChildAmount.ToString();
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
