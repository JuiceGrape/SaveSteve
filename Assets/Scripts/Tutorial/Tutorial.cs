using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public TextMeshProUGUI tutorialText;
    public GameObject tutorialTextBalloon;
    public GameObject tutorialTextArrow;
    public Steve steve;
    public GameObject ThoughtBubble;
    public GameObject Camera;
    public Spawner spawner;

    int id = 1;

    protected virtual void setup()
    {

    }

    public virtual void GoToStep(int id)
    {
    }

    protected void ShowTutorialTextBubble()
    {
        tutorialTextBalloon.SetActive(true);
    }

    protected void HideTutorialTextBubble()
    {
        tutorialTextBalloon.SetActive(false);
    }

    protected void disableTutorialTextButton()
    {
        tutorialTextBalloon.GetComponent<Button>().enabled = false;
        tutorialTextArrow.SetActive(false);
    }

    protected void enableTutorialTextButton()
    {
        tutorialTextBalloon.GetComponent<Button>().enabled = true;
        tutorialTextArrow.SetActive(true);
    }

    public void nextStep()
    {
        id++;
        GoToStep(id);
    }

    protected void zoomCamera(float newZoom, float seconds)
    {
        StartCoroutine(zoomCameraCoroutine(Camera.GetComponent<Camera>().orthographicSize, newZoom, seconds));
    }

    protected void moveCamera(Vector3 newLocation, float seconds)
    {
        StartCoroutine(moveCameraCoroutine(Camera.transform.position, newLocation, seconds));

    }

    private IEnumerator zoomCameraCoroutine(float startValue, float endValue, float seconds)
    {
        float time = 0;
        while (time/seconds < 1)
        {
            float result = Mathf.Lerp(startValue, endValue, time/seconds);
            Camera.GetComponent<Camera>().orthographicSize = result;
            yield return new WaitForEndOfFrame();
            time += Time.deltaTime;
        }
        Camera.GetComponent<Camera>().orthographicSize = endValue;
    }

    private IEnumerator moveCameraCoroutine(Vector3 startLocation, Vector3 endLocation, float seconds)
    {
        float time = 0;
        while (time / seconds < 1)
        {
            Vector3 result = Vector3.Lerp(startLocation, endLocation, time / seconds);
            Camera.transform.position = result;
            yield return new WaitForEndOfFrame();
            time += Time.deltaTime;
        }
    }
}
