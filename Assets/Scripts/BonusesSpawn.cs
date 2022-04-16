using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusesSpawn : MonoBehaviour
{
    public GameManager gm;
    
    public List<GameObject> bonuses;
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(2);
        StartCoroutine(SpawnBonus());
    }

    private IEnumerator SpawnBonus()
    {
        if (gm.isDead) yield break;
        
        Instantiate(bonuses[Random.Range(0, bonuses.Count)], transform);
        yield return new WaitForSeconds(2);
        StartCoroutine(SpawnBonus());
    }
}
