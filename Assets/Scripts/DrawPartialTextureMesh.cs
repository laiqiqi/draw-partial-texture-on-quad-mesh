using UnityEngine;
using System.Collections;

public class DrawPartialTextureMesh : MonoBehaviour {

	MeshFilter mf;
	Vector2[] uvs;

	// Use this for initialization
	void Start () {
		mf = this.GetComponent<MeshFilter> ();

		uvs = mf.mesh.uv;

		for (var i = 0; i < uvs.Length; i++) 
			Debug.Log(uvs[i]);

	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.A)) {
			
			uvs[0] = new Vector2(0.0f, 0.5f);
			uvs[1] = new Vector2(0.5f, 1.0f);
			uvs[2] = new Vector2(0.5f, 0.5f);
			uvs[3] = new Vector2(0.0f, 1.0f);
			mf.mesh.uv = uvs;
		}
		
		if (Input.GetKeyDown(KeyCode.B)) {
			// upper-lefr corner
			uvs[0] = new Vector2(0.5f, 0.5f);
			uvs[1] = new Vector2(1.0f, 1.0f);
			uvs[2] = new Vector2(1.0f, 0.5f);
			uvs[3] = new Vector2(0.5f, 1.0f);
			mf.mesh.uv = uvs;
		}
		
		if (Input.GetKeyDown(KeyCode.C)) {
			
			uvs[0] = new Vector2(0.0f, 0.0f);
			uvs[1] = new Vector2(0.5f, 0.5f);
			uvs[2] = new Vector2(0.5f, 0.0f);
			uvs[3] = new Vector2(0.0f, 0.5f);
			mf.mesh.uv = uvs;
		}

		if (Input.GetKeyDown(KeyCode.D)) {
			
			uvs[0] = new Vector2(0.5f, 0.0f);
			uvs[1] = new Vector2(1.0f, 0.5f);
			uvs[2] = new Vector2(1.0f, 0.0f);
			uvs[3] = new Vector2(0.5f, 0.5f);
			mf.mesh.uv = uvs;
		}

		if (Input.GetKeyDown(KeyCode.E)) {
			
			uvs[0] = new Vector2(0.0f, 0.0f);
			uvs[1] = new Vector2(1.0f, 1.0f);
			uvs[2] = new Vector2(1.0f, 0.0f);
			uvs[3] = new Vector2(0.0f, 1.0f);
			mf.mesh.uv = uvs;
		}

	}
}
