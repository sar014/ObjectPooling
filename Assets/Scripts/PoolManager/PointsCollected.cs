using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsCollected : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI rewards;
    public float points;
    WaitForSeconds waitForSeconds;
    PoolManager poolManager;
    AutoLeftRight autoLeftRight;
    bool increasedDifficulty = false;

    void Start()
    {
        
        poolManager = GetComponent<PoolManager>();
        autoLeftRight = GetComponent<AutoLeftRight>();
        waitForSeconds = new WaitForSeconds(10f);
        StartCoroutine(CollectingPoints());

    }

    private void Update() 
    {
        if(points==5 && !increasedDifficulty)
        {
            IncreaseDifficulty();
        }
        else if(points==10 && increasedDifficulty)
        {
            IncreaseDifficultyAgain();
        }
       
    }


    IEnumerator CollectingPoints()
    {
        while (true)
        {
            points++; 
            rewards.SetText("Points "+points.ToString());
            Debug.Log("Points: " + points); 
            yield return waitForSeconds; 
        }
    }

    void IncreaseDifficulty()
    {
        poolManager.spawnInterval-= 0.5f;
        poolManager.objectLifeTime -= 2;
        autoLeftRight.speed+=10f;
        autoLeftRight.TimeInterval-=2f;

        increasedDifficulty = true;
    }

    void IncreaseDifficultyAgain()
    {
        poolManager.spawnInterval-= 0.1f;
        poolManager.objectLifeTime -= 2;
         autoLeftRight.speed+=10f;
        autoLeftRight.TimeInterval-=1f;
        increasedDifficulty = false;
    }
}
