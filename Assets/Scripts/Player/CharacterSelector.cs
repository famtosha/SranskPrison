using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public static CharacterSelector instance;

    public GameObject mainCamera;
    public Character[] characters = new Character[3];
    public Inventory playersInventory = new Inventory();
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
        instance = this;
        foreach (var item in characters)
        {
            item.Deselect();
        }
        currentCharacter.Select();
    }

    private void UpdateCameraPosition()
    {
        //smooth version
        //var charPos = currentCharacter.gameObject.transform.position;
        //var currentPos = mainCamera.transform.position;
        //var lerpPos = Vector3.Lerp(currentPos, charPos, 0.25f);
        //mainCamera.transform.position = new Vector3(lerpPos.x, lerpPos.y, mainCamera.transform.position.z);

        var currentCharPos = currentCharacter.transform.position;
        mainCamera.transform.position = new Vector3(currentCharPos.x, currentCharPos.y, mainCamera.transform.position.z);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl)) selectedCharacter++;
        UpdateCameraPosition();
    }
}
