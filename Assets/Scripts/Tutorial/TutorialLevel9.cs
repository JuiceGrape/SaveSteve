using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialLevel9 : Tutorial
{
    public Adventurer purple;
    public Adventurer blue;
    public Adventurer green;

    public TrapButton mimicButton;
    public TrapButton pitFallButton;
    public TrapButton crusherButton;

    public TrapButton rockButton;

    public GameObject StartSpawningButton;

    private void Start()
    {
        setup();
        GoToStep(1);
    }

    public override void GoToStep(int id)
    {
        switch (id)
        {
            case 1:
                Step1();
                break;
            case 2:
                Step2();
                break;
            case 3:
                Step3();
                break;
            case 4:
                Step4();
                break;
            case 5:
                Step5();
                break;
            case 6:
                Step6();
                break;
            case 7:
                Step7();
                break;
            case 8:
                Step8();
                break;
            case 9:
                Step9();
                break;
            case 10:
                Step10();
                break;
            case 11:
                Step11();
                break;
            case 12:
                //Step12();
                break;
        }
    }

    protected override void setup()
    {
        rockButton.GetComponent<Collider2D>().enabled = false;
        stopAllAdventurers();
        purple.gameObject.SetActive(false);
        blue.gameObject.SetActive(false);
        green.gameObject.SetActive(false);
    }

    private void Step1()
    {
        tutorialText.text = "Wow, Steve has been really hungry. Good thing he has you to help him!";
    }

    private void Step2()
    {
        disableTutorialTextButton();
        blue.gameObject.SetActive(true);
        tutorialText.text = "Oh, here comes another one! \n Here, let me help you out by stopping time.";
        StartCoroutine(waitForButtonPress());
    }

    private IEnumerator waitForButtonPress() {
        Camera.GetComponent<CameraMovement>().enabled = false;
        moveCamera(new Vector3(18.38f, -3.7f, -5), 1);
        yield return new WaitUntil(() => pitFallButton.isTriggered == true);
        HideTutorialTextBubble();
        blue.isMoving = true;
        yield return new WaitUntil(() => blue.transform.position.x >= 20);
        green.gameObject.SetActive(true);
        stopAllAdventurers();
        ShowTutorialTextBubble();
        tutorialText.text = "Did that trap not activate? Must've been a malfunction. \n Oh, here comes another!";
        enableTutorialTextButton();
    }

    private void stopAllAdventurers()
    {
        purple.isMoving = false;
        blue.isMoving = false;
        green.isMoving = false;
    }

    private void Step3()
    {
        moveCamera(new Vector3(18.38f, .15f, -5), 1);
        tutorialText.text = "Executing my patented timestop magic.. \n Go ahead, activate that trap.";
        disableTutorialTextButton();
        StartCoroutine(MimicButtonPress());
    }

    private IEnumerator MimicButtonPress()
    {
        yield return new WaitUntil(() => mimicButton.isTriggered == true);
        HideTutorialTextBubble();
        blue.isMoving = true;
        green.isMoving = true;
        yield return new WaitUntil(() => green.transform.position.x >= 20);
        stopAllAdventurers();
        ShowTutorialTextBubble();
        enableTutorialTextButton();
        tutorialText.text = "Okay.. they just straight up ignored that mimic.";
    }

    private void Step4()
    {
        tutorialText.text = "Well, we can ignore those 2 for now. Here comes another!";
        purple.gameObject.SetActive(true);
    }

    private void Step5()
    {
        tutorialText.text = "Well, third time's the charm! \n Let's crush this one.";
        disableTutorialTextButton();
        StartCoroutine(CrusherButtonPress());
    }

    private IEnumerator CrusherButtonPress()
    {
        moveCamera(new Vector3(18.38f, 4f, -5), 1);
        yield return new WaitUntil(() => crusherButton.isTriggered == true);
        HideTutorialTextBubble();
        blue.isMoving = true;
        green.isMoving = true;
        purple.isMoving = true;
        yield return new WaitUntil(() => purple.transform.position.x >= 20);
        StartCoroutine(stopAdventurerOnX(blue, 30));
        StartCoroutine(stopAdventurerOnX(green, 29));
        StartCoroutine(stopAdventurerOnX(purple, 28));
        enableTutorialTextButton();
        ShowTutorialTextBubble();
        tutorialText.text = "Did they all just really dodge the traps?";
    }

    private IEnumerator stopAdventurerOnX(Adventurer adventurer, float x)
    {
        yield return new WaitUntil(() => adventurer.transform.position.x >= x);
        adventurer.isMoving = false;
    }

    private void Step6()
    {
        tutorialText.text = "By my calculations, blue appears able to dodge pitfall traps, \n green doesn't care about treasure.";
    }

    private void Step7()
    {
        tutorialText.text = "..and purple are immune to crushing traps.";
    }

    private void Step8()
    {
        tutorialText.text = "Ohno, they have made it to Steve! And he's not hungry right now!";
        StopAllCoroutines();
        stopAllAdventurers();
        blue.transform.position = new Vector3(30, 0.02f, 0);
        green.transform.position = new Vector3(29, 0.02f, 0);
        purple.transform.position = new Vector3(28, 0.02f, 0);
        moveCamera(new Vector3(26.5f, 0.15f, -5), 1);
    }

    private void Step9()
    {
        tutorialText.text = "Not to worry, we have our patented R.O.C.K. just for this occasion!";
    }

    private void Step10() {
        tutorialText.text = "Go ahead and press the button.";
        disableTutorialTextButton();
        StartCoroutine(waitForRock());
    }

    private IEnumerator waitForRock()
    {
        rockButton.GetComponent<Collider2D>().enabled = true;
        yield return new WaitUntil(() => purple == null);
        tutorialText.text = "The boulder did it's thing! But more adventurers are coming, and steve doesn't want any of it.";
        enableTutorialTextButton();
    }

    private void Step11()
    {
        HideTutorialTextBubble();
        StartSpawningButton.SetActive(true);
        Camera.GetComponent<CameraMovement>().enabled = true;
    }
}
