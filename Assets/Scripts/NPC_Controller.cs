using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NPC_Controller : MonoBehaviour {

    public Text myText, eagleText;
    private int myCounter = 0;
    private int currentSceneIndex;
    bool inRange = false;

	// Use this for initialization
	void Start () {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 1)
            myCounter = 4;
        else if (currentSceneIndex == 2)
            myCounter = 7;
        else if (currentSceneIndex == 3)
            myCounter = 10;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E) && inRange)
        {
            changeDialogue(myCounter);
            myCounter++;
            Debug.Log(myCounter);
        }
	}

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerCharacter")
        {
            Debug.Log("Hello");
            inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerCharacter")
        {
            Debug.Log("Goodbye");
            inRange = false;
        }
    }

    void changeDialogue(int state)
    {
        switch (state)
        {
            case 0:
                myText.text = "Hi! My name is Huido.";
                break;
            case 1:
                myText.text = "Welcome to Fairfeather Island!";
                break;
            case 2:
                myText.text = "Oh no! A huge tsunami is coming! Come, follow me to safety.";
                break;
            case 3:
                SceneManager.LoadScene(currentSceneIndex + 1);
                myCounter = 4;
                break;
            case 5:
                myText.text = "You made it! But we have to save my friend! Quickly, come with me.";
                break;
            case 6:
                SceneManager.LoadScene(currentSceneIndex + 1);
                break;
            case 7:
                myText.text = "Thank you!";
                eagleText.text = "SOS! I need help!!";
                break;
            case 8:
                myText.text = "Do you hear that? C'mon, we have to help them!";
                break;
            case 9:
                SceneManager.LoadScene(currentSceneIndex + 1);
                break;
            case 10:
                myText.text = "You did it! Everyone's safe. Now let's get to safety.";
                break;
            case 11:
                SceneManager.LoadScene(currentSceneIndex + 1);
                break;
        }
    }
}
