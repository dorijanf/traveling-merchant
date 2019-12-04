using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldUI : MonoBehaviour
{
    [Header("References:")]
    public Text text;
    public GameObject player;
    private Gold gold;
    private int value;

    void Awake()
    {
        gold = player.GetComponent<Gold>();
    }

    private void Update()
    {
        SetGoldText();
    }

    private void SetGoldText()
    {
        value = gold.gold;
        text.text = value.ToString();
    }
}
