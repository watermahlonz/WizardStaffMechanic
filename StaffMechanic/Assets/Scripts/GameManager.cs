using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    //Souls
    public int currentSouls = 0;
    public int maxSouls = 10;
    
    //Ability
    public bool abilityActivated = false;
    
    //UI
    public TMP_Text _soulsText;
    
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    
    private void Update()
    {
        _soulsText.text = currentSouls.ToString();
    }


}
