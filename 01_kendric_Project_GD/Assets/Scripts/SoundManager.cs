using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource Pop;
    public AudioSource Pop2;
    public AudioSource fart;
    public AudioSource fart2;


    // Start is called before the first frame update
    
    public void PlayPop()
    {
        // Choose 0 or 1 (int overload: max is exclusive)
        int choice = Random.Range(0, 2);
        AudioSource chosen = (choice == 0) ? Pop : Pop2;

        if (chosen == null) return;

        // Stop the other pop source to avoid overlap, then play chosen
        if (Pop != null && Pop != chosen) Pop.Stop();
        if (Pop2 != null && Pop2 != chosen) Pop2.Stop();

        chosen.Play();
    }

    public void PlayFart()
    {
        int choice = Random.Range(0, 2);
        AudioSource chosen = (choice == 0) ? fart : fart2;

        if (chosen == null) return;

        // Stop the other source to avoid overlap, then play chosen
        if (fart != null && fart != chosen) fart.Stop();
        if (fart2 != null && fart2 != chosen) fart2.Stop();

        chosen.Play();
    }
}
