using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class Fade : MonoBehaviour {

	public Shader shader;
	public Texture ruleTex;

	float scale;
	Material material;
	List<FadeData> que = new List<FadeData>();
	float time;

	// Use this for initialization
	void Awake () {
		material = new Material(shader);
	}
	
	// Update is called once per frame
	void Update () {
		if (que.Count > 0) {
			var per = time / que[0].time;
			scale = Mathf.Lerp(que[0].start, que[0].end, per);
			time += Time.deltaTime;
			if (per >= 1.0f) {
				time = 0;
				if (que[0].callback != null) que[0].callback();
				que.RemoveAt(0);
			}
		}
	}

	Fade Fadeing(float _time, float _start, float _end, System.Action _callback) {
		FadeData data = new FadeData {
			time = _time,
			callback = _callback,
			start = _start,
			end = _end
		};
		que.Add(data);
		return this;
	}

	public Fade FadeIn(float time, System.Action callback = null) {
		return Fadeing(time, 1, 0, callback);
	}
	public Fade FadeOut(float time, System.Action callback = null) {
		return Fadeing(time, 0, 1, callback);
	}

	void OnRenderImage(RenderTexture source, RenderTexture destination) {
		material.SetFloat("_Scale", scale);
		material.SetTexture("_RuleTex", ruleTex);
		Graphics.Blit(source, destination, material);
	}

	struct FadeData {
		public float time;
		public System.Action callback;
		public float start;
		public float end;
	}
}
