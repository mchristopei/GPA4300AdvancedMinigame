using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenuUi : MonoBehaviour
{
    private PlayerStats playerStats;
    private UpgradeMenu upgradeMenu;

    bool healthPlus;
    bool healthMinus;


 

   
    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        upgradeMenu = FindObjectOfType<UpgradeMenu>();
    }

    
    
    void Update()
    {
       
    }
}
