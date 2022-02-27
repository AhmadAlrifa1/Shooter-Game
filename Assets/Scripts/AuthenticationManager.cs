using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class AuthenticationManager : MonoBehaviour
{

    private LoadingScreenManager loadingscreen;

    [SerializeField] private InputField usernameInputField = default;
    [SerializeField] private InputField loginemailInputField = default;
    [SerializeField] private InputField loginpasswordInputField = default;

    [SerializeField] private InputField registeremailInputField = default;
    [SerializeField] private InputField registerpasswordInputField = default;

    [SerializeField] private Text errortext = default;
    [SerializeField] private GameObject errorPanel = default;

    string encryptedPassword;
    public GameObject LoginPanel;
    public GameObject RegisterPanel;

    public void Start()
    {
        PlayFabSettings.TitleId = "43C45";
    }

    private void OnPlayFabError(PlayFabError obj)
    {
        
    }
    public void ChangeToLogin()
    {
        LoginPanel.SetActive(true);
        RegisterPanel.SetActive(false);
    }

    public void ChangeToRegister()
    {
        LoginPanel.SetActive(false);
        RegisterPanel.SetActive(true);
    }

    string Encrypt(string pass)
    {
        System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] bs = System.Text.Encoding.UTF8.GetBytes(pass);
        bs = x.ComputeHash(bs);
        System.Text.StringBuilder s = new System.Text.StringBuilder();
        foreach(byte b in bs)
        {
            s.Append(b.ToString("x2").ToLower());
        }
        return s.ToString();
    }

    public void SignUp()
    {
        var registerRequest = new RegisterPlayFabUserRequest{
            Email = registeremailInputField.text,
            Password = Encrypt(registerpasswordInputField.text),
            Username = usernameInputField.text
        };
        PlayFabClientAPI.RegisterPlayFabUser(registerRequest, RegisterSuccess, RegisterError);
    }

    public void RegisterSuccess(RegisterPlayFabUserResult result)
    {
        errortext.text = "";
        SceneManager.LoadScene("LoadingScreen");
        loadingscreen.WhichScene = "Lobby";
    }

    public void RegisterError(PlayFabError error)
    {
        errorPanel.SetActive(true);

        switch(error.Error)
        {
            case PlayFabErrorCode.AccountBanned:
            SceneManager.LoadScene("LoadingScreen");
            loadingscreen.WhichScene = "Banned";
            break;
            case PlayFabErrorCode.AccountDeleted:
            errortext.text = "Account is deleted!";
            break;
            case PlayFabErrorCode.AccountNotFound:
            errortext.text = "Account not found!";
            break;
            case PlayFabErrorCode.InvalidEmailAddress:
            errortext.text = "Email is not valid!";
            break;
            case PlayFabErrorCode.InvalidPassword:
            errortext.text = "Password is not valid!";
            break;
            case PlayFabErrorCode.UnknownError:
            errortext.text = "Something went wrong!";
            break;
            case PlayFabErrorCode.UsernameNotAvailable:
            errortext.text = "Username not available!";
            break;
        }
    }

    public void LogIn()
    {
        var request = new LoginWithEmailAddressRequest{
            Email = loginemailInputField.text, 
            Password = Encrypt(loginpasswordInputField.text)
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, LogInSuccess, LogInError);
    }

    public void LogInSuccess(LoginResult result)
    {
        errortext.text = "";
        SceneManager.LoadScene("LoadingScreen");
        loadingscreen.WhichScene = "Lobby";
    }

    public void LogInError(PlayFabError error)
    {
        errorPanel.SetActive(true);

        switch(error.Error)
        {
            case PlayFabErrorCode.AccountBanned:
            SceneManager.LoadScene("LoadingScreen");
            loadingscreen.WhichScene = "Banned";
            break;
            case PlayFabErrorCode.AccountDeleted:
            errortext.text = "Account is deleted!";
            break;
            case PlayFabErrorCode.AccountNotFound:
            errortext.text = "Account not found!";
            break;
            case PlayFabErrorCode.InvalidEmailAddress:
            errortext.text = "Email is not valid!";
            break;
            case PlayFabErrorCode.InvalidPassword:
            errortext.text = "Password is not valid!";
            break;
            case PlayFabErrorCode.UnknownError:
            errortext.text = "Something went wrong!";
            break;
        }
    }

    public void ErrorExit()
    {
        errorPanel.SetActive(false);
    }
}
