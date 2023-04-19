using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchCharaButton : MonoBehaviour
{
    [SerializeField] GameObject currentPrefab;
    [SerializeField] Sprite kachinaSprite;
    [SerializeField] Sprite rosaSprite;
    [SerializeField] Sprite lolaSprite;
    [SerializeField] Sprite margotSprite;
    [SerializeField] GameObject kachinaPrefab;
    [SerializeField] GameObject rosaPrefab;
    [SerializeField] GameObject lolaPrefab;
    [SerializeField] GameObject margotPrefab;

    SwitchChara switchChara;

    void Start()
    {
        switchChara = FindObjectOfType<SwitchChara>();
        currentPrefab = rosaPrefab;
        lolaPrefab.SetActive(false);
        kachinaPrefab.SetActive(false);
        margotPrefab.SetActive(false);
    }
    public void SwitchPrefabToKachina() {

        //currentPrefab.GetComponent<SpriteRenderer>().sprite = kachinaSprite;
        currentPrefab.GetComponent<Renderer>().enabled = false;
        //currentPrefab.SetActive(false);
        //kachinaPrefab.SetActive(true);
        //currentPrefab = kachinaPrefab;
        //switchChara.SwitchOff();
    }
    public void SwitchToRosa() {

        //currentPrefab.GetComponent<SpriteRenderer>().sprite = rosaSprite;
        currentPrefab = rosaPrefab;
        switchChara.SwitchOff();
    }
    public void SwitchToMargot() {

        currentPrefab.GetComponent<SpriteRenderer>().sprite = margotSprite;
        switchChara.SwitchOff();
    }
    public void SwitchToLola() {

        currentPrefab.GetComponent<SpriteRenderer>().sprite = lolaSprite;
        switchChara.SwitchOff();
    }

    public void DebugHere()
    {
        Debug.Log("Button working");
    }
}


/*using UnityEngine;
using UnityEngine.InputSystem;

public class PrefabSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject prefab1;
    [SerializeField] private GameObject prefab2;
    private GameObject currentPrefab;

    private void Start()
    {
        // Set initial prefab to prefab1
        currentPrefab = prefab1;
        currentPrefab.SetActive(true);
        prefab2.SetActive(false);
    }

    public void SwitchPrefab()
    {
        // Switch between prefabs
        if (currentPrefab == prefab1)
        {
            currentPrefab.SetActive(false);
            prefab2.SetActive(true);
            currentPrefab = prefab2;
        }
        else
        {
            currentPrefab.SetActive(false);
            prefab1.SetActive(true);
            currentPrefab = prefab1;
        }
    }
}
*/