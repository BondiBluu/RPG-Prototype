using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public GameObject questBox;
    public TMP_Text questTitle;
    public TMP_Text questDescription;
    public TMP_Text questAssignment;

    public GameObject moneyPrefab;
    public GameObject itemPrefab;
    //public GameObject expPrefab;

    void Start()
    {
        QuestBoxOff();
    }

    public void QuestBoxOff()
    {
        questBox.gameObject.SetActive(false);
    }

    public void QuestBoxOn()
    {
        questBox.gameObject.SetActive(true);
    }
}
