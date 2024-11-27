using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Tambahkan ini untuk berpindah scene

public class Gameselesai : MonoBehaviour
{
    public GameObject gameEndUIPrefab; // Drag prefab UI ke sini di Inspector

    private bool isGameEnded = false; // Cegah trigger berulang

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isGameEnded)
        {
            isGameEnded = true;

            // Hentikan waktu
            Time.timeScale = 0f;

            // Munculkan UI Game Selesai
            Instantiate(gameEndUIPrefab);

            Debug.Log("Game Berakhir!");
        }
    }




    // [Header("Nama Scene Tujuan")]
    // [Tooltip("Masukkan nama scene tujuan (harus ada di Build Settings)")]
    // public string sceneName = "SceneSelesai";

    // [Header("Opsi Transisi")]
    // [Tooltip("Tambahkan delay sebelum berpindah ke scene, dalam detik")]
    // public float transitionDelay = 0f;

    // private bool isTriggered = false; // Untuk mencegah pemicu ganda

    // private void OnTriggerEnter(Collider other)
    // {
    //     // Cek apakah yang menyentuh adalah pemain
    //     if (other.CompareTag("Player") && !isTriggered)
    //     {
    //         isTriggered = true; // Mencegah pemicu ganda
    //         Debug.Log($"Checkpoint tercapai! Memindahkan ke scene: {sceneName}");

    //         // Validasi scene
    //         if (SceneExists(sceneName))
    //         {
    //             // Pindah scene dengan atau tanpa delay
    //             if (transitionDelay > 0f)
    //             {
    //                 Invoke(nameof(LoadTargetScene), transitionDelay);
    //             }
    //             else
    //             {
    //                 LoadTargetScene();
    //             }
    //         }
    //         else
    //         {
    //             Debug.LogError($"Scene '{sceneName}' tidak ditemukan di Build Settings! Periksa pengaturan Anda.");
    //         }
    //     }
    // }

    // private void LoadTargetScene()
    // {
    //     SceneManager.LoadScene(sceneName);
    // }

    // private bool SceneExists(string name)
    // {
    //     // Periksa apakah scene ada di Build Settings
    //     for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
    //     {
    //         string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
    //         string sceneName = System.IO.Path.GetFileNameWithoutExtension(scenePath);

    //         if (sceneName == name)
    //         {
    //             return true;
    //         }
    //     }
    //     return false;
    // }
}

