using UnityEngine;
using System.Collections;
using System.IO;

using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class menuComponent : MonoBehaviour {
	
	private const int LayerUI = 5;
	
	void Start () {
		CreateMenuComponent();
	}
	
	void Update () {
	}
	
	
	private void CreateMenuComponent() {


		for (int i = 0; i <4; i ++) {
			GameObject containerEmptyMenu = new GameObject ();
			containerEmptyMenu.name= "menu #"+i;

			RectTransform containerEmptyMenuTrans = containerEmptyMenu.AddComponent<RectTransform>();

			containerEmptyMenuTrans.localScale = new Vector3 (0.005718042f, 0.005718042f, 0.005718042f);
			containerEmptyMenuTrans.sizeDelta = new Vector2 (100f, 100f);
			containerEmptyMenuTrans.anchorMax = new Vector2 (0.5f, 0.5f);
			containerEmptyMenuTrans.anchorMin = new Vector2 (0.5f, 0.5f);
			containerEmptyMenuTrans.pivot = new Vector2(0.5f, 0.5f);
			//containerEmptyMenu.transform.localScale = new Vector3(0.005718042f, 0.005718042f, 0.005718042f);
			containerEmptyMenuTrans.Rotate(new Vector3(0f, 0f, 0f));

			if(i== 0){
				containerEmptyMenuTrans.position = new Vector3(0f, 30.184f, -19.396f);
			}else if(i== 1){
				containerEmptyMenuTrans.position = new Vector3(0f, 0.7f, 1f);
			}else if(i== 2){
				containerEmptyMenuTrans.position = new Vector3(0f, 2.5f, 10f);
			}else if(i== 3){
				containerEmptyMenuTrans.position = new Vector3(0f, 0f, 20f);
			}


			GameObject canvas = CreateCanvas(containerEmptyMenu.transform);
			RectTransform canvasTrans = canvas.GetComponent<RectTransform>();

			canvasTrans.localScale = new Vector3 (0.3497701f, 0.3497701f, 0.3497701f);
			canvasTrans.localPosition = new Vector3(0, 0, 0);
			canvasTrans.position = new Vector3(0, 0, 0);
			//canvasTrans.Rotate  = new Vector3(0f, 0f, 0f);
			//CreateEventSystem(canvas.transform);
			//CreateButton(canvas.transform, 0, 0, 160, 30, "Yes", delegate {OnExit();});

		}

		//GameObject canvas = CreateCanvas(this.transform);
		
		//CreateEventSystem(canvas.transform);
		
		//GameObject panel = CreatePanel(canvas.transform);
		
		//CreateText(panel.transform, 0, 100, 160, 50, "Message", 32);
		//CreateText(panel.transform, 0, 0, 160, 50, "Are you sure, you want to exit?", 24);
		//CreateButton(canvas.transform, 0, 0, 160, 50, "Yes", delegate {OnExit();});
		//CreateButton(panel.transform, 100, -100, 160, 50, "No", delegate {OnCancel();});
	}
	
	private GameObject CreateCanvas(Transform parent) {
		// create the canvas
		GameObject canvasObject = new GameObject("Canvas");
		canvasObject.layer = 0;
		
		RectTransform canvasTrans = canvasObject.AddComponent<RectTransform>();
		//canvasTrans.localPosition = new Vector3(0f, 0f, 0f);
		//canvasTrans.position = new Vector3(0f, 0f, 0f);
		canvasTrans.pivot = new Vector2(0.5f, 0.5f);

		canvasTrans.sizeDelta = new Vector2 (1000f, 1000f);
		canvasTrans.anchorMax = new Vector2 (0f, 0f);
		canvasTrans.anchorMin = new Vector2 (0f, 0f);
		canvasTrans.localScale = new Vector3 (0.3497701f, 0.3497701f, 0.3497701f);

		Canvas canvas = canvasObject.AddComponent<Canvas>();
		canvas.renderMode = RenderMode.WorldSpace;
		//canvas.pixelPerfect = true;
		
		CanvasScaler canvasScal = canvasObject.AddComponent<CanvasScaler>();
		//canvasScal.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
		//canvasScal.referenceResolution = new Vector3(800, 600, 0);
		canvasScal.dynamicPixelsPerUnit = 1;
		canvasScal.referencePixelsPerUnit = 100;
		GraphicRaycaster canvasRayc = canvasObject.AddComponent<GraphicRaycaster>();
		
		canvasObject.transform.SetParent(parent);
		
		return canvasObject;
	}
	
	private GameObject CreateEventSystem(Transform parent) {
		GameObject esObject = new GameObject("EventSystem");
		
		EventSystem esClass = esObject.AddComponent<EventSystem>();
		esClass.sendNavigationEvents = true;
		esClass.pixelDragThreshold = 5;
		
		StandaloneInputModule stdInput = esObject.AddComponent<StandaloneInputModule>();
		stdInput.horizontalAxis = "Horizontal";
		stdInput.verticalAxis = "Vertical";
		
		TouchInputModule touchInput = esObject.AddComponent<TouchInputModule>();
		
		esObject.transform.SetParent(parent);
		
		return esObject;
	}
	
	private GameObject CreatePanel(Transform parent) {
		GameObject panelObject = new GameObject("Panel");
		panelObject.transform.SetParent(parent);
		
		panelObject.layer = LayerUI;
		
		RectTransform trans = panelObject.AddComponent<RectTransform>();
		trans.anchorMin = new Vector2(0, 0);
		trans.anchorMax = new Vector2(1, 1);
		trans.anchoredPosition3D = new Vector3(0, 0, 0);
		trans.anchoredPosition = new Vector2(0, 0);
		trans.offsetMin = new Vector2(0, 0);
		trans.offsetMax = new Vector2(0, 0);
		trans.localPosition = new Vector3(0, 0, 0);
		trans.sizeDelta = new Vector2(0, 0);
		trans.localScale = new Vector3(0.8f, 0.8f, 1.0f);
		
		CanvasRenderer renderer = panelObject.AddComponent<CanvasRenderer>();
		
		/*Image image = panelObject.AddComponent<Image>();
		Texture2D tex = Resources.Load<Texture2D>("panel_bkg");
		image.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height),
		                             new Vector2(0.5f, 0.5f));*/
		
		return panelObject;
	}
	
	private GameObject CreateText(Transform parent, float x, float y,
	                              float w, float h, string message, int fontSize) {
		GameObject textObject = new GameObject("Text");
		textObject.transform.SetParent(parent);
		
		textObject.layer = LayerUI;
		
		RectTransform trans = textObject.AddComponent<RectTransform>();
		trans.sizeDelta.Set(w, h);
		trans.anchoredPosition3D = new Vector3(0, 0, 0);
		trans.anchoredPosition = new Vector2(x, y);
		trans.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		trans.localPosition.Set(0, 0, 0);
		
		CanvasRenderer renderer = textObject.AddComponent<CanvasRenderer>();
		
		Text text = textObject.AddComponent<Text>();
		text.supportRichText = true;
		text.text = message;
		text.fontSize = fontSize;
		text.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text.alignment = TextAnchor.MiddleCenter;
		text.horizontalOverflow = HorizontalWrapMode.Overflow;
		text.color = new Color(0, 0, 1);
		
		return textObject;
	}
	
	private GameObject CreateButton(Transform parent, float x, float y,
	                                float w, float h, string message,
	                                UnityAction eventListner) {
		GameObject buttonObject = new GameObject("Button");
		buttonObject.transform.SetParent(parent);
		
		buttonObject.layer = LayerUI;
		
		RectTransform trans = buttonObject.AddComponent<RectTransform>();
		//SetSize(trans, new Vector2(w, h));
		//trans.anchoredPosition3D = new Vector3(0, 0, 0);
		//trans.anchoredPosition = new Vector2(x, y);
		trans.sizeDelta = new Vector2 (x, y);
		trans.localScale = new Vector3(2.859021f, 2.859021f, 2.859021f);
		trans.pivot = new Vector2 (0.5f, 0.5f);
		//canvasTrans.localScale = new Vector3 (0.3497701f, 0.3497701f, 0.3497701f);
		//trans.localPosition.Set(0, 0, 0);
		
		CanvasRenderer renderer = buttonObject.AddComponent<CanvasRenderer>();
		
		Image image = buttonObject.AddComponent<Image>();
		
		/*Texture2D tex = Resources.Load<Texture2D>("button_bkg");
		image.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height),
		                             new Vector2(0.5f, 0.5f));*/
		
		Button button = buttonObject.AddComponent<Button>();
		button.interactable = true;
		button.onClick.AddListener(eventListner);
		
		GameObject textObject = CreateText(buttonObject.transform, 0, 0, 0, 0,
		                                   message,12);
		
		return buttonObject;
	}
	
	/*private static void SetSize(RectTransform trans, Vector2 size) {
		Vector2 currSize = trans.rect.size;
		Vector2 sizeDiff = size - currSize;
		trans.offsetMin = trans.offsetMin -
			new Vector2(sizeDiff.x * trans.pivot.x,
			            sizeDiff.y * trans.pivot.y);
		trans.offsetMax = trans.offsetMax + 
			new Vector2(sizeDiff.x * (1.0f - trans.pivot.x),
			            sizeDiff.y * (1.0f - trans.pivot.y));
	}*/
	
	private void OnExit()
	{
		Debug.Log ("Exit ..... ");
		Application.Quit();
	}
	
	private void OnCancel()
	{
		GameObject.Destroy(this);
	}
}