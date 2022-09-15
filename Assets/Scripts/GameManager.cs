using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;//Objeleri tutacak list de�i�keni
    private float spawnRate = 1.5f;//Obje do�u� aral���n�n s�resi
    public TextMeshProUGUI scoreText;//Puan text nesnesi
    public TextMeshProUGUI gameOverText;
    private int score;
    public bool isGameActive=true;
    void Start()
    {
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
        gameOverText.gameObject.SetActive(false);
        isGameActive = true;
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)//Oyun bitti�i an ekranda olan objelerle etkile�im i�ine giremeyiz
        {//Oyun aktifse her 1.5 saniyede �al��s�n ve obje �retsin
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);//0 ile targets dizisinin uzunlu�u aras�nda rastgele bir say� d�nd�r.(0-4)
            Instantiate(targets[index]);//targets dizisi i�inde bulunan bir oyun objesini gelen rastegele de�er s�ras�na g�re olu�tur.
            
        }
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Puan:" + score;
    }
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }
}
