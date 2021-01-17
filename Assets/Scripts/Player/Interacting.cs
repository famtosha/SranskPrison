using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacting : MonoBehaviour
{
    private Character character;

    private IInteraction _itemNowTouch = null;
    public IInteraction itemNowTouch
    {
        get => _itemNowTouch;
        set
        {
            _itemNowTouch?.HideInfo();
            _itemNowTouch = value;
            _itemNowTouch?.ShowInfo();
        }
    }

    private Character _characterNowTouch = null;
    public Character characterNowTouch
    {
        get => _characterNowTouch;
        set
        {
            GiveItemInfo.instance?.HideInfo();
            _characterNowTouch = value;
            if (_characterNowTouch != null) GiveItemInfo.instance?.ShowInfo();
        }
    }

    private IPickupable _zadr = null;
    public IPickupable zadr
    {
        get => _zadr;
        set
        {
            _zadr = value;
        }
    }

    private void Awake()
    {
        character = GetComponent<Character>();
    }

    private void Update()
    {
        bool isUsed = false;
        if (Input.GetKeyDown(KeyCode.E) && itemNowTouch != null) itemNowTouch.UseByCharacter(character.useAction, out isUsed);
        if (isUsed) character.RemoveItem();
        if (Input.GetKeyDown(KeyCode.T) && characterNowTouch != null) characterNowTouch.Trade(character.playerID);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IInteraction interaction)) itemNowTouch = interaction;
        if (collision.gameObject.TryGetComponent(out Character anotherCharacter)) characterNowTouch = anotherCharacter;
        if (collision.gameObject.TryGetComponent(out IPickupable zadr)) this.zadr = zadr;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (itemNowTouch != null && collision.gameObject.GetComponent<IInteraction>() == itemNowTouch) itemNowTouch = null;
        if (characterNowTouch != null && collision.gameObject.GetComponent<Character>() == characterNowTouch) characterNowTouch = null;
        if (zadr != null && collision.gameObject.GetComponent<IPickupable>() == zadr) zadr = null;
    }
}