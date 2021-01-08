using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public Character[] characters = new Character[3];
    public Character currentCharacter => characters[_selectedCharacter];
    private int _selectedCharacter = 0;
    public int selectedCharacter
    {
        get => _selectedCharacter;
        set
        {
            currentCharacter.Deselect();
            _selectedCharacter = value;
            if (_selectedCharacter > 2) _selectedCharacter = 0;          
            if (_selectedCharacter < 0) _selectedCharacter = 2;
            currentCharacter.Select();
        }
    }

    private void Start()
    {
        foreach (var item in characters)
        {
            item.Deselect();
        }
        currentCharacter.Select();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl)) selectedCharacter++;
    }
}
