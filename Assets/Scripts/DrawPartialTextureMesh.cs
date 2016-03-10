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
		mf = this.GetComponent<MeshFilter>();

		uvs = mf.mesh.uv;

		for (var i = 0; i < uvs.Length; i++) 
			Debug.Log(uvs[i]);


			Expand(mf.mesh, 1f, 2f);
     		Expand(mf.mesh, -1f, -2f);

	

		originalVerts =  new Vector3[ mf.mesh.vertices.Length ];

		for (var i = 0; i < mf.mesh.vertices.Length; i++) {
			originalVerts [i] = mf.mesh.vertices [i];
		}

		for (var i = 0; i < mf.mesh.triangles.Length; i++) 
		{
				Debug.Log("tri[" + i + "]= " + mf.mesh.triangles[i]);

		}

		rotatedVerts = new Vector3[ mf.mesh.vertices.Length];
	}

	public void Expand(Mesh mesh, float offsetX, float offsetY)
	{
		Vector3[] originals = mesh.vertices;
		Vector2[] originalUV = mesh.uv;
		int[] originalTri = mesh.triangles;

		Vector3[] verts =  new Vector3[originals.Length + 4];
		Vector2[] uv = new Vector2[originalUV.Length + 4];
		int[] tris = new int[mesh.triangles.Length + 6];

		for(int i=0; i< originals.Length; i++) {
				verts[i] = originals[i];
				uv[i] = originalUV[i];
		}

		verts[originals.Length] = new Vector3(originals[0].x + offsetX, originals[0].y + offsetY, 0);
		verts[originals.Length+ 1] = new Vector3(originals[1].x + offsetX, originals[1].y + offsetY, 0);
		verts[originals.Length+ 2] = new Vector3(originals[2].x + offsetX, originals[2].y + offsetY, 0);
		verts[originals.Length+ 3] = new Vector3(originals[3].x + offsetX, originals[3].y + offsetY, 0);

		uv[originalUV.Length] = uv[0];
		uv[originalUV.Length+1] = uv[1];
		uv[originalUV.Length+2] = uv[2];
		uv[originalUV.Length+3] = uv[3];

		for (int i =0; i<originalTri.Length; i++) {
			tris[i] = originalTri[i];
		}

		tris [originalTri.Length] = originals.Length;
		tris [originalTri.Length+1] = originals.Length+1;
		tris [originalTri.Length+2] = originals.Length+2;
		tris [originalTri.Length+3] = originals.Length+1;
		tris [originalTri.Length+4] = originals.Length;
		tris [originalTri.Length+5] = originals.Length+3;

		
		mf.mesh.vertices = verts;
		mf.mesh.uv = uv;
		mf.mesh.triangles = tris;

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
		//Vector3 center = new Vector3(x, y, z);//a pivot point.
		Quaternion qAngle = Quaternion.AngleAxis( rotatedAngle, new Vector3(0,0,1) );

		for (int i=0; i < rotatedVerts.Length; i++) {
			rotatedVerts[i] = qAngle * originalVerts[i];

			// use this line to rotate around a pivot point
			//			rotatedVerts[i] = qAngle * (originalVerts[i]- center)+center;
		}

		mf.mesh.vertices = rotatedVerts;
	}

}
