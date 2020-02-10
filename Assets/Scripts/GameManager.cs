using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private void Start()
    {
        OpenMenu();
    }
    static public string _char = "Ninja",
                         _name = "Israel";
    static public Character.CharType _scriptChar = Character.CharType.Ninja;
    public GameObject _PlayerSelect,
                      _FirstMenu,
                      _Store;

    public void SetName(string s)
    {
        _name = s;
    }
    public void ChoosePlayer(string s)
    {
        switch(s)
        {
            case "Knight":
                _char = "Karate Warrior";
                //_scriptChar = Character.CharType.Ninja; ;
                break;

            case "Mage":
                _char = "Sorceress Warrior";
               // _scriptChar = Character.CharType.Ninja; ;

                break;

            case "Zombie":
                _char = "Brute";
               // _scriptChar = Character.CharType.Ninja; ;

                break;

            case "Archer":
                _char = "Ninja";
                _scriptChar = Character.CharType.Ninja;
                break;

            default:
                break;
        }
    }
    public void OpenMenu(string s)
    {
        switch(s)
        {
            case "Store":
                OpenStore();
                break;

            case "Quit":
                Quit();
                break;

            case "ChangeChar":
                OpenChanger();
                break;

            case "StartGame":
                StartGame();
                break;

            case "Settings":
                break;

            case "Menu":
                OpenMenu();
                break;

            default:
                break;
        }
    }
    void OpenMenu()
    {
        _FirstMenu.SetActive(true);
        _PlayerSelect.SetActive(false);
        _Store.SetActive(false);
    }
    void OpenChanger()
    {
        _FirstMenu.SetActive(false);
        _PlayerSelect.SetActive(true);
        _Store.SetActive(false);

    }
    void OpenStore()
    {
        _FirstMenu.SetActive(false);
        _PlayerSelect.SetActive(false);
        _Store.SetActive(true);
    }
    void StartGame()
    {
        if(_char != null)
        {
            SceneManager.LoadScene("one");
        }
    }
    void Quit()
    {
        Application.Quit();
    }

}
