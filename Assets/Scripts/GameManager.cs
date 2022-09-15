using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;//Objeleri tutacak list deðiþkeni
    private float spawnRate = 1.5f;//Obje doðuþ aralýðýnýn süresi
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
        while (isGameActive)//Oyun bittiði an ekranda olan objelerle etkileþim içine giremeyiz
        {//Oyun aktifse her 1.5 saniyede çalýþsýn ve obje üretsin
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);//0 ile targets dizisinin uzunluðu arasýnda rastgele bir sayý döndür.(0-4)
            Instantiate(targets[index]);//targets dizisi içinde bulunan bir oyun objesini gelen rastegele deðer sýrasýna göre oluþtur.
            
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
