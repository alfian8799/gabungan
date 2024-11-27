using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mualigame : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Tombol Mulai Game Ditekan");  // Menambahkan log untuk debugging
        SceneManager.LoadScene("Scene7"); // Pastikan nama scene sesuai dengan yang ada
    }
}
