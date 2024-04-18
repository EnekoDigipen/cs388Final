using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //0-Coins
    //1-Magnet
    //2-Coins*2
    //3-Shield
    //4-Keys
    //5-Skins
    //6-Gems
    public int[] RewardsVar;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateRewards()
    {
        int random = Random.Range(1, 100);
        int idx = 0;
        if (random <= 20)
        {
            random = Random.Range(1, 20);
            idx++;
            if (random <= 6)
            {
                random = Random.Range(1, 6);
                idx += 3;
                if (random == 1)
                    RewardsVar[++idx]++;
                else
                    RewardsVar[idx]++;
            }
            else
            {
                random = Random.Range(0, 99);
                if (random < 33)
                    RewardsVar[idx]++;
                idx++;
                if(random >= 33 && random < 66)
                    RewardsVar[idx]++;
                idx++;
                if(random >= 66)
                    RewardsVar[idx]++;
            }
        }
        else
            RewardsVar[idx] += Random.Range(20, 150);
    }
}
