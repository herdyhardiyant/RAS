using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class RandomSpawnTrash : MonoBehaviour
    {
        public GameObject[] tipeSampah;
        private Vector3 posisiRandom;
        [SerializeField(),Range(0.01f,0.5f)]private float posisiSpawn;
        private bool jalanfungsi;
        [SerializeField(),Range(1,10)] private int size; 
        // Update is called once per frame
         void Awake()
        {
        jalanfungsi = true;
        if(jalanfungsi)
        {
        for (int i = 0; i < size; i++)
        {

           float posisiXacak = Random.Range(-0.5f,0.5f);
           float posisiZacak = Random.Range(-0.5f,0.5f);
           Vector3 tmPos = transform.position;
           if (tmPos.x == 0)
            tmPos.x = Random.Range(-45f,60f);
           if (tmPos.z == 0)
            tmPos.z = Random.Range(-27f,27f);
           tmPos.x = tmPos.x + tmPos.x*posisiXacak;
           tmPos.z = tmPos.z + tmPos.z*posisiZacak;
           tmPos.y = posisiSpawn;
           transform.position=tmPos;
           posisiRandom = transform.position;
           int randomSampah = Random.Range(0,tipeSampah.Length);
            Instantiate(tipeSampah[randomSampah],posisiRandom,Quaternion.identity);
        }
        jalanfungsi = false;
        }
    }
    }

