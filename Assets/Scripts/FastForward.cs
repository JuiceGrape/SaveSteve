using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FastForward : MonoBehaviour
{
    [Header("Graphics")]
    [SerializeField] private List<Sprite> speedImages;

    [Header("Settings")]
    [SerializeField] private Image ffwGraphic;

    private int currentSpeed = 0;

    void Start()
    {
        Time.timeScale = 1f;
        ffwGraphic.sprite = speedImages[currentSpeed];
    }

    public void FFWButtonClick() {
        currentSpeed++;
        if (currentSpeed == speedImages.Count) currentSpeed = 0;
        switch (currentSpeed) {
            case 0:
                Time.timeScale = 1f;
                break;
            case 1:
                Time.timeScale = 1.5f;
                break;
            case 2:
                Time.timeScale = 2;
                break;
        }
        ffwGraphic.sprite = speedImages[currentSpeed];
    }
}
