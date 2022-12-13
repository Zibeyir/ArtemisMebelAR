using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Photo : MonoBehaviour
{
	public RawImage image;
	public GameObject TurnOfInPhoto;

	public void clickCapture()
	{
		StartCoroutine(SaveImage());
	}

	private IEnumerator SaveImage()
	{

		yield return new WaitForEndOfFrame();
		TurnOfInPhoto.SetActive(false);
		Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.ARGB32, false);
		ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
		ss.Apply();
		image.texture = ss;
		TurnOfInPhoto.SetActive(true);

		yield return new WaitForEndOfFrame();
		NativeGallery.Permission permission = NativeGallery.SaveImageToGallery(ss, "CameraTest", "CaptureImage.png", (success, path) => Debug.Log("Media save result: " + success + " " + path));

	}
}
