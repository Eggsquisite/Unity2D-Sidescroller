using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Eagle_Controller : MonoBehaviour {

    public Text myText;
    private int myCounter = 0;
    private int currentSceneIndex;
    bool inRange = false;

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 4)
            myCounter = 2;
    }

    // Update is called once per frame
    void Update()
    {
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
            inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerCharacter")
        {
            inRange = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "WavySprite")
            SceneManager.LoadScene("Lose");
    }

    void changeDialogue(int state)
    {
        switch (state)
        {
            case 0:
                myText.text = "Thank you. I will remember this. *CAW*";
                break;
            case 1:
                myText.text = "";
                Destroy(gameObject);
                break;
            case 2:
                myText.text = "My life is in your debt. Thank you.";
                break;
            case 3:
                myText.text = "I must leave this place as soon as possible.";
                break;
            case 4:
                myText.text = "There is something not quite right with those two...";
                break;
            case 5:
                myText.text = "It should not take long for my injuries to heal.";
                break;
            case 6:
                myText.text = "On my wings.";
                break;
            case 7:
                myText.text = "Be wary of them, especially the frog...";
                break;
        }
    }
}
