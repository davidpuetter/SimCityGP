using UnityEngine;

public class buildManager : MonoBehaviour
{
        public static buildManager instance;

    void Awake()
    {
        if (instance = null)
        {
        //some shit
            return;
        }
        instance = this;
    }




}
