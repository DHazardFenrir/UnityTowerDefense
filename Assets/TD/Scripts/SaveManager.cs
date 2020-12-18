using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] SaveData saveData = default;
    [SerializeField] Transform player = default;



    SaveSystem saveSystem;
    void Awake()
    {
        saveSystem = new SaveSystem();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
        if (Input.GetKeyDown(KeyCode.S))
            Save();
    }

    private void Load()
    {
        saveData = saveSystem.Load();
        player.position = saveData.lastPosition.ToVector3();
    }

    private void Save()
    {
        saveData.lastPosition = SerializedVector3.FromVector3(player.position);
        saveSystem.Save(saveData);

    }
}
