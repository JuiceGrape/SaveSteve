using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class TextDisplay : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private List<Story> stories;

    [Header("Settings")]
    [SerializeField] private float displayDelay;
    [SerializeField] private int maxLettersPerLine;
    [SerializeField] private CanvasGroup click;

    [Header("Text Objects")]
    [SerializeField] private TextMeshProUGUI uiTextBox;

    [Header("Sound Effect Settings")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float minPitch;
    [SerializeField] private float maxPitch;

    private string display;
    private int currentStory = -1;
    private bool lineCompleted;

    private void Start() {
        NextStory();
    }

    public void NextStory() {
        if (currentStory + 1 > stories.Count - 1) {
            Debug.Log("no more stories");
            return;
        }

        currentStory++;

        stories[currentStory].CurrentLine = -1;

        NextLine();
    }

    public void NextLine() {
        if (stories[currentStory].CurrentLine + 1 > stories[currentStory].lines.Count - 1) {
            Debug.Log("Reached End of Story");
            stories[currentStory].onStoryEnd.Invoke();
            return;
        }

        stories[currentStory].CurrentLine++;

        string[] seperatedWords = stories[currentStory].lines[stories[currentStory].CurrentLine].Split(null);

        display = FixLineFlow(seperatedWords);

        StartCoroutine(DisplayText());
    }

    public string FixLineFlow(string[] seperatedLine) {
        string finalLine = "";
        int count = 0;

        foreach (string word in seperatedLine) {
            count += word.Length + 1;

            if (count > maxLettersPerLine) {
                count = word.Length + 1;
                finalLine += '\n';
            }

            finalLine += word + ' ';
        }

        return finalLine;
    }

    public IEnumerator DisplayText() {
        

        while(uiTextBox.text.Length < display.Length) {
        
            if (display[uiTextBox.text.Length] == '{') {
                yield return new WaitForSecondsRealtime(ProcessDelay() / 1000);
            }

            uiTextBox.text += display[uiTextBox.text.Length];
            audioSource.pitch = Random.Range(minPitch, maxPitch);
            audioSource.Play();
            yield return new WaitForSecondsRealtime(displayDelay);
            lineCompleted = false;
        }

        lineCompleted = true;
        click.alpha = 1;
    }

    public float ProcessDelay() {
        int indexStart = display.IndexOf('{') + 1;
        int indexEnd = display.IndexOf('}');

        float time = 0;
        if (float.TryParse(display.Substring(indexStart, indexEnd - indexStart), out time)) {
            display = display.Remove(indexStart - 1, (indexEnd - indexStart) + 2);
        }

        return time;
    }

    private void LateUpdate() {
        if (lineCompleted == true) {
            if (Input.GetMouseButtonDown(0)) {
                click.alpha = 0;
                uiTextBox.text = "";
                NextLine();
            }
        }
        if (!lineCompleted) {

            if (Input.GetMouseButtonDown(0)) {
                StopAllCoroutines();
                while (uiTextBox.text.Length < display.Length) {

                    if (display[uiTextBox.text.Length] == '{') {
                        ProcessDelay();
                    }

                    uiTextBox.text += display[uiTextBox.text.Length];
                }
                click.alpha = 1;
                lineCompleted = true;
            }
        }
    }
}

[System.Serializable]
public class Story {
    public int CurrentLine { get; set; }

    public List<string> lines;

    [System.Serializable]
    public class StoryEnd : UnityEvent { }
    public StoryEnd onStoryEnd;
}
