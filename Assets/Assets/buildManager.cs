﻿using UnityEngine;

public class buildManager : MonoBehaviour
{
        public static buildManager instance;
    //i'll be honest i dont think this is used.
    void Awake()
    {
        if (instance = null)
        {
            return;
        }
        instance = this;
    }




}