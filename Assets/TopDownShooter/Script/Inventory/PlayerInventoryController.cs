﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;


namespace topDownShooter.Inventory
{

public class PlayerInventoryController : MonoBehaviour
{
    [SerializeField] private AbstractBasePlayerInventoryItemData[] _inventoryItemDataArray;
    private List<AbstractBasePlayerInventoryItemData> _instantiatedItemDataList;
    public Transform bodyParent;
    public Transform CanonParent;

    public ReactiveCommand ReactiveShootCommand { get; private set; }

    //FOR TESTİNG
    private void Start()
    {
        initializeInventory(_inventoryItemDataArray);
    }

    private void OnDestroy()
    {
        ClearInventory();
    }

    public void initializeInventory(AbstractBasePlayerInventoryItemData[] inventoryItemDataArray)
    {
        if (ReactiveShootCommand != null)
        {
            //adjusting reactive command
            ReactiveShootCommand.Dispose();
        }
        ReactiveShootCommand = new ReactiveCommand();
        
        //clearing old inventory and creating new one
        ClearInventory();
        _instantiatedItemDataList = new List<AbstractBasePlayerInventoryItemData>(inventoryItemDataArray.Length);
        for (int i = 0; i < inventoryItemDataArray.Length; i++)
        {
            var instantiated = Instantiate(_inventoryItemDataArray[i]);
            instantiated.Initialize(this);
            _instantiatedItemDataList.Add(instantiated);
        }
    }

    private void ClearInventory()
    {
        if (_instantiatedItemDataList != null)
        {
            for (int i = 0; i < _instantiatedItemDataList.Count; i++)
            {
                _instantiatedItemDataList[i].Destroy();
            }
        }
    }
}
}
