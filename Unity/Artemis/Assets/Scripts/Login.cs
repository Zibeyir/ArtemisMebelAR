using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Login : MonoBehaviour
{
    [SerializeField] string Usarname;
    [SerializeField] string Password;
    void Start()
    {
        
    }

    public void SignIn()
    {
        PlayerPrefs.SetInt("Login",1);
        GameManager.instance.LoginFunc();
    }
    
}
