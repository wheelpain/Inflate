using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeliumBar : MonoBehaviour
{
    public GameObject heliumBar;
    public Slider heliumSlider;
    float heliumMaxCapcity = 100;
    float currentHelium;
    public float lossingGas;
    public bool isHeliumBarTrue = false;

    bool isNearCanister = false;

    public ParticleSystem bubbleParticle;

    public SoundManager soundManager;
    //Detect if player is near Canister
    private void Start()
    {
        currentHelium = heliumMaxCapcity;
        SetMaxHelium(heliumMaxCapcity);
        
    }

    public void SetHelium(float gas)
    {
        heliumSlider.value = gas;
    }

    //Set helium bar max value
    public void SetMaxHelium(float gas)
    {
        heliumSlider.maxValue = gas;
        heliumSlider.value = gas;
    }


    public void SpendHelium(float gas)
    {
        currentHelium -= gas;
    }

    public void SetNearCanister(bool state)
    {
        isNearCanister = state;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HeliumCanister"))
        {
            isNearCanister = true;
            Debug.Log("Near canister");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("HeliumCanister"))
        {
            isNearCanister = false;
            Debug.Log("Left canister");
        }
    }
    private void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.X) && isNearCanister)
        {

            isHeliumBarTrue = true;
            heliumBar.SetActive(true);
            HeliTransform.instance.TransformToBall();
            bubbleParticle.Play();
            soundManager.PlayPop();

        }
        
        if (isHeliumBarTrue)
        { 
            currentHelium -= lossingGas * Time.deltaTime;
            SetHelium(currentHelium);
            
            if (currentHelium <= 0)
            {   
                currentHelium = heliumMaxCapcity;
                isHeliumBarTrue = false;
                heliumBar.SetActive(false);
                HeliTransform.instance.TransformToHuman();
                soundManager.PlayPop();
                //bubbleParticle.Play();
            }
        }

       
    }
}
