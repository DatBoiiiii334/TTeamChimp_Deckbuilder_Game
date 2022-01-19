using System.Collections;
using UnityEngine;

public class ShopState : State
{
    public GameObject CardPrefab, CardSpawnPoint;

    public override void Enter()
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName(FMODUnity.AudioManager._instance.parameter, 3);
        GameManager._instance.CardDeckBlocker.SetActive(false);
        StartCoroutine(SetupShop());
    }

    public void PlaceNewCards()
    {
        if(CardSpawnPoint.transform.childCount > 0){
            foreach(Transform _card in CardSpawnPoint.transform){
                Destroy(_card.transform.gameObject);
            }
        }
        for (int i = 0; i < 3; i++)
        {
            GameObject myCard;
            myCard = Instantiate(CardPrefab, CardSpawnPoint.transform);
            myCard.GetComponent<DisplayCard>().card = WinState._instance.AllNewCardProfiles[Random.Range(0, WinState._instance.AllNewCardProfiles.Count)];
            Debug.Log("Name: "+myCard.GetComponent<DisplayCard>().card.name);
        }
    }

    IEnumerator SetupShop(){
        GameManager._instance.FightScene.SetActive(false);
        GameManager._instance.ShopScene.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        GameManager._instance.ShopAnim.SetBool("OpenShop", true);
        PlaceNewCards();
    }

    IEnumerator PackUpShop(){
        GameManager._instance.CardDeckBlocker.SetActive(true);
        GameManager._instance.TransitionScreenAnim.SetTrigger("StartTransition");
        GameManager._instance.ShopAnim.SetBool("OpenShop", false);
        yield return new WaitForSeconds(2f);
        GameManager._instance.ShopScene.SetActive(false);
        myFSM.SetCurrentState(typeof(GridMapState));
    }

    public void ExitShop(){StartCoroutine(PackUpShop());}
}
