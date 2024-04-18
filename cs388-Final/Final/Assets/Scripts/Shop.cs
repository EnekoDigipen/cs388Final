using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    Inventory inventoryRef;
    public Text CoinText;
    public Text MagnetText;
    public Text PUCoinText;
    public Text ShieldText;
    public Text KeysText;
    public Text SkinText;
    public Text GemsText;
    // Start is called before the first frame update
    void Start()
    {
        inventoryRef = GameObject.FindObjectOfType<Inventory>();
        CoinText.text = inventoryRef.RewardsVar[0].ToString();
        MagnetText.text = inventoryRef.RewardsVar[1].ToString();
        PUCoinText.text = inventoryRef.RewardsVar[2].ToString();
        ShieldText.text = inventoryRef.RewardsVar[3].ToString();
        KeysText.text = inventoryRef.RewardsVar[4].ToString();
        SkinText.text = inventoryRef.RewardsVar[5].ToString();
        GemsText.text = inventoryRef.RewardsVar[6].ToString();
    }

    // Update is called once per frame
    void Update()
    {
        CoinText.text = inventoryRef.RewardsVar[0].ToString();
        MagnetText.text = inventoryRef.RewardsVar[1].ToString();
        PUCoinText.text = inventoryRef.RewardsVar[2].ToString();
        ShieldText.text = inventoryRef.RewardsVar[3].ToString();
        KeysText.text = inventoryRef.RewardsVar[4].ToString();
        SkinText.text = inventoryRef.RewardsVar[5].ToString();
        GemsText.text = inventoryRef.RewardsVar[6].ToString();
    }

    public void AddCoins()
    {
        if(inventoryRef.RewardsVar[6] >= 100)
        {
            inventoryRef.RewardsVar[0] += 100;
            inventoryRef.RewardsVar[6] -= 100;
        }
    }

    public void AddCoins2()
    {
        if(inventoryRef.RewardsVar[6] >= 500)
        {
            inventoryRef.RewardsVar[0] += 500;
            inventoryRef.RewardsVar[6] -= 500;
        }
    }

    public void AddCoins3()
    {
        if(inventoryRef.RewardsVar[6] >= 1000)
        {
            inventoryRef.RewardsVar[0] += 5000;
            inventoryRef.RewardsVar[6] -= 1000;
        }
    }

    public void AddMagnets()
    {
        if(inventoryRef.RewardsVar[0] >= 100)
        {
            inventoryRef.RewardsVar[1]++;
            inventoryRef.RewardsVar[0] -= 100;
        }
    }

    public void Addx2Coins()
    {
        if (inventoryRef.RewardsVar[0] >= 100)
        {
            inventoryRef.RewardsVar[2]++;
            inventoryRef.RewardsVar[0] -= 100;
        }
    }

    public void AddShields()
    {
        if (inventoryRef.RewardsVar[0] >= 100)
        {
            inventoryRef.RewardsVar[3]++;
            inventoryRef.RewardsVar[0] -= 100;
        }
    }

    public void AddKeys()
    {
        if (inventoryRef.RewardsVar[0] >= 500)
        {
            inventoryRef.RewardsVar[4]++;
            inventoryRef.RewardsVar[0] -= 500;
        }
    }

    public void AddSkins()
    {
        if (inventoryRef.RewardsVar[0] >= 5000)
        {
            inventoryRef.RewardsVar[5]++;
            inventoryRef.RewardsVar[0] -= 5000;
        }
    }

    public void AddGems()
    {
        inventoryRef.RewardsVar[6] += 100;
    }

    public void AddGems1()
    {
        inventoryRef.RewardsVar[6] += 500;
    }

    public void AddGems2()
    {
        inventoryRef.RewardsVar[6] += 1000;
    }

    public void BackToMenu()
    {
        Invoke("RealBackToMenu", 1);
    }

    void RealBackToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
