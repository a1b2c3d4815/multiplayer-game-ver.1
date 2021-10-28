using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartPoint : MonoBehaviour
{

    

    public void StartHost()
    {
        NetworkManager.Singleton.StartHost();
        Debug.Log("starthost");
        NetworkManager.Singleton.SceneManager.LoadScene("Lobby" , UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
    public void StartClient()
    {
        
        NetworkManager.Singleton.StartClient();
        var isconnectedclient = NetworkManager.Singleton.IsConnectedClient;
        Debug.Log(isconnectedclient);
        if (!NetworkManager.Singleton.IsConnectedClient)
        {
            NetworkManager.Singleton.Shutdown();
            NetworkManager.Singleton.StartHost();
            NetworkManager.Singleton.SceneManager.LoadScene("Lobby", LoadSceneMode.Single);
        }
        if (NetworkManager.Singleton.IsClient){
            SceneManager.LoadScene("Lobby", LoadSceneMode.Single);
        }
        Debug.Log("isserver" + (NetworkManager.Singleton.IsServer ? "server" :"client")) ;

    }

}
