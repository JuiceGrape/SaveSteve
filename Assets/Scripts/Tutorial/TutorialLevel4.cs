using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialLevel4 : Tutorial
{
    public Adventurer FirstAdventurer;
    public Adventurer SecondAdventurer;

    public GameObject StartSpawningButton;
    public MovementBase firstEntrance;

    private Vector3 startPositionCamera;

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
                //Step9();
                break;
            case 10:
                //Step10();
                break;
            case 11:
                //Step11();
                break;
            case 12:
                //Step12();
                break;
        }
    }

    protected override void setup()
    {
        startPositionCamera = Camera.transform.position;
        FirstAdventurer.isMoving = false;
        SecondAdventurer.isMoving = false;
        SecondAdventurer.gameObject.SetActive(false);
        StartSpawningButton.SetActive(false);
        firstEntrance.isClickable = false;
    }

    private void Step1()
    {
        tutorialText.text = "Ohno, there are 3 hallways. Use the W key to look at the floor above.";
        StartCoroutine(WaitForMovement());
    }

    private IEnumerator WaitForMovement()
    {
        disableTutorialTextButton();
        yield return new WaitUntil(() => Camera.transform.position.y >= 3.5);

        tutorialText.text = "You can use the S key to go down a floor. Go down twice.";

        yield return new WaitUntil(() => Camera.transform.position.y <= -3.5);
        nextStep();
    }

    private void Step2()
    {
        enableTutorialTextButton();
        tutorialText.text = "You can move left and right using the A and D buttons.";
    }

    private void Step3()
    {
        Camera.GetComponent<CameraMovement>().enabled = false;
        tutorialText.text = "Adventurers will use these entrances to go up or down a floor.";
        moveCamera(new Vector3(9.44f, 1.8f, -5), 1);
    }

    private void Step4()
    {
        StartCoroutine(WaitForAdventurerToGoThroughPassage());
    }

    private IEnumerator WaitForAdventurerToGoThroughPassage()
    {
        HideTutorialTextBubble();
        FirstAdventurer.isMoving = true;
        yield return new WaitUntil(() => FirstAdventurer.transform.position.x >= 11);
        FirstAdventurer.isMoving = false;
        nextStep();
    }

    private void Step5()
    {
        ShowTutorialTextBubble();
        tutorialText.text = "These entrances change their exit with every visitor they get.";
    }

    private void Step6()
    {
        tutorialText.text = "alternatively, you can click on the sign or entrance to change it's destination. \n Give it a try! Make it so the next adventurer stays on the same floor.";
        StartCoroutine(WaitForEntrance());
    }

    private IEnumerator WaitForEntrance()
    {
        firstEntrance.isClickable = true;
        disableTutorialTextButton();
        yield return new WaitUntil(() => firstEntrance.currentState == 2);
        SecondAdventurer.gameObject.SetActive(true);
        SecondAdventurer.isMoving = true;
        yield return new WaitUntil(() => SecondAdventurer.transform.position.x >= 11);
        SecondAdventurer.isMoving = false;
        nextStep();
    }

    private void Step7()
    {
        enableTutorialTextButton();
        moveCamera(startPositionCamera, 1);
        tutorialText.text = "Uhoh, Steve's tummy is grumbling again. Get to work!";
    }

    private void Step8()
    {
        FirstAdventurer.Die();
        SecondAdventurer.Die();
        HideTutorialTextBubble();
        StartSpawningButton.SetActive(true);
        Camera.GetComponent<CameraMovement>().enabled = true;
    }
}
