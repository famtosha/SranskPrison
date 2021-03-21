using UnityEngine;

[RequireComponent(typeof(Character))]
public class Interacting : MonoBehaviour
{
    private Character character;
    public InterationData<IPickupable> zadr;
    public InterationData<Character> anotherCharacter;
    public InterationData<IInteraction> interactionNowTouch;

    private void Awake()
    {
        character = GetComponent<Character>();

        zadr = new InterationData<IPickupable>(x => { return; }, x => { return; });
        anotherCharacter = new InterationData<Character>(x => GiveItemInfo.instance.HideInfo(), y => { GiveItemInfo.instance.ShowInfo(); });
        interactionNowTouch = new InterationData<IInteraction>(x => x.HideInfo(), y => y.ShowInfo());
    }

    private void Update()
    {
        if (Input.GetKeyDown(InputSettings.current.hackPanel) && interactionNowTouch.nowTouch != null && interactionNowTouch.nowTouch.UseByCharacter(character.useAction)) character.RemoveItem();
        if (Input.GetKeyDown(InputSettings.current.giveItem)) anotherCharacter.nowTouch?.Trade(character.playerID);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        zadr.OnEnter(collision);
        anotherCharacter.OnEnter(collision);
        interactionNowTouch.OnEnter(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        zadr.OnExit(collision);
        anotherCharacter.OnExit(collision);
        interactionNowTouch.OnExit(collision);
    }
}