using System;
using TMPro;
using UnityEngine;

public class RejoicePlayer : MonoBehaviour
{
    [SerializeField] private TMP_Text timeText; // текст для вывода времени
    [SerializeField] private GameObject PanelRejoice; // UI Панель возрождения
    private float timeRejoice = 3f; // Время, через которое игрок будет возрождён
    private HPPlayer hPPlayer; // ссылка на скрипт игрока
    private bool rejoice = false; // true, если игрок был убит



    private void Start()
    {
        hPPlayer = GetComponent<HPPlayer>();
        hPPlayer.OnChangeDied += (On) =>
        {
            if (!On)
            {
                rejoice = true;
                PanelRejoice.SetActive(true);
            }
        };
    }


    private void Update()
    {
        if (rejoice)
        {
            timeRejoice -= Time.deltaTime;
            timeText.text = Convert.ToInt32(timeRejoice).ToString();
            if(timeRejoice <= 0)
            {
                timeRejoice = 3f;
                PanelRejoice.SetActive(false);
                rejoice = false;
            }
        }
    }
}
