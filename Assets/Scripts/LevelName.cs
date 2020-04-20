using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelName : MonoBehaviour
{
    [SerializeField] private string levelName;
    [SerializeField] private TextMeshProUGUI textBox;
    [SerializeField] private CanvasGroup textContainer;
    [SerializeField] private float waitBeforeFade;
    [SerializeField] private float fadeSpeed;

    private void Start() {
        textContainer.alpha = 1;
        textBox.text = $"{SceneManager.GetActiveScene().name}:\n{levelName}";
        StartCoroutine(FadeLevel());
    }


    private IEnumerator FadeLevel() {
        yield return new WaitForSeconds(waitBeforeFade);

        float current = 0;
        while (current / fadeSpeed < 1) {
            float result = Mathf.Lerp(1, 0, current / fadeSpeed);
            textContainer.alpha = result;
            yield return new WaitForEndOfFrame();
            current += Time.deltaTime;
        }
        textContainer.alpha = 0;
        textContainer.gameObject.SetActive(false);
    }
}
