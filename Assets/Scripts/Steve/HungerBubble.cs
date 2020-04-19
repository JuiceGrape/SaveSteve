using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using TMPro;

public class HungerBubble : MonoBehaviour
{
    public TextMeshPro blue;
    public TextMeshPro green;
    public TextMeshPro purple;
    public void Populate(Steve steve)
    {
        int blueAmount = 0;
        int greenAmount = 0;
        int purpleAmount = 0;

        foreach(AdventurerType type in steve.HungerList)
        {
            switch(type)
            {
                case (AdventurerType.BLUE):
                    blueAmount++;
                break;
                case (AdventurerType.GREEN):
                    greenAmount++;
                break;
                case (AdventurerType.PURPLE):
                    purpleAmount++;
                break;
            }
        }
        blue.text = "x " + blueAmount;
        green.text = "x " + greenAmount;
        purple.text = "x " + purpleAmount;

    }

}
