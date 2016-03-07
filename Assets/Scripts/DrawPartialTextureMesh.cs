using UnityEngine;
using System.Collections;

public class DrawPartialTextureMesh : MonoBehaviour {

	MeshFilter mf;
	Vector2[] uvs;
	Vector3[] originalVerts, rotatedVerts;
	[Range(0,360)]
	public float rotatedAngle = 0;
	private float previousRotatedAngle = 0;

	// Use this for initialization
	void Start () {
		mf = this.GetComponent<MeshFilter> ();

		uvs = mf.mesh.uv;

		for (var i = 0; i < uvs.Length; i++) 
			Debug.Log(uvs[i]);

		originalVerts =  new Vector3[ mf.mesh.vertices.Length ];

		for (var i = 0; i < mf.mesh.vertices.Length; i++) 
			originalVerts [i] = mf.mesh.vertices [i];


		rotatedVerts = new Vector3[ mf.mesh.vertices.Length];
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

		if (previousRotatedAngle != rotatedAngle) {
			Rotate();
			previousRotatedAngle = rotatedAngle;
		}

	}

	void Rotate()
	{
		Quaternion qAngle = Quaternion.AngleAxis( rotatedAngle, new Vector3(0,0,1) );

		for (int i=0; i < rotatedVerts.Length; i++) {
			rotatedVerts[i] = qAngle * originalVerts[i];
		}

		mf.mesh.vertices = rotatedVerts;
	}

}
