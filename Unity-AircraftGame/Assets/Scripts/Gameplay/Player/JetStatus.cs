﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetStatus : MonoBehaviour
{
    public float altitude;
    public float speed;
    public int fuel;
    public int enemiesLeft;

    private static JetStatus instance;
    public static JetStatus Get()
    {
        return instance;
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }
}
