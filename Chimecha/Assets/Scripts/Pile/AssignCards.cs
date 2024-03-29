using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignCards : MonoBehaviour
{
    [SerializeField] GameObject fightPanel;
    [SerializeField] GameObject pilePanel;
    [SerializeField] List<GameObject> pileList;
    bool doneDistributing = false;
    private void Start()
    {
        Debug.Log("Created");
    }
   
    public void StartDistribution()
    {
        StartCoroutine(GiveCards());
    }
    IEnumerator GiveCards()
    {
        while (pileList.Count > 0)
        {
            int destroyIndex = Random.Range(0, pileList.Count);
            GameObject cardToDestroy = pileList[destroyIndex];
            GameObject.Destroy(cardToDestroy);
            pileList.RemoveAt(destroyIndex);
            yield return new WaitForSeconds(.1f);
        }
        fightPanel.SetActive(true);
        pilePanel.SetActive(false);
    }    
}
