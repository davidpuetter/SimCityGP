using UnityEngine;

public class buildManager : MonoBehaviour
{
        public static buildManager instance;

    void Awake()
    {
        if (instance = null)
        {
            return;
        }
        instance = this;
    }




}
