using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableConditionallyOnComplete : MonoBehaviour
{
    public bool shouldComplete = false;
    // Start is called before the first frame update
    void Start()
    {
        bool shouldDisable = false;
        
        if (!shouldComplete)
            shouldDisable = true;
        
        for (int i = 1; i < GameMenu.completedLevels.Length; i++)
        {
            if(shouldComplete)
            {
                if (!GameMenu.completedLevels[i])
                {
                    shouldDisable = true;
                }
            }
            else
            {
                if (!GameMenu.completedLevels[i])
                {
                    shouldDisable = false;
                }
            }
        }
        gameObject.SetActive(!shouldDisable);
    }
}
