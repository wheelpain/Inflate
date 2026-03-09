using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutotrial : MonoBehaviour
{
    bool isTutorial2;


   
    public Text tutorialText;
    // Start is called before the first frame update
    void Instructions()
    {
        tutorialText.text = "When near canister, press x to transform into bubble.";
        
    }

    void Intruction2()
    {
        tutorialText.text = "While in bubble form, jumping and dashing will consume bubble metre at the top left. Shift to Dash";
    }

    void LoseTutorial()
    {
        tutorialText.text = "When you health reaches zero, you pass away";
    }

    void WinTutorial()
    {
        tutorialText.text = "When you reach beam of light, you win";
    }

    //public void OnCollisionEnter(Collision collision)
    //{
        
    //    if (collision.gameObject.CompareTag("HeliumCanister"))
    //    {
    //        Instructions();
    //    }
    //    if (collision.gameObject.CompareTag("Tutorial2"))
    //    {
    //        Intruction2();
    //    }
    //    if (collision.gameObject.CompareTag("Tutorial3"))
    //    {
    //        LoseTutorial();
    //    }
    //    if (collision.gameObject.CompareTag("Tutorial4"))
    //    {
    //        WinTutorial();
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        Instructions();
        if (Input.GetKeyDown(KeyCode.X))
            Intruction2();
    }

    
}
