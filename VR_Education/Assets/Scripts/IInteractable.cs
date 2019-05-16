using System.Collections;
using UnityEngine.EventSystems;

public interface IInteractable : IEventSystemHandler {

	IEnumerable OnPointerOver();
	IEnumerable OnPointerExit();
	IEnumerable OnPress();
	IEnumerable OnRelease();
	IEnumerable OnHold();

	//void Ray(float position);

}
