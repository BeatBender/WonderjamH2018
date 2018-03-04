using UnityEngine.Audio;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;

    public static AudioManager instance;

    private static bool keepFadingIn;
    private static bool keepFadingOut;

    private string currentMusic;

    private bool valideChange = true;

    // Use this for initialization
    void Awake () {

        if (instance == null)
            instance = this;
        else {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

		foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

            s.source.outputAudioMixerGroup = s.output;
        }
	}

    void Start() {
        //FadeInCaller("MusiqueMenu", .05f, 1f);
    }

    public void Play(string name) {

        Sound s = Array.Find(sounds, sound => sound.name == name);

        if(s == null) {
            Debug.LogWarning("Le son " + name + " n'a pas été trouvé!");
            return;
        }

        s.source.Play();
    }

    public void FadeInCaller(string name, float speed, float maxVolume) {
        instance.StartCoroutine(FadeIn(name, speed, maxVolume));
        currentMusic = name;
    }

    public void ChangeMusic(string name, float speed, float maxVolume) {

        if(currentMusic == null) {
            instance.StartCoroutine(FadeIn(name, speed, maxVolume));
            currentMusic = name;
        }

        if (currentMusic != name && valideChange) {
            instance.StartCoroutine(TimeChange());
            instance.StartCoroutine(FadeOut(name, speed, maxVolume));
        }

    }

    IEnumerator FadeIn (string name, float speed, float maxVolume) {
        keepFadingIn = true;
        keepFadingOut = false;

        int nb = Array.FindIndex(sounds, sound => sound.name == name);
        if (nb < 0) {
            Debug.LogWarning("Le son " + name + " n'a pas été trouvé!");
            keepFadingIn = false;
            yield break;
        }

        sounds[nb].source.volume = 0;
        float audioVolume = sounds[nb].source.volume;

        if(keepFadingIn)
            Play(name);

        while (sounds[nb].source.volume < maxVolume && keepFadingIn) {
            audioVolume += speed;
            sounds[nb].source.volume = audioVolume;
            yield return new WaitForSeconds(0.1f);
        }

        keepFadingIn = false;
    }

    IEnumerator FadeOut(string name, float speed, float maxVolume) {
        keepFadingIn = false;
        keepFadingOut = true;

        int nb = Array.FindIndex(sounds, sound => sound.name == currentMusic);
        if (nb < 0) {
            Debug.LogWarning("Le son " + currentMusic + " n'a pas été trouvé!");
            keepFadingOut = false;
            yield break;
        }

        float audioVolume = sounds[nb].source.volume;

        while (sounds[nb].source.volume >= speed && keepFadingOut) {
            audioVolume -= speed;
            sounds[nb].source.volume = audioVolume;
            yield return new WaitForSeconds(0.1f);
        }

        sounds[nb].source.Pause();
        keepFadingOut = false;

        instance.StartCoroutine(FadeIn(name, speed, maxVolume));
        currentMusic = name;
    }

    IEnumerator TimeChange() {
        valideChange = false;

        yield return new WaitForSeconds(0.5f);

        Debug.Log(valideChange);
        valideChange = true;
    }


    #region Fonctions Musique
    public void A_MusiqueMenu() {
        ChangeMusic("MusiqueMenu", .1f, 1f);
    }

    public void A_Musique2() {
        ChangeMusic("Musique2", .1f, 1f);
    }

    public void A_CheckPlayer() {
        ChangeMusic("CheckPlayer", .2f, 1f);
    }

    public void A_Seek() {
        ChangeMusic("Seek", .2f, 0.8f);
    }

    public void A_Perdu() {
        ChangeMusic("Perdu", .2f, 0.8f);
    }

    public void A_Victoire() {
        ChangeMusic("Victoire", .1f, 1f);
    }
#endregion
}
