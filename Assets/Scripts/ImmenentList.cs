using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ImmenentList : MonoBehaviour
{
    public List<Spawner> spawners;
    public TextMeshProUGUI purple;
    public TextMeshProUGUI green;
    public TextMeshProUGUI blue;

    private int purpleCount = 0;
    private int greenCount = 0;
    private int blueCount = 0;

    private void Start() {
        foreach (Spawner spawner in spawners) {
            foreach (Adventurer adventurer in spawner.adventurers) {
                switch (adventurer.type) {
                    case AdventurerType.BLUE:
                        blueCount++;
                        break;
                    case AdventurerType.GREEN:
                        greenCount++;
                        break;
                    case AdventurerType.PURPLE:
                        purpleCount++;
                        break;
                }
            }
        }

        purple.text = $"x {purpleCount}";
        green.text = $"x {greenCount}";
        blue.text = $"x {blueCount}";
    }
}
