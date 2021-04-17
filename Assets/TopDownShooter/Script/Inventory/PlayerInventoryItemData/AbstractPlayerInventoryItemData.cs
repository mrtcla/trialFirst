﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace topDownShooter.Inventory
{
    public enum InventoryItemData{Canon, Body};

    public abstract class AbstractPlayerInventoryItemData<T> : AbstractBasePlayerInventoryItemData where T : AbstractPlayerInventoryItemMono

    {
    [SerializeField] protected string _itemId;

    [SerializeField] protected InventoryItemData _InventoryItemData;
    [SerializeField] protected T _prefab; //reference vermek için

    protected T InstantiateAndInitialiazePrefab(Transform parent)
    {
        return Instantiate(_prefab, parent);
    }

    }
}