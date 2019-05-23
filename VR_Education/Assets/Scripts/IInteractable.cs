using System.Collections;
using UnityEngine.EventSystems;

public interface IInteractable : IEventSystemHandler {

	//Line/Point
	IEnumerable OnPointerOver();
	IEnumerable OnPointerExit();

	//Trigger
	IEnumerable OnTriggerPress();
	IEnumerable OnTriggerHold();
	IEnumerable OnTriggerRelease();

	//IEnumerable ThouchAxis();

	//void Ray(float position);

}
