using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] public CharacterStatistics characterStats;

    // Start is called before the first frame update
    void Start()
    {
        characterStats = FindObjectOfType<CharacterStatistics>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
