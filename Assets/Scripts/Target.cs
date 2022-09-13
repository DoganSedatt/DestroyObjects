using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private float maxSpeed = 16;
    private float minSpeed = 12;
    private float maxTorgue = 10;
    private float xRange = 4.3f;
    private float ySpawnPos = -1f;

    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        //Eski kod=targetRb.AddForce(Vector3.up * Random.Range(12, 16), ForceMode.Impulse);//Yukarýya doðru 12 ile 16 deðerleri arasýnda güce sahip bir itki kuvveti uygular.
        //Eski kod=targetRb.AddTorque(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10),ForceMode.Impulse);//Objenin x,y ve z rotasyon deðerlerine itki kuvveti uygular ve dönmesini saðlar.
        //Eski kod=transform.position = new Vector3(Random.Range(-4.3f, 4.3f), -1);//Oyun her baþladýðýnda objenin yatay konumunu rastgele ayarla.Yükseklik olarak ise -1.

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(),RandomTorque(),RandomTorque(),ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
        //12 ile 16 arasýnda yukarýya doðru rastgele bir kuvvet ekle
    }
    float RandomTorque()
    {
        return Random.Range(-maxTorgue, maxTorgue);
        //-10 ile 10 arasýnda bir tork gücü uygula. Bu güç, objenin x,y ve z rotasyonlarý için tek tek uygulanacak.
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
        //X düzleminde -4.3f ile 4.3f arasýnda rastgele bir deðer dönder. Bu objenin yatayda baþlangýç konumunu belirleyecek. Y=-1;  
    }
}
