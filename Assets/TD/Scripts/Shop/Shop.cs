using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] Image currentTowerImage = default;
    [SerializeField] Transform evolutionsParent = default;
    [SerializeField] GameObject evolutionPrefab = default;

    public TowerData TEST_data;

    private void Start()
    {
        OpenShop(TEST_data);
    }
    public void OpenShop(TowerData data)
    {
        currentTowerImage.sprite = data.sprite;
        for(int i=0; i < data.evolutions.Length; i++)
        {
            GameObject optionObject = Instantiate(evolutionPrefab, evolutionsParent);
            EvolutionShopOption option = optionObject.GetComponent<EvolutionShopOption>();
            option.Init(data.evolutions[i]);
        }

    }
}
