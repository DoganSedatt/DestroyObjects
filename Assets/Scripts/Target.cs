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
    private GameManager gameManager;//GameManager.cs scriptini tutacak olan de�i�ken
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();//GameManager objesini bul ve i�indeki GameManager kodunu al. 
        targetRb = GetComponent<Rigidbody>();
        //Eski kod=targetRb.AddForce(Vector3.up * Random.Range(12, 16), ForceMode.Impulse);//Yukar�ya do�ru 12 ile 16 de�erleri aras�nda g�ce sahip bir itki kuvveti uygular.
        //Eski kod=targetRb.AddTorque(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10),ForceMode.Impulse);//Objenin x,y ve z rotasyon de�erlerine itki kuvveti uygular ve d�nmesini sa�lar.
        //Eski kod=transform.position = new Vector3(Random.Range(-4.3f, 4.3f), -1);//Oyun her ba�lad���nda objenin yatay konumunu rastgele ayarla.Y�kseklik olarak ise -1.

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(),RandomTorque(),RandomTorque(),ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
        //12 ile 16 aras�nda yukar�ya do�ru rastgele bir kuvvet ekle
    }
    float RandomTorque()
    {
        return Random.Range(-maxTorgue, maxTorgue);
        //-10 ile 10 aras�nda bir tork g�c� uygula. Bu g��, objenin x,y ve z rotasyonlar� i�in tek tek uygulanacak.
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
        //X d�zleminde -4.3f ile 4.3f aras�nda rastgele bir de�er d�nder. Bu objenin yatayda ba�lang�� konumunu belirleyecek. Y=-1;  
    }
    private void OnMouseDown()
    {
        Destroy(gameObject);//Fare ile t�klad���m nesnenin yok olmas�n� sa�l�yor
        gameManager.UpdateScore(2);//Nesne yok olduk�a 2 puan ekleyecek.
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);//Oyun ekran�ndan a�a��ya d��en objeler sens�r nesnesinin collider'� ile �arp���yor ve yok oluyor.
    }
}
