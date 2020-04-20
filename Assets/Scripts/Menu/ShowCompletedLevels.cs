using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowCompletedLevels : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 1; i < GameMenu.completedLevels.Length; i++)
        {
            if (GameMenu.completedLevels[i])
            {
                transform.Find("Level (" + i + ")").GetComponentInChildren<TextMeshProUGUI>().color = Color.green;
            }
        }
    }
}
