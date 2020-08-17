using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] ShopStatusValue statusValue = default;
    [SerializeField] Image currentTowerImage = default;
    [SerializeField] Transform evolutionsParent = default;
    [SerializeField] GameObject evolutionPrefab = default;
    [SerializeField] Inventory inventory = default;
    [SerializeField] GameObject basicTowerShop = default;
    [SerializeField] GameObject selectedTowerShop = default;
    [SerializeField] GameObject towerPlaceHolderPrefab = default;
    private GameNode currentNode;

    private void Start()
    {
        OpenBasicShop();
    }
    public void OpenShop(GameNode node)
    {
        selectedTowerShop.SetActive(true);
        basicTowerShop.SetActive(false);
        DestroyAllChildren(evolutionsParent);
        currentNode = node;
        var data = node.Tower.GetData();
        
        currentTowerImage.sprite = data.sprite;
        for(int i=0; i < data.evolutions.Length; i++)
        {
            GameObject optionObject = Instantiate(evolutionPrefab, evolutionsParent);
            EvolutionShopOption option = optionObject.GetComponent<EvolutionShopOption>();
            option.Init(data.evolutions[i],this);
        }

    }

    private void DestroyAllChildren(Transform parent)
    {
        for(int i=0; i < parent.childCount; i++)
        {
            Destroy(parent.GetChild(i).gameObject);
        }
    }

    private void OpenBasicShop()
    {
        selectedTowerShop.SetActive(false);
        basicTowerShop.SetActive(true);
    }

    public void Clean()
    {
        DestroyAllChildren(evolutionsParent);
        currentNode = null;
        OpenBasicShop();
    }
    public void TryBuyEvolutionInCurrentTower(Evolution evolution)
    {
        if(inventory.CurrentGold >= evolution.cost)
        {
            inventory.ReduceGold(evolution.cost);
            Tower newTower = currentNode.Tower.Evolve(evolution);
            currentNode.SetTower(newTower);
            OpenShop(currentNode);
        }
    }

    public void TryBuyNewTower(Evolution evolution)
    {
        if (!statusValue.Status.Equals(ShopStatus.None))
            return;
        if (inventory.CurrentGold >= evolution.cost)
        {
            inventory.ReduceGold(evolution.cost);
            //Instanciar.
            GameObject towerObject = Instantiate(towerPlaceHolderPrefab, Vector3.zero, Quaternion.identity);
            TowerPlaceHolder placeholder = towerObject.GetComponent<TowerPlaceHolder>();
            placeholder.Init(evolution.tower);
            statusValue.SetStatus(ShopStatus.Buying);


           
        }
    }
}
