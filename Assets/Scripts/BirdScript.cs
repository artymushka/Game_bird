using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : Sounds
{
    public static bool isEnd { get; set; }
    public float gravity;
    public float force;

    float timer;
    public TrailRenderer trailRenderer; // Добавляем ссылку на компонент Trail Renderer

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            timer = force;
            EnableTrail(); // Включаем след при клике
            PlaySound(sounds[0]);
        }

        if (!isEnd)
        {
            transform.Translate(new Vector3(0, timer, 0) * Time.deltaTime);
            if (timer > gravity)
                timer -= Time.deltaTime * 30;
            else
                timer = gravity;
        }
        else
        {
            gravity = 0;
            force = 0;
            timer = 0;
            DisableTrail(); // Выключаем след при окончании игры
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Column")
            isEnd = true;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        ViewerScript.PlusCoins();
    }

    // Метод для включения следа
    void EnableTrail()
    {
        trailRenderer.enabled = true;
    }

    // Метод для выключения следа
    void DisableTrail()
    {
        trailRenderer.enabled = false;
    }
}