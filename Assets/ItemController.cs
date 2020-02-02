using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemController : MonoBehaviour
{
    public GameObject wrench;
    public GameObject propellor;
    public GameObject tank;
    public GameObject antenna;
    public GameObject wrench_empty;
    public GameObject propellor_empty;
    public GameObject tank_empty;
    public GameObject antenna_empty;

    public AudioSource theme;
    public AudioSource endMusic;
    public Canvas endGameCanvas;

    private int items = 0;

    public void flipItem(string type)
    {
        if (type.Equals("wrench"))
        {
            wrench.gameObject.SetActive(true);
            wrench_empty.gameObject.SetActive(false);
            items++;
        }
        else if (type.Equals("antenna"))
        {
            antenna.gameObject.SetActive(true);
            antenna_empty.gameObject.SetActive(false);
            items++;
        }
        else if (type.Equals("tank"))
        {
            tank.gameObject.SetActive(true);
            tank_empty.gameObject.SetActive(false);
            items++;
        }
        else if (type.Equals("propellor"))
        {
            propellor.gameObject.SetActive(true);
            propellor_empty.gameObject.SetActive(false);
            items++;
        }

        if (items >= 4 && type.Equals("spaceship"))
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        endGameCanvas.gameObject.SetActive(true);
        StartCoroutine(FadeOut(theme, 7f));
        endMusic.gameObject.SetActive(true);
        endMusic.Play();
        Invoke("ChangeToMainMenu", endMusic.clip.length);
    }

    public void ChangeToMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }
}
