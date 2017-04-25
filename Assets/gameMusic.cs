using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameMusic : MonoBehaviour {

    // Use this for initialization

    public AudioSource[] music;
    public AudioSource music1;
    public AudioSource music2;

    public bool firstPlaying;

    void Start() {
        music = GetComponents<AudioSource>();
        music1 = music[0];
        music2 = music[1];

        firstPlaying = false;

        music1.loop = false;
        music2.loop = false;

        playMusic();
    }

    void playMusic() {

        if (firstPlaying)
        {
            music1.Play();

            firstPlaying = false;

            // Invoke("playMusic", 141f);

        }

        else
        {
            music2.Play();

            firstPlaying = true;

            // Invoke("playMusic", 89f);

        }

    }
    void Update()
    {
        if (!music1.isPlaying && !music2.isPlaying)
        {
            playMusic();
        }
    }
    


}
