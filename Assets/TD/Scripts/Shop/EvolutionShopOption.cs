using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EvolutionShopOption : MonoBehaviour
{
    [SerializeField] Image evolutionImage = default;
    [SerializeField] TMP_Text evolutionNameLabel = default;
    [SerializeField] TMP_Text costLabel = default;

    public void Init(Evolution evolution)
    {
        evolutionImage.sprite = evolution.tower.sprite;
        evolutionNameLabel.text = evolution.tower.name;
        costLabel.text = "Cost: " + evolution.cost.ToString();
    }
}
