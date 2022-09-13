using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;//Objeleri tutacak list deðiþkeni
    private float spawnRate = 1.5f;//Obje doðuþ aralýðýnýn süresi
    void Start()
    {
        StartCoroutine(SpawnTarget());
    }

    IEnumerator SpawnTarget()
    {
        while (true)
        {//Sonsuz döngü
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);//0 ile targets dizisinin uzunluðu arasýnda rastgele bir sayý döndür.(0-4)
            Instantiate(targets[index]);//targets dizisi içinde bulunan bir oyun objesini gelen rastegele deðer sýrasýna göre oluþtur.
        }
    }
}
