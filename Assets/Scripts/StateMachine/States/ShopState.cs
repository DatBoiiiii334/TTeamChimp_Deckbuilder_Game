using System.Collections;
using UnityEngine;

public class ShopState : State
{
    public GameObject CardPrefab, CardSpawnPoint;

    public override void Enter()
    {
        GameManager._instance.CardDeckBlocker.SetActive(false);
        MainMenuState._instance.MainMenu.SetActive(true);
        StartCoroutine(SetupShop());
        FMODUnity.AudioManager._instance.ChangeThemeSong(3);
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
            myCard.GetComponent<DisplayCard>().card = CardPicker.instance_CardPicker.AllNewCardProfiles[Random.Range(0, CardPicker.instance_CardPicker.AllNewCardProfiles.Count)];
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
