using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

public class TutorialLevel1 : Tutorial
{
    public Adventurer blueAdventurer;
    public Adventurer greenAdventurer;
    public Adventurer secondGreenAdventurer;
    public GameObject CrusherButton;

    private void Start()
    {
        setup();
        GoToStep(1);
    }

    public override void GoToStep(int id)
    {
        switch (id) {
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
                Step12();
                break;
            case 13:
                break;
        }
    }

    protected override void setup() {

        tutorialTextBalloon.SetActive(true);
        ThoughtBubble.SetActive(false);
        blueAdventurer.isMoving = false;
        greenAdventurer.isMoving = false;
        secondGreenAdventurer.isMoving = false;
        CrusherButton.GetComponent<Collider2D>().enabled = false;
    }

    private void Step1()
    {

        Camera.GetComponent<CameraMovement>().enabled = false;
        Camera.GetComponent<PixelPerfectCamera>().enabled = false;
        Camera.transform.position = new Vector3(19, -0.15f, -1.5f);
        Camera.GetComponent<Camera>().orthographicSize = 1;
        tutorialText.text = "This is Steve. Steve is very cute.";
    }

    private void Step2()
    {
        steve.ChangeHunger(new List<AdventurerType>() { AdventurerType.BLUE });
        base.zoomCamera(1.5f, 1);
        tutorialText.text = "Steve is also ravenous.";
        ThoughtBubble.SetActive(true);
    }

    private void Step3()
    {
        tutorialText.text = "Steve is very picky in what he wants to eat. \n He doesn't want to upset his stomach.";
    }

    private void Step4()
    {
        base.zoomCamera(2f, 1);
        tutorialText.text = "He is hungry for some blue adventurers. \n Oh, here is one now.";
    }

    private void Step5()
    {
        tutorialTextBalloon.SetActive(false);
        StartCoroutine(waitForAdventurerToDie());
        blueAdventurer.isMoving = true;
    }

    IEnumerator waitForAdventurerToDie()
    {
        yield return new WaitUntil(() => blueAdventurer == null);
        nextStep();
    }

    private void Step6()
    {
        tutorialTextBalloon.SetActive(true);
        steve.ChangeHunger(new List<AdventurerType>() { AdventurerType.BLUE, AdventurerType.BLUE, AdventurerType.BLUE });
        tutorialText.text = "That adventurer was delicious, but his tummy was still rumbly.";
    }

    private void Step7()
    {
        zoomCamera(4.21875f, 1);
        tutorialText.text = "Steve sees another adventurer up ahead! \n ..but this one isn't blue.";
    }

    private void Step8() {
        disableTutorialTextButton();
        Camera.GetComponent<PixelPerfectCamera>().enabled = true;
        tutorialText.text = "They appear to be standing under one of Steve's crushers. \n Press the red button to get rid of this nasty snack.";
        StartCoroutine(waitForGreenToDie());
        CrusherButton.GetComponent<Collider2D>().enabled = true;

    }

    private IEnumerator waitForGreenToDie() {
        yield return new WaitUntil(() => greenAdventurer == null);
        nextStep();
    }

    private void Step9()
    {
        enableTutorialTextButton();
        tutorialText.text = "By pressing one such buttons, you can arm the trap. \n The next adventurer that walks by will get squished!";
    }

    private void Step10()
    {
        disableTutorialTextButton();
        tutorialText.text = "These traps remain armed for a few seconds. Now, give it a try!";
        StartCoroutine(armTrap());
    }

    private IEnumerator armTrap()
    {
        yield return new WaitUntil(() => CrusherButton.GetComponent<TrapButton>().isTriggered == false);
        yield return new WaitUntil(() => CrusherButton.GetComponent<TrapButton>().isTriggered == true);
        secondGreenAdventurer.isMoving = true;
        yield return new WaitUntil(() => secondGreenAdventurer == null);
        nextStep();
    }

    private void Step11() {
        enableTutorialTextButton();
        tutorialText.text = "Help Steve eat the yummy blue adventurers, and squish all the yuckie green adventurers.";
        moveCamera(new Vector3(13.8f, -.15f, -1.5f),1);
    }

    private void Step12()
    {
        tutorialTextBalloon.SetActive(false);
        spawner.StartSpawning();
    }
}
