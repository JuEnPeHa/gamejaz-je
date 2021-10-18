using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text currentTime;
    public Text playerName;
    public Text saludoChange;
    public InputField askName;
    public Button confirmar;
    public Button letsPlay;

    private string salute;

    void Awake()
    {
        askName.gameObject.SetActive(false);
        playerName.gameObject.SetActive(false);
        confirmar.gameObject.SetActive(false);
        letsPlay.gameObject.SetActive(false);
    }

    private void Start()
    {
        Saludo();
        DefinirSalute();
    }

    private void DefinirSalute()
    {
        if (System.DateTime.Now.Hour >= 05 && System.DateTime.Now.Hour < 12)
        {
            salute = "Buenos días";
        }else if (System.DateTime.Now.Hour >= 12 && System.DateTime.Now.Hour < 19)
        {
            salute = "Buenas tardes";
        }else if ((System.DateTime.Now.Hour >= 19 && System.DateTime.Now.Hour < 24 ) || (System.DateTime.Now.Hour >= 00 && System.DateTime.Now.Hour < 05 ) )
        {
            salute = "Buenas noches";
        }

        saludoChange.text = salute;
    }


    public void Saludo()
    {
        if (PlayerPrefs.GetString("PlayerName") != null && PlayerPrefs.GetString("PlayerName") != "")
        {
            playerName.gameObject.SetActive(true);
            playerName.text = PlayerPrefs.GetString("PlayerName");
            letsPlay.gameObject.SetActive(true);
        }
        else
        {
            ReceiveName();
            Debug.Log("Mandando a ReceiveName");
        }

        Debug.Log("La hora es: " + System.DateTime.Now.Hour);
        
    }

    public void ReceivedName(string asked)
    {
        asked = askName.text;
        PlayerPrefs.SetString("PlayerName", asked);
        askName.gameObject.SetActive(false);
        confirmar.gameObject.SetActive(false);
        Debug.Log(asked);
        playerName.text = asked;
        playerName.gameObject.SetActive(true);
        letsPlay.gameObject.SetActive(true);
    }
    
    
    public void ReceiveName()
    {
        askName.gameObject.SetActive(true);
        confirmar.gameObject.SetActive(true);
        Debug.Log("Recibido en ReceiveName");
    }

    void Update()
    {
        currentTime.text =
            System.DateTime.Now.Hour.ToString("00") + ":" +
            System.DateTime.Now.Minute.ToString("00") + ":" +
            System.DateTime.Now.Second.ToString("00");
    }
}
