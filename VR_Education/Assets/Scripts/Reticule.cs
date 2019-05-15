using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticule:MonoBehaviour {

	public Pointer _pointer;
	public SpriteRenderer _crincleRenderer;


	public Sprite _openSprite;
	public Sprite _closeSprite;

	private Camera _cam = null;

	private void Awake() {
		_pointer.OnPointUpdate += UpdateSprite;
		_cam = Camera.main;
	}

	private void Update() {

		transform.LookAt(_cam.gameObject.transform);

	}

	private void OnDestroy() {
		_pointer.OnPointUpdate -= UpdateSprite;
	}

	private void UpdateSprite(Vector3 point, GameObject hitObject) {
		transform.position = point;

		if (hitObject) {
			_crincleRenderer.sprite = _closeSprite;
		}
		else
			_crincleRenderer.sprite = _closeSprite;

	}

}
