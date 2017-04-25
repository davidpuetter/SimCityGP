using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ambience : MonoBehaviour {

    public AudioSource[] noise;
    public AudioSource small;
    public AudioSource medium;
    public AudioSource large;

    bool smallPlaying;
    bool mediumPlaying;
    bool largePlaying;

    public GameObject master;
    private gameMoney gameManager;

    // Use this for initialization
    void Start() {

        smallPlaying = false;
        mediumPlaying = false;
        largePlaying = false;

        noise = GetComponents<AudioSource>();
        small = noise[0];
        medium = noise[1];
        large = noise[2];

        small.loop = true;
        medium.loop = true;
        large.loop = true;

        gameManager = master.GetComponent<gameMoney>();

        playMusic();
    }

    void playMusic() {
        

        if (gameManager.Population >= 0.0f && gameManager.Population < 50.0f)
        {
            small.Stop();
            medium.Stop();
            large.Stop();

            small.Play();

            smallPlaying = true;
            mediumPlaying = false;
            largePlaying = false;

        }

        if (gameManager.Population >= 50.0f && gameManager.Population < 100.0f)
        {
            small.Stop();
            medium.Stop();
            large.Stop();

            medium.Play();

            smallPlaying = false;
            mediumPlaying = true;
            largePlaying = false;
        }

        if (gameManager.Population >= 100.0f)
        {
            small.Stop();
            medium.Stop();
            large.Stop();

            large.Play();

            smallPlaying = false;
            mediumPlaying = false;
            largePlaying = true;
        }
    }


    // Update is called once per frame
    void Update() {

        if (gameManager.Population >= 0.0f && gameManager.Population < 50.0f && !smallPlaying)
        {
            playMusic();
        }

        if (gameManager.Population >= 50.0f && gameManager.Population < 100.0f && !mediumPlaying)
        {
            playMusic();
        }

        if (gameManager.Population >= 100.0f && !largePlaying)
        {
            playMusic();
        }
    }

}
