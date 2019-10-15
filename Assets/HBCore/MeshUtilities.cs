﻿using CielaSpike;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public static class MeshUtilities {

    public struct MeshMaterial {
        public Mesh mesh;
        public string material;

        public MeshMaterial(Mesh _mesh, string _material) {
            this.mesh = _mesh;
            this.material = _material;
        }
    }

    public static string CalcHash(Mesh m) {
        if (m == null) { return "empty mesh"; }
        byte[] data = EncodeH3D(m);
        if (data == null) { return "empty mesh"; }
        string md5 = CalculateMD5(data);
        return md5;
    }

    public static string CalcFastHash(Mesh m) {
        if (m == null) { return "empty mesh"; }

        byte[] data = new byte[120];
        if (m.vertexCount == 0) {
            byte[] bx1 = BitConverter.GetBytes(0f);
            byte[] by1 = BitConverter.GetBytes(0f);
            byte[] bz1 = BitConverter.GetBytes(0f);

            byte[] bx2 = BitConverter.GetBytes(0f);
            byte[] by2 = BitConverter.GetBytes(0f);
            byte[] bz2 = BitConverter.GetBytes(0f);

            byte[] bx3 = BitConverter.GetBytes(0f);
            byte[] by3 = BitConverter.GetBytes(0f);
            byte[] bz3 = BitConverter.GetBytes(0f);

            byte[] bx4 = BitConverter.GetBytes(0f);
            byte[] by4 = BitConverter.GetBytes(0f);
            byte[] bz4 = BitConverter.GetBytes(0f);

            byte[] bx5 = BitConverter.GetBytes(0f);
            byte[] by5 = BitConverter.GetBytes(0f);
            byte[] bz5 = BitConverter.GetBytes(0f);

            byte[] bx6 = BitConverter.GetBytes(0f);
            byte[] by6 = BitConverter.GetBytes(0f);
            byte[] bz6 = BitConverter.GetBytes(0f);

            byte[] bx7 = BitConverter.GetBytes(0f);
            byte[] by7 = BitConverter.GetBytes(0f);
            byte[] bz7 = BitConverter.GetBytes(0f);

            byte[] bx8 = BitConverter.GetBytes(0f);
            byte[] by8 = BitConverter.GetBytes(0f);
            byte[] bz8 = BitConverter.GetBytes(0f);

            byte[] len = BitConverter.GetBytes(m.vertexCount);

            data[0] = bx1[0]; data[1] = bx1[1]; data[2] = bx1[2]; data[3] = bx1[3];
            data[4] = by1[0]; data[5] = by1[1]; data[6] = by1[2]; data[7] = by1[3];
            data[8] = bz1[0]; data[9] = bz1[1]; data[10] = bz1[2]; data[11] = bz1[3];

            data[12] = bx2[0]; data[13] = bx2[1]; data[14] = bx2[2]; data[15] = bx2[3];
            data[16] = by2[0]; data[17] = by2[1]; data[18] = by2[2]; data[19] = by2[3];
            data[20] = bz2[0]; data[18] = bz2[1]; data[19] = bz2[2]; data[20] = bz2[3];

            data[24] = bx3[0]; data[25] = bx3[1]; data[26] = bx3[2]; data[27] = bx3[3];
            data[28] = by3[0]; data[29] = by3[1]; data[30] = by3[2]; data[31] = by3[3];
            data[32] = bz3[0]; data[33] = bz3[1]; data[34] = bz3[2]; data[35] = bz3[3];

            data[36] = bx4[0]; data[37] = bx4[1]; data[38] = bx4[2]; data[39] = bx4[3];
            data[40] = by4[0]; data[41] = by4[1]; data[42] = by4[2]; data[43] = by4[3];
            data[44] = bz4[0]; data[45] = bz4[1]; data[46] = bz4[2]; data[47] = bz4[3];

            data[48] = bx5[0]; data[49] = bx5[1]; data[50] = bx5[2]; data[51] = bx5[3];
            data[52] = by5[0]; data[53] = by5[1]; data[54] = by5[2]; data[55] = by5[3];
            data[56] = bz5[0]; data[57] = bz5[1]; data[58] = bz5[2]; data[59] = bz5[3];

            data[60] = bx6[0]; data[61] = bx6[1]; data[62] = bx6[2]; data[63] = bx6[3];
            data[64] = by6[0]; data[65] = by6[1]; data[66] = by6[2]; data[67] = by6[3];
            data[68] = bz6[0]; data[69] = bz6[1]; data[70] = bz6[2]; data[71] = bz6[3];

            data[72] = bx7[0]; data[73] = bx7[1]; data[74] = bx7[2]; data[75] = bx7[3];
            data[76] = by7[0]; data[77] = by7[1]; data[78] = by7[2]; data[79] = by7[3];
            data[80] = bz7[0]; data[81] = bz7[1]; data[82] = bz7[2]; data[83] = bz7[3];

            data[84] = bx8[0]; data[85] = bx8[1]; data[86] = bx8[2]; data[87] = bx8[3];
            data[88] = by8[0]; data[89] = by8[1]; data[90] = by8[2]; data[91] = by8[3];
            data[92] = bz8[0]; data[93] = bz8[1]; data[94] = bz8[2]; data[95] = bz8[3];

            data[96] = len[0]; data[97] = len[1]; data[98] = len[2]; data[99] = len[3];
        } else {
            int index1 = (m.vertexCount / 9) * 1;
            int index2 = (m.vertexCount / 9) * 2;
            int index3 = (m.vertexCount / 9) * 3;
            int index4 = (m.vertexCount / 9) * 4;
            int index5 = (m.vertexCount / 9) * 5;
            int index6 = (m.vertexCount / 9) * 6;
            int index7 = (m.vertexCount / 9) * 7;
            int index8 = (m.vertexCount / 9) * 8;

            byte[] bx1;
            byte[] by1;
            byte[] bz1;

            byte[] bx2;
            byte[] by2;
            byte[] bz2;

            byte[] bx3;
            byte[] by3;
            byte[] bz3;

            byte[] bx4;
            byte[] by4;
            byte[] bz4;

            byte[] bx5;
            byte[] by5;
            byte[] bz5;

            byte[] bx6;
            byte[] by6;
            byte[] bz6;

            byte[] bx7;
            byte[] by7;
            byte[] bz7;

            byte[] bx8;
            byte[] by8;
            byte[] bz8;

            byte[] len;

            if (m.uv.Length == m.vertices.Length) {
                bx1 = BitConverter.GetBytes(m.vertices[index1].x + m.uv[index1].x);
                by1 = BitConverter.GetBytes(m.vertices[index1].y + m.uv[index1].y);
                bz1 = BitConverter.GetBytes(m.vertices[index1].z);

                bx2 = BitConverter.GetBytes(m.vertices[index2].x + m.uv[index2].x);
                by2 = BitConverter.GetBytes(m.vertices[index2].y + m.uv[index2].y);
                bz2 = BitConverter.GetBytes(m.vertices[index2].z);

                bx3 = BitConverter.GetBytes(m.vertices[index3].x + m.uv[index3].x);
                by3 = BitConverter.GetBytes(m.vertices[index3].y + m.uv[index3].y);
                bz3 = BitConverter.GetBytes(m.vertices[index3].z);

                bx4 = BitConverter.GetBytes(m.vertices[index4].x + m.uv[index4].x);
                by4 = BitConverter.GetBytes(m.vertices[index4].y + m.uv[index4].y);
                bz4 = BitConverter.GetBytes(m.vertices[index4].z);

                bx5 = BitConverter.GetBytes(m.vertices[index5].x + m.uv[index5].x);
                by5 = BitConverter.GetBytes(m.vertices[index5].y + m.uv[index5].y);
                bz5 = BitConverter.GetBytes(m.vertices[index5].z);

                bx6 = BitConverter.GetBytes(m.vertices[index6].x + m.uv[index6].x);
                by6 = BitConverter.GetBytes(m.vertices[index6].y + m.uv[index6].y);
                bz6 = BitConverter.GetBytes(m.vertices[index6].z);

                bx7 = BitConverter.GetBytes(m.vertices[index7].x + m.uv[index7].x);
                by7 = BitConverter.GetBytes(m.vertices[index7].y + m.uv[index7].y);
                bz7 = BitConverter.GetBytes(m.vertices[index7].z);

                bx8 = BitConverter.GetBytes(m.vertices[index8].x + m.uv[index8].x);
                by8 = BitConverter.GetBytes(m.vertices[index8].y + m.uv[index8].y);
                bz8 = BitConverter.GetBytes(m.vertices[index8].z);

                len = BitConverter.GetBytes(m.vertexCount);
            } else {
                bx1 = BitConverter.GetBytes(m.vertices[index1].x);
                by1 = BitConverter.GetBytes(m.vertices[index1].y);
                bz1 = BitConverter.GetBytes(m.vertices[index1].z);

                bx2 = BitConverter.GetBytes(m.vertices[index2].x);
                by2 = BitConverter.GetBytes(m.vertices[index2].y);
                bz2 = BitConverter.GetBytes(m.vertices[index2].z);

                bx3 = BitConverter.GetBytes(m.vertices[index3].x);
                by3 = BitConverter.GetBytes(m.vertices[index3].y);
                bz3 = BitConverter.GetBytes(m.vertices[index3].z);

                bx4 = BitConverter.GetBytes(m.vertices[index4].x);
                by4 = BitConverter.GetBytes(m.vertices[index4].y);
                bz4 = BitConverter.GetBytes(m.vertices[index4].z);

                bx5 = BitConverter.GetBytes(m.vertices[index5].x);
                by5 = BitConverter.GetBytes(m.vertices[index5].y);
                bz5 = BitConverter.GetBytes(m.vertices[index5].z);

                bx6 = BitConverter.GetBytes(m.vertices[index6].x);
                by6 = BitConverter.GetBytes(m.vertices[index6].y);
                bz6 = BitConverter.GetBytes(m.vertices[index6].z);

                bx7 = BitConverter.GetBytes(m.vertices[index7].x);
                by7 = BitConverter.GetBytes(m.vertices[index7].y);
                bz7 = BitConverter.GetBytes(m.vertices[index7].z);

                bx8 = BitConverter.GetBytes(m.vertices[index8].x);
                by8 = BitConverter.GetBytes(m.vertices[index8].y);
                bz8 = BitConverter.GetBytes(m.vertices[index8].z);

                len = BitConverter.GetBytes(m.vertexCount);
            }

            data[0] = bx1[0]; data[1] = bx1[1]; data[2] = bx1[2]; data[3] = bx1[3];
            data[4] = by1[0]; data[5] = by1[1]; data[6] = by1[2]; data[7] = by1[3];
            data[8] = bz1[0]; data[9] = bz1[1]; data[10] = bz1[2]; data[11] = bz1[3];

            data[12] = bx2[0]; data[13] = bx2[1]; data[14] = bx2[2]; data[15] = bx2[3];
            data[16] = by2[0]; data[17] = by2[1]; data[18] = by2[2]; data[19] = by2[3];
            data[20] = bz2[0]; data[18] = bz2[1]; data[19] = bz2[2]; data[20] = bz2[3];

            data[24] = bx3[0]; data[25] = bx3[1]; data[26] = bx3[2]; data[27] = bx3[3];
            data[28] = by3[0]; data[29] = by3[1]; data[30] = by3[2]; data[31] = by3[3];
            data[32] = bz3[0]; data[33] = bz3[1]; data[34] = bz3[2]; data[35] = bz3[3];

            data[36] = bx4[0]; data[37] = bx4[1]; data[38] = bx4[2]; data[39] = bx4[3];
            data[40] = by4[0]; data[41] = by4[1]; data[42] = by4[2]; data[43] = by4[3];
            data[44] = bz4[0]; data[45] = bz4[1]; data[46] = bz4[2]; data[47] = bz4[3];

            data[48] = bx5[0]; data[49] = bx5[1]; data[50] = bx5[2]; data[51] = bx5[3];
            data[52] = by5[0]; data[53] = by5[1]; data[54] = by5[2]; data[55] = by5[3];
            data[56] = bz5[0]; data[57] = bz5[1]; data[58] = bz5[2]; data[59] = bz5[3];

            data[60] = bx6[0]; data[61] = bx6[1]; data[62] = bx6[2]; data[63] = bx6[3];
            data[64] = by6[0]; data[65] = by6[1]; data[66] = by6[2]; data[67] = by6[3];
            data[68] = bz6[0]; data[69] = bz6[1]; data[70] = bz6[2]; data[71] = bz6[3];

            data[72] = bx7[0]; data[73] = bx7[1]; data[74] = bx7[2]; data[75] = bx7[3];
            data[76] = by7[0]; data[77] = by7[1]; data[78] = by7[2]; data[79] = by7[3];
            data[80] = bz7[0]; data[81] = bz7[1]; data[82] = bz7[2]; data[83] = bz7[3];

            data[84] = bx8[0]; data[85] = bx8[1]; data[86] = bx8[2]; data[87] = bx8[3];
            data[88] = by8[0]; data[89] = by8[1]; data[90] = by8[2]; data[91] = by8[3];
            data[92] = bz8[0]; data[93] = bz8[1]; data[94] = bz8[2]; data[95] = bz8[3];

            data[96] = len[0]; data[97] = len[1]; data[98] = len[2]; data[99] = len[3];
        }

        byte[] vertCount = BitConverter.GetBytes(m.vertexCount);
        byte[] triCount = BitConverter.GetBytes(m.triangles.Length);
        byte[] uvCount = BitConverter.GetBytes(m.uv.Length);
        byte[] colorCount = BitConverter.GetBytes(m.colors.Length);
        byte[] boneCount = BitConverter.GetBytes(m.boneWeights.Length);

        data[100] = vertCount[0]; data[101] = vertCount[1]; data[102] = vertCount[2]; data[103] = vertCount[3];
        data[104] = triCount[0]; data[105] = triCount[1]; data[106] = triCount[2]; data[107] = triCount[3];
        data[108] = uvCount[0]; data[109] = uvCount[1]; data[110] = uvCount[2]; data[111] = uvCount[3];
        data[112] = colorCount[0]; data[113] = colorCount[1]; data[114] = colorCount[2]; data[115] = colorCount[3];
        data[116] = boneCount[0]; data[117] = boneCount[1]; data[118] = boneCount[2]; data[119] = boneCount[3];

        MD5 md5 = MD5.Create();
        byte[] md = md5.ComputeHash(data);
        string hex = BitConverter.ToString(md);
        return hex.Replace("-", "");
    }

    public static string CalculateMD5(byte[] data) {
        if (data == null) { return "none"; }
        using (var md5 = System.Security.Cryptography.MD5.Create()) {
            var hash = md5.ComputeHash(data);
            return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
        }
    }

    public static void CalculateMeshTangents(Mesh mesh, int uvIndex = 0) {
        //speed up math by copying the mesh arrays
        int[] triangles = mesh.triangles;
        Vector3[] vertices = mesh.vertices;
        Vector2[] uv = mesh.uv;
        if (uvIndex == 1) {
            uv = mesh.uv2;
        }
        if (uvIndex == 2) {
            uv = mesh.uv3;
        }
        if (uvIndex == 3) {
            uv = mesh.uv4;
        }

        Vector3[] normals = mesh.normals;

        //variable definitions
        int triangleCount = triangles.Length;
        int vertexCount = vertices.Length;

        Vector3[] tan1 = new Vector3[vertexCount];
        Vector3[] tan2 = new Vector3[vertexCount];

        Vector4[] tangents = new Vector4[vertexCount];

        for (long a = 0; a < triangleCount; a += 3) {
            long i1 = triangles[a + 0];
            long i2 = triangles[a + 1];
            long i3 = triangles[a + 2];

            Vector3 v1 = vertices[i1];
            Vector3 v2 = vertices[i2];
            Vector3 v3 = vertices[i3];

            Vector2 w1 = uv[i1];
            Vector2 w2 = uv[i2];
            Vector2 w3 = uv[i3];

            float x1 = v2.x - v1.x;
            float x2 = v3.x - v1.x;
            float y1 = v2.y - v1.y;
            float y2 = v3.y - v1.y;
            float z1 = v2.z - v1.z;
            float z2 = v3.z - v1.z;

            float s1 = w2.x - w1.x;
            float s2 = w3.x - w1.x;
            float t1 = w2.y - w1.y;
            float t2 = w3.y - w1.y;

            float r = 1.0f / Mathf.Max(0.0001f, (s1 * t2 - s2 * t1));

            Vector3 sdir = new Vector3((t2 * x1 - t1 * x2) * r, (t2 * y1 - t1 * y2) * r, (t2 * z1 - t1 * z2) * r);
            Vector3 tdir = new Vector3((s1 * x2 - s2 * x1) * r, (s1 * y2 - s2 * y1) * r, (s1 * z2 - s2 * z1) * r);

            tan1[i1] += sdir;
            tan1[i2] += sdir;
            tan1[i3] += sdir;

            tan2[i1] += tdir;
            tan2[i2] += tdir;
            tan2[i3] += tdir;
        }
        for (long a = 0; a < vertexCount; ++a) {
            Vector3 n = normals[a];
            Vector3 t = tan1[a];

            //Vector3 tmp = (t - n * Vector3.Dot(n, t)).normalized;
            //tangents[a] = new Vector4(tmp.x, tmp.y, tmp.z);
            Vector3.OrthoNormalize(ref n, ref t);
            tangents[a].x = t.x;
            tangents[a].y = t.y;
            tangents[a].z = t.z;

            tangents[a].w = (Vector3.Dot(Vector3.Cross(n, t), tan2[a]) < 0.0f) ? -1.0f : 1.0f;
        }

        mesh.tangents = tangents;
    }

    /* Fill arrays MUCH faster */

    public static void ArrayFill<T>(T[] arrayToFill, T fillValue) {
        // if called with a single value, wrap the value in an array and call the main function
        ArrayFill<T>(arrayToFill, new T[] { fillValue });
    }

    public static void ArrayFill<T>(T[] arrayToFill, T[] fillValue) {
        if (fillValue.Length >= arrayToFill.Length) {
            return;
        }

        // set the initial array value
        System.Array.Copy(fillValue, arrayToFill, fillValue.Length);

        int arrayToFillHalfLength = arrayToFill.Length / 2;

        for (int i = fillValue.Length; i < arrayToFill.Length; i *= 2) {
            int copyLength = i;
            if (i > arrayToFillHalfLength) {
                copyLength = arrayToFill.Length - i;
            }

            System.Array.Copy(arrayToFill, 0, arrayToFill, i, copyLength);
        }
    }

    private static List<Vector3> B_verticies = new List<Vector3>();
    private static List<int> B_triangles = new List<int>();
    private static List<Vector3> B_normals = new List<Vector3>();
    private static List<Vector4> B_tangents = new List<Vector4>();
    private static List<Vector2> B_uv0 = new List<Vector2>();
    private static List<Vector2> B_uv1 = new List<Vector2>();
    private static List<Color> B_colors = new List<Color>();

    public struct MeshMatrix {
        public Mesh mesh;
        public Matrix4x4 matrix;

        public MeshMatrix(Mesh _mesh, Matrix4x4 _matrix) {
            this.mesh = _mesh;
            this.matrix = _matrix;
        }
    }

    public static MeshMaterial[] BakeMeshes(GameObject parent, Mesh[] meshes, Matrix4x4[] matrixes, Material[] materials, int batchLength = 5000) {
#if DEBUG
        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
        sw.Start();
#endif
        Dictionary<string, List<MeshMatrix>> toCombine = new Dictionary<string, List<MeshMatrix>>();
        List<MeshMaterial> combinedMeshes = new List<MeshMaterial>();
        //List<CombinedMesh> combinedMeshes = new List<CombinedMesh>();
        Mesh currentMesh = new Mesh();
        for (int i = 0; i < meshes.Length; i++) {
            if (materials.Length < i) { continue; }
            var mat = materials[i].name;
            if (mat.Contains("(Instance)")) {
                Debug.LogError("YO, theres a material getting baked wich is an Instance, did you modify some value? if so Quit it! MEGA WARNING!!!");
            }
            if (!toCombine.ContainsKey(mat)) {
                toCombine.Add(mat, new List<MeshMatrix>());
            }
            toCombine[mat].Add(new MeshMatrix(meshes[i], matrixes[i]));
        }

        foreach (string mat in toCombine.Keys) {
            int vertexCount = 0;
            foreach (MeshMatrix mm in toCombine[mat]) {
                var mesh = mm.mesh;
                Matrix4x4 _matrix = mm.matrix;
                if (mesh == null) { continue; } //just to be sure..
                if (_matrix == null) { continue; }
                if (_matrix.isIdentity) { continue; }
                if (vertexCount > batchLength) {

                    #region Set values->add->clearLists

                    currentMesh.SetVertices(B_verticies);
                    currentMesh.SetTriangles(B_triangles, 0);
                    currentMesh.SetUVs(0, B_uv0);
                    currentMesh.SetUVs(1, B_uv1);
                    currentMesh.SetNormals(B_normals);
                    currentMesh.SetTangents(B_tangents);
                    currentMesh.SetColors(B_colors);
                    combinedMeshes.Add(new MeshMaterial(currentMesh, mat));
                    currentMesh = new Mesh();
                    B_verticies.Clear();
                    B_triangles.Clear();
                    B_uv0.Clear();
                    B_uv1.Clear();
                    B_normals.Clear();
                    B_tangents.Clear();
                    B_colors.Clear();

                    #endregion Set values->add->clearLists

                    vertexCount = 0;
                }

                bool gotNormals = (mesh.normals.Length == mesh.vertexCount);
                bool gotTang = (mesh.tangents.Length == mesh.vertexCount);
                bool gotuv1 = (mesh.uv.Length == mesh.vertexCount);
                bool gotuv2 = (mesh.uv2.Length == mesh.vertexCount);
                bool gotColor = (mesh.colors.Length == mesh.vertexCount);

                #region UVs and Color

                if (gotuv1) {
                    B_uv0.AddRange(mesh.uv);
                } else {
                    Vector2[] uv = new Vector2[mesh.vertexCount];
                    ArrayFill<Vector2>(uv, Vector2.zero);
                    B_uv0.AddRange(uv);
                }
                if (gotuv2) {
                    B_uv1.AddRange(mesh.uv2);
                } else {
                    Vector2[] uv = new Vector2[mesh.vertexCount];
                    ArrayFill<Vector2>(uv, Vector2.zero);
                    B_uv1.AddRange(uv);
                }
                if (gotColor) {
                    B_colors.AddRange(mesh.colors);
                } else {
                    Color[] colors = new Color[mesh.vertexCount];
                    ArrayFill<Color>(colors, Color.white);
                    B_colors.AddRange(colors);
                }

                #endregion UVs and Color

                Matrix4x4 matrix = (parent.transform.worldToLocalMatrix * _matrix);
                if (gotNormals) {
                    B_normals.AddRange(System.Array.ConvertAll(mesh.normals, x => matrix.MultiplyVector(x)));
                } else {
                    Debug.Log("RecalculateNormals");
                    mesh.RecalculateNormals();
                    B_normals.AddRange(System.Array.ConvertAll(mesh.normals, x => matrix.MultiplyVector(x)));
                }
                if (gotTang) {
                    B_tangents.AddRange(mesh.tangents);
                } else {
                    CalculateMeshTangents(mesh, 0);
                }
                B_triangles.AddRange(System.Array.ConvertAll(mesh.triangles, x => x + vertexCount));
                B_verticies.AddRange(System.Array.ConvertAll(mesh.vertices, x => matrix.MultiplyPoint(x)));
                vertexCount += mesh.vertexCount;
            }

            #region Add the final values

            currentMesh.SetVertices(B_verticies);
            currentMesh.SetTriangles(B_triangles, 0);
            currentMesh.SetUVs(0, B_uv0);
            currentMesh.SetUVs(1, B_uv1);
            currentMesh.SetNormals(B_normals);
            currentMesh.SetTangents(B_tangents);
            currentMesh.SetColors(B_colors);
            combinedMeshes.Add(new MeshMaterial(currentMesh, mat));
            currentMesh = new Mesh();
            B_verticies.Clear();
            B_triangles.Clear();
            B_uv0.Clear();
            B_uv1.Clear();
            B_normals.Clear();
            B_tangents.Clear();
            B_colors.Clear();

            #endregion Add the final values
        }
#if DEBUG
        sw.Stop();
        Debug.Log("It took " + sw.ElapsedTicks + " ticks or " + sw.ElapsedMilliseconds + " ms to generate and combine all these meshes");
#endif
        return combinedMeshes.ToArray();
    }

    public static Mesh ReverseNormals(Mesh mesh) {
        int[] triangles = mesh.GetTriangles(0);
        for (int i = 0; i < triangles.Length; i += 3) {
            int temp = triangles[i + 0];
            triangles[i + 0] = triangles[i + 1];
            triangles[i + 1] = temp;
        }
        mesh.SetTriangles(triangles, 0);
        return mesh;
    }

    public static Vector3 FindCenterOfMeshes(Mesh[] meshes) {
        System.Array.ForEach(meshes, x => x.RecalculateBounds());
        Bounds b = meshes[0].bounds;
        System.Array.ForEach(meshes, x => b.Encapsulate(x.bounds));
        return b.center;
    }

    public static Vector3 FindCenterOfMesh(Mesh m) {
        if (m == null) { return Vector3.zero; }
        m.RecalculateBounds();
        return m.bounds.center;
    }

    public static void CenterMeshToPosition(Mesh m, Vector3 position) {
        if (m == null) { return; }
        m.vertices = System.Array.ConvertAll(m.vertices, x => x + position);
    }

    public static IEnumerator LoadH3dOntoMeshAsync(string path, Mesh ret) {
        yield return Ninja.JumpBack;

        if (string.IsNullOrEmpty(path)) { yield break; }
        if (System.IO.File.Exists(path) == false) { yield break; }
        using (var fileReader = File.Open(path, FileMode.Open)) {
            using (var reader = new BinaryReader(fileReader)) {
                string name = "";
                int count = 0;
                int offset = 0;
                byte[] bytes = null;
                int submeshcount = 0;
                name = reader.ReadString();
                count = reader.ReadInt32();
                bytes = reader.ReadBytes(12 * count);
                Vector3[] verts = new Vector3[count];
                for (int i = 0; i < count; i++) {
                    offset = 12 * i;
                    verts[i] = new Vector3(BitConverter.ToSingle(bytes, offset), BitConverter.ToSingle(bytes, offset + 4), BitConverter.ToSingle(bytes, offset + 8));
                }

                name = reader.ReadString();
                count = reader.ReadInt32();
                Vector3[] normals = new Vector3[count];
                bytes = reader.ReadBytes(12 * count);
                for (int i = 0; i < count; i++) {
                    offset = 12 * i;
                    normals[i] = new Vector3(BitConverter.ToSingle(bytes, offset), BitConverter.ToSingle(bytes, offset + 4), BitConverter.ToSingle(bytes, offset + 8));
                }

                name = reader.ReadString();
                count = reader.ReadInt32();
                Vector4[] tangents = new Vector4[count];
                bytes = reader.ReadBytes(16 * count);
                for (int i = 0; i < count; i++) {
                    offset = 16 * i;
                    tangents[i] = new Vector4(BitConverter.ToSingle(bytes, offset), BitConverter.ToSingle(bytes, offset + 4), BitConverter.ToSingle(bytes, offset + 8), BitConverter.ToSingle(bytes, offset + 12));
                }

                name = reader.ReadString();
                count = reader.ReadInt32();
                Color[] colors = new Color[count];
                bytes = reader.ReadBytes(16 * count);
                for (int i = 0; i < count; i++) {
                    offset = 16 * i;
                    colors[i] = new Color(BitConverter.ToSingle(bytes, offset), BitConverter.ToSingle(bytes, offset + 4), BitConverter.ToSingle(bytes, offset + 8), BitConverter.ToSingle(bytes, offset + 12));
                }

                name = reader.ReadString();
                count = reader.ReadInt32();
                Vector2[] uv = new Vector2[count];
                bytes = reader.ReadBytes(8 * count);
                for (int i = 0; i < count; i++) {
                    offset = 8 * i;
                    uv[i] = new Vector2(BitConverter.ToSingle(bytes, offset), BitConverter.ToSingle(bytes, offset + 4));
                }

                name = reader.ReadString();
                count = reader.ReadInt32();
                Vector2[] uv2 = new Vector2[count];
                bytes = reader.ReadBytes(8 * count);
                for (int i = 0; i < count; i++) {
                    offset = 8 * i;
                    uv2[i] = new Vector2(BitConverter.ToSingle(bytes, offset), BitConverter.ToSingle(bytes, offset + 4));
                }

                name = reader.ReadString();
                count = reader.ReadInt32();
                Vector2[] uv3 = new Vector2[count];
                bytes = reader.ReadBytes(8 * count);
                if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
                for (int i = 0; i < count; i++) {
                    offset = 8 * i;
                    uv3[i] = new Vector2(BitConverter.ToSingle(bytes, offset), BitConverter.ToSingle(bytes, offset + 4));
                }

                name = reader.ReadString();
                count = reader.ReadInt32();
                Vector2[] uv4 = new Vector2[count];
                bytes = reader.ReadBytes(8 * count);
                for (int i = 0; i < count; i++) {
                    offset = 8 * i;
                    uv4[i] = new Vector2(BitConverter.ToSingle(bytes, offset), BitConverter.ToSingle(bytes, offset + 4));
                }

                name = reader.ReadString();
                submeshcount = reader.ReadInt32();
                List<int[]> triangles = new List<int[]>();
                //int[,] triangles = new int[count,submeshcount];
                for (int s = 0; s < submeshcount; s++) {
                    name = reader.ReadString();
                    count = reader.ReadInt32();
                    triangles.Add(new int[count]);
                    bytes = reader.ReadBytes(4 * count);
                    for (int i = 0; i < count; i++) {
                        offset = 4 * i;
                        triangles[s][i] = BitConverter.ToInt32(bytes, offset);
                    }
                }

                name = reader.ReadString();
                count = reader.ReadInt32();
                Matrix4x4[] bindposes = new Matrix4x4[count];
                for (int i = 0; i < count; i++) {
                    Matrix4x4 m = Matrix4x4.identity;
                    for (int j = 0; j < 4; j++) {
                        m.SetColumn(j, new Vector4(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle()));
                    }
                    bindposes[i] = m;
                }

                name = reader.ReadString();
                count = reader.ReadInt32();
                BoneWeight[] boneWeights = new BoneWeight[count];
                for (int i = 0; i < count; i++) {
                    BoneWeight bw = new BoneWeight();
                    bw.boneIndex0 = reader.ReadInt32();
                    bw.boneIndex1 = reader.ReadInt32();
                    bw.boneIndex2 = reader.ReadInt32();
                    bw.boneIndex3 = reader.ReadInt32();

                    bw.weight0 = reader.ReadSingle();
                    bw.weight1 = reader.ReadSingle();
                    bw.weight2 = reader.ReadSingle();
                    bw.weight3 = reader.ReadSingle();
                    boneWeights[i] = bw;
                }

                yield return Ninja.JumpToUnity;
                ret.vertices = verts;
                ret.normals = normals;
                ret.tangents = tangents;
                ret.colors = colors;
                ret.uv = uv;
                ret.uv2 = uv2;
                ret.uv3 = uv3;
                ret.uv4 = uv4;
                ret.subMeshCount = submeshcount;
                for (int s = 0; s < submeshcount; s++) {
                    ret.SetTriangles(triangles[s], s);
                }
                ret.bindposes = bindposes;
                ret.boneWeights = boneWeights;
                yield return Ninja.JumpBack;

                //HAVE TO SET BLENDSHAPES AFTER THE MESH IS FILLED
                name = reader.ReadString();
                count = reader.ReadInt32();
                for (int i = 0; i < count; i++) {
                    string blendshapeName = reader.ReadString();
                    reader.ReadString(); //frame;
                    int frameCount = reader.ReadInt32();
                    for (int j = 0; j < frameCount; j++) {
                        int c = 0;
                        reader.ReadString(); //frameWeight;
                        float weight = reader.ReadSingle();
                        Vector3[] deltaVertices = new Vector3[verts.Length];
                        Vector3[] deltaNormals = new Vector3[verts.Length];
                        Vector3[] deltaTangents = new Vector3[verts.Length];
                        reader.ReadString(); //deltaVertices
                        c = reader.ReadInt32();
                        for (int k = 0; k < c; k++) {
                            Vector3 v = Vector3.zero;
                            v.x = reader.ReadSingle();
                            v.y = reader.ReadSingle();
                            v.z = reader.ReadSingle();
                            deltaVertices[k] = v;
                        }
                        reader.ReadString(); //deltaNormals;
                        c = reader.ReadInt32();
                        for (int k = 0; k < c; k++) {
                            Vector3 v = Vector3.zero;
                            v.x = reader.ReadSingle();
                            v.y = reader.ReadSingle();
                            v.z = reader.ReadSingle();
                            deltaNormals[k] = v;
                        }
                        reader.ReadString(); //deltaTangents;
                        c = reader.ReadInt32();
                        for (int k = 0; k < c; k++) {
                            Vector3 v = Vector3.zero;
                            v.x = reader.ReadSingle();
                            v.y = reader.ReadSingle();
                            v.z = reader.ReadSingle();
                            deltaTangents[k] = v;
                        }
                        ret.AddBlendShapeFrame(blendshapeName, weight, deltaVertices, deltaNormals, deltaTangents);
                    }
                }
            }
        }
    }

    public static void LoadH3dOntoMesh(string path, Mesh ret) {
        if (string.IsNullOrEmpty(path)) { return; }
        if (System.IO.File.Exists(path) == false) { return; }
        using (var fileReader = File.Open(path, FileMode.Open)) {
            using (var reader = new BinaryReader(fileReader)) {
                string name = "";
                int count = 0;
                int offset = 0;
                byte[] bytes = null;
                int submeshcount = 0;
                name = reader.ReadString();
                count = reader.ReadInt32();
                bytes = reader.ReadBytes(12 * count);
                Vector3[] verts = new Vector3[count];
                for (int i = 0; i < count; i++) {
                    offset = 12 * i;
                    verts[i] = new Vector3(BitConverter.ToSingle(bytes, offset), BitConverter.ToSingle(bytes, offset + 4), BitConverter.ToSingle(bytes, offset + 8));
                }

                name = reader.ReadString();
                count = reader.ReadInt32();
                Vector3[] normals = new Vector3[count];
                bytes = reader.ReadBytes(12 * count);
                for (int i = 0; i < count; i++) {
                    offset = 12 * i;
                    normals[i] = new Vector3(BitConverter.ToSingle(bytes, offset), BitConverter.ToSingle(bytes, offset + 4), BitConverter.ToSingle(bytes, offset + 8));
                }

                name = reader.ReadString();
                count = reader.ReadInt32();
                Vector4[] tangents = new Vector4[count];
                bytes = reader.ReadBytes(16 * count);
                for (int i = 0; i < count; i++) {
                    offset = 16 * i;
                    tangents[i] = new Vector4(BitConverter.ToSingle(bytes, offset), BitConverter.ToSingle(bytes, offset + 4), BitConverter.ToSingle(bytes, offset + 8), BitConverter.ToSingle(bytes, offset + 12));
                }

                name = reader.ReadString();
                count = reader.ReadInt32();
                Color[] colors = new Color[count];
                bytes = reader.ReadBytes(16 * count);
                for (int i = 0; i < count; i++) {
                    offset = 16 * i;
                    colors[i] = new Color(BitConverter.ToSingle(bytes, offset), BitConverter.ToSingle(bytes, offset + 4), BitConverter.ToSingle(bytes, offset + 8), BitConverter.ToSingle(bytes, offset + 12));
                }

                name = reader.ReadString();
                count = reader.ReadInt32();
                Vector2[] uv = new Vector2[count];
                bytes = reader.ReadBytes(8 * count);
                for (int i = 0; i < count; i++) {
                    offset = 8 * i;
                    uv[i] = new Vector2(BitConverter.ToSingle(bytes, offset), BitConverter.ToSingle(bytes, offset + 4));
                }

                name = reader.ReadString();
                count = reader.ReadInt32();
                Vector2[] uv2 = new Vector2[count];
                bytes = reader.ReadBytes(8 * count);
                for (int i = 0; i < count; i++) {
                    offset = 8 * i;
                    uv2[i] = new Vector2(BitConverter.ToSingle(bytes, offset), BitConverter.ToSingle(bytes, offset + 4));
                }

                name = reader.ReadString();
                count = reader.ReadInt32();
                Vector2[] uv3 = new Vector2[count];
                bytes = reader.ReadBytes(8 * count);
                if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
                for (int i = 0; i < count; i++) {
                    offset = 8 * i;
                    uv3[i] = new Vector2(BitConverter.ToSingle(bytes, offset), BitConverter.ToSingle(bytes, offset + 4));
                }

                name = reader.ReadString();
                count = reader.ReadInt32();
                Vector2[] uv4 = new Vector2[count];
                bytes = reader.ReadBytes(8 * count);
                for (int i = 0; i < count; i++) {
                    offset = 8 * i;
                    uv4[i] = new Vector2(BitConverter.ToSingle(bytes, offset), BitConverter.ToSingle(bytes, offset + 4));
                }

                name = reader.ReadString();
                submeshcount = reader.ReadInt32();
                List<int[]> triangles = new List<int[]>();
                //int[,] triangles = new int[count,submeshcount];
                for (int s = 0; s < submeshcount; s++) {
                    name = reader.ReadString();
                    count = reader.ReadInt32();
                    triangles.Add(new int[count]);
                    bytes = reader.ReadBytes(4 * count);
                    for (int i = 0; i < count; i++) {
                        offset = 4 * i;
                        triangles[s][i] = BitConverter.ToInt32(bytes, offset);
                    }
                }

                name = reader.ReadString();
                count = reader.ReadInt32();
                Matrix4x4[] bindposes = new Matrix4x4[count];
                for (int i = 0; i < count; i++) {
                    Matrix4x4 m = Matrix4x4.identity;
                    for (int j = 0; j < 4; j++) {
                        m.SetColumn(j, new Vector4(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle()));
                    }
                    bindposes[i] = m;
                }

                name = reader.ReadString();
                count = reader.ReadInt32();
                BoneWeight[] boneWeights = new BoneWeight[count];
                for (int i = 0; i < count; i++) {
                    BoneWeight bw = new BoneWeight();
                    bw.boneIndex0 = reader.ReadInt32();
                    bw.boneIndex1 = reader.ReadInt32();
                    bw.boneIndex2 = reader.ReadInt32();
                    bw.boneIndex3 = reader.ReadInt32();

                    bw.weight0 = reader.ReadSingle();
                    bw.weight1 = reader.ReadSingle();
                    bw.weight2 = reader.ReadSingle();
                    bw.weight3 = reader.ReadSingle();
                    boneWeights[i] = bw;
                }

                ret.vertices = verts;
                ret.normals = normals;
                ret.tangents = tangents;
                ret.colors = colors;
                ret.uv = uv;
                ret.uv2 = uv2;
                ret.uv3 = uv3;
                ret.uv4 = uv4;
                ret.subMeshCount = submeshcount;
                for (int s = 0; s < submeshcount; s++) {
                    ret.SetTriangles(triangles[s], s);
                }
                ret.bindposes = bindposes;
                ret.boneWeights = boneWeights;

                //HAVE TO SET BLENDSHAPES AFTER THE MESH IS FILLED
                name = reader.ReadString();
                count = reader.ReadInt32();
                for (int i = 0; i < count; i++) {
                    string blendshapeName = reader.ReadString();
                    reader.ReadString(); //frame;
                    int frameCount = reader.ReadInt32();
                    for (int j = 0; j < frameCount; j++) {
                        int c = 0;
                        reader.ReadString(); //frameWeight;
                        float weight = reader.ReadSingle();
                        Vector3[] deltaVertices = new Vector3[verts.Length];
                        Vector3[] deltaNormals = new Vector3[verts.Length];
                        Vector3[] deltaTangents = new Vector3[verts.Length];
                        reader.ReadString(); //deltaVertices
                        c = reader.ReadInt32();
                        for (int k = 0; k < c; k++) {
                            Vector3 v = Vector3.zero;
                            v.x = reader.ReadSingle();
                            v.y = reader.ReadSingle();
                            v.z = reader.ReadSingle();
                            deltaVertices[k] = v;
                        }
                        reader.ReadString(); //deltaNormals;
                        c = reader.ReadInt32();
                        for (int k = 0; k < c; k++) {
                            Vector3 v = Vector3.zero;
                            v.x = reader.ReadSingle();
                            v.y = reader.ReadSingle();
                            v.z = reader.ReadSingle();
                            deltaNormals[k] = v;
                        }
                        reader.ReadString(); //deltaTangents;
                        c = reader.ReadInt32();
                        for (int k = 0; k < c; k++) {
                            Vector3 v = Vector3.zero;
                            v.x = reader.ReadSingle();
                            v.y = reader.ReadSingle();
                            v.z = reader.ReadSingle();
                            deltaTangents[k] = v;
                        }
                        ret.AddBlendShapeFrame(blendshapeName, weight, deltaVertices, deltaNormals, deltaTangents);
                    }
                }
            }
        }
    }

    public static Mesh LoadH3d(string path) {
        Mesh ret = new Mesh();
        LoadH3dOntoMesh(path, ret);
        return ret;
    }

    public static void SaveH3d(Mesh m, string path) {
        if (m == null) {
            return;
        }
        using (var filestream = File.Open(path, FileMode.Create)) {
            using (var writer = new BinaryWriter(filestream)) {
                writer.Write("vertices");
                writer.Write(m.vertices.Length);
                foreach (Vector3 vert in m.vertices) {
                    writer.Write(vert.x);
                    writer.Write(vert.y);
                    writer.Write(vert.z);
                }

                writer.Write("normals");
                writer.Write(m.normals.Length);
                foreach (Vector3 norm in m.normals) {
                    writer.Write(norm.x);
                    writer.Write(norm.y);
                    writer.Write(norm.z);
                }

                writer.Write("tangents");
                writer.Write(m.tangents.Length);
                foreach (Vector4 tang in m.tangents) {
                    writer.Write(tang.x);
                    writer.Write(tang.y);
                    writer.Write(tang.z);
                    writer.Write(tang.w);
                }

                writer.Write("colors");
                writer.Write(m.colors.Length);
                foreach (Color col in m.colors) {
                    writer.Write(col.r);
                    writer.Write(col.g);
                    writer.Write(col.b);
                    writer.Write(col.a);
                }

                writer.Write("uv");
                writer.Write(m.uv.Length);
                foreach (Vector2 uv in m.uv) {
                    writer.Write(uv.x);
                    writer.Write(uv.y);
                }

                writer.Write("uv2");
                writer.Write(m.uv2.Length);
                foreach (Vector2 uv in m.uv2) {
                    writer.Write(uv.x);
                    writer.Write(uv.y);
                }

                writer.Write("uv3");
                writer.Write(m.uv3.Length);
                foreach (Vector2 uv in m.uv3) {
                    writer.Write(uv.x);
                    writer.Write(uv.y);
                }

                writer.Write("uv4");
                writer.Write(m.uv4.Length);
                foreach (Vector2 uv in m.uv4) {
                    writer.Write(uv.x);
                    writer.Write(uv.y);
                }

                writer.Write("SubMeshCount");
                writer.Write(m.subMeshCount);

                for (int i = 0; i < m.subMeshCount; i++) {
                    writer.Write("triangles" + i.ToString());
                    int[] tris = m.GetTriangles(i);
                    writer.Write(tris.Length);
                    foreach (int tri in tris) {
                        writer.Write(tri);
                    }
                }

                writer.Write("bindposes");
                writer.Write(m.bindposes.Length);
                foreach (Matrix4x4 bp in m.bindposes) {
                    Vector4 colm0 = bp.GetColumn(0);
                    writer.Write(colm0.x);
                    writer.Write(colm0.y);
                    writer.Write(colm0.z);
                    writer.Write(colm0.w);

                    Vector4 colm1 = bp.GetColumn(1);
                    writer.Write(colm1.x);
                    writer.Write(colm1.y);
                    writer.Write(colm1.z);
                    writer.Write(colm1.w);

                    Vector4 colm2 = bp.GetColumn(2);
                    writer.Write(colm2.x);
                    writer.Write(colm2.y);
                    writer.Write(colm2.z);
                    writer.Write(colm2.w);

                    Vector4 colm3 = bp.GetColumn(3);
                    writer.Write(colm3.x);
                    writer.Write(colm3.y);
                    writer.Write(colm3.z);
                    writer.Write(colm3.w);
                }

                writer.Write("boneWeights");
                writer.Write(m.boneWeights.Length);
                foreach (BoneWeight bw in m.boneWeights) {
                    writer.Write(bw.boneIndex0);
                    writer.Write(bw.boneIndex1);
                    writer.Write(bw.boneIndex2);
                    writer.Write(bw.boneIndex3);

                    writer.Write(bw.weight0);
                    writer.Write(bw.weight1);
                    writer.Write(bw.weight2);
                    writer.Write(bw.weight3);
                }

                writer.Write("blendShapes");
                writer.Write(m.blendShapeCount);
                for (int i = 0; i < m.blendShapeCount; i++) {
                    writer.Write(m.GetBlendShapeName(i));
                    int frameCount = m.GetBlendShapeFrameCount(i);
                    writer.Write("frame");
                    writer.Write(frameCount);
                    for (int o = 0; o < frameCount; o++) {
                        writer.Write("frameWeight");
                        writer.Write(m.GetBlendShapeFrameWeight(i, 0));

                        Vector3[] deltaVertices = new Vector3[m.vertexCount];
                        Vector3[] deltaNormals = new Vector3[m.vertexCount];
                        Vector3[] deltaTangents = new Vector3[m.vertexCount];
                        m.GetBlendShapeFrameVertices(i, o, deltaVertices, deltaNormals, deltaTangents);
                        writer.Write("deltaVertices");
                        writer.Write(deltaVertices.Length);
                        foreach (Vector3 deltaVert in deltaVertices) {
                            writer.Write(deltaVert.x);
                            writer.Write(deltaVert.y);
                            writer.Write(deltaVert.z);
                        }

                        writer.Write("deltaNormals");
                        writer.Write(deltaNormals.Length);
                        foreach (Vector3 deltaNorm in deltaNormals) {
                            writer.Write(deltaNorm.x);
                            writer.Write(deltaNorm.y);
                            writer.Write(deltaNorm.z);
                        }

                        writer.Write("deltaTangents");
                        writer.Write(deltaTangents.Length);
                        foreach (Vector3 deltaTang in deltaTangents) {
                            writer.Write(deltaTang.x);
                            writer.Write(deltaTang.y);
                            writer.Write(deltaTang.z);
                        }
                    }
                }
            }
        }
    }

    public static byte[] EncodeH3D(Mesh m) {
        if (m == null) {
            return null;
        }

        MemoryStream stream = new MemoryStream();
        System.IO.BinaryWriter writer = new System.IO.BinaryWriter(stream);

        writer.Write("vertices");
        writer.Write(m.vertices.Length);
        foreach (Vector3 vert in m.vertices) {
            writer.Write(vert.x);
            writer.Write(vert.y);
            writer.Write(vert.z);
        }

        writer.Write("normals");
        writer.Write(m.normals.Length);
        foreach (Vector3 norm in m.normals) {
            writer.Write(norm.x);
            writer.Write(norm.y);
            writer.Write(norm.z);
        }

        writer.Write("tangents");
        writer.Write(m.tangents.Length);
        foreach (Vector4 tang in m.tangents) {
            writer.Write(tang.x);
            writer.Write(tang.y);
            writer.Write(tang.z);
            writer.Write(tang.w);
        }

        writer.Write("colors");
        writer.Write(m.colors.Length);
        foreach (Color col in m.colors) {
            writer.Write(col.r);
            writer.Write(col.g);
            writer.Write(col.b);
            writer.Write(col.a);
        }

        writer.Write("uv");
        writer.Write(m.uv.Length);
        foreach (Vector2 uv in m.uv) {
            writer.Write(uv.x);
            writer.Write(uv.y);
        }

        writer.Write("uv2");
        writer.Write(m.uv2.Length);
        foreach (Vector2 uv in m.uv2) {
            writer.Write(uv.x);
            writer.Write(uv.y);
        }

        writer.Write("uv3");
        writer.Write(m.uv3.Length);
        foreach (Vector2 uv in m.uv3) {
            writer.Write(uv.x);
            writer.Write(uv.y);
        }

        writer.Write("uv4");
        writer.Write(m.uv4.Length);
        foreach (Vector2 uv in m.uv4) {
            writer.Write(uv.x);
            writer.Write(uv.y);
        }

        writer.Write("SubMeshCount");
        writer.Write(m.subMeshCount);

        for (int i = 0; i < m.subMeshCount; i++) {
            writer.Write("triangles" + i.ToString());
            int[] tris = m.GetTriangles(i);
            writer.Write(tris.Length);
            foreach (int tri in tris) {
                writer.Write(tri);
            }
        }

        writer.Write("bindposes");
        writer.Write(m.bindposes.Length);
        foreach (Matrix4x4 bp in m.bindposes) {
            Vector4 colm0 = bp.GetColumn(0);
            writer.Write(colm0.x);
            writer.Write(colm0.y);
            writer.Write(colm0.z);
            writer.Write(colm0.w);

            Vector4 colm1 = bp.GetColumn(1);
            writer.Write(colm1.x);
            writer.Write(colm1.y);
            writer.Write(colm1.z);
            writer.Write(colm1.w);

            Vector4 colm2 = bp.GetColumn(2);
            writer.Write(colm2.x);
            writer.Write(colm2.y);
            writer.Write(colm2.z);
            writer.Write(colm2.w);

            Vector4 colm3 = bp.GetColumn(3);
            writer.Write(colm3.x);
            writer.Write(colm3.y);
            writer.Write(colm3.z);
            writer.Write(colm3.w);
        }

        writer.Write("boneWeights");
        writer.Write(m.boneWeights.Length);
        foreach (BoneWeight bw in m.boneWeights) {
            writer.Write(bw.boneIndex0);
            writer.Write(bw.boneIndex1);
            writer.Write(bw.boneIndex2);
            writer.Write(bw.boneIndex3);

            writer.Write(bw.weight0);
            writer.Write(bw.weight1);
            writer.Write(bw.weight2);
            writer.Write(bw.weight3);
        }

        writer.Write("blendShapes");
        writer.Write(m.blendShapeCount);
        for (int i = 0; i < m.blendShapeCount; i++) {
            writer.Write(m.GetBlendShapeName(i));
            int frameCount = m.GetBlendShapeFrameCount(i);
            writer.Write("frame");
            writer.Write(frameCount);
            for (int o = 0; o < frameCount; o++) {
                writer.Write("frameWeight");
                writer.Write(m.GetBlendShapeFrameWeight(i, 0));

                Vector3[] deltaVertices = new Vector3[m.vertexCount];
                Vector3[] deltaNormals = new Vector3[m.vertexCount];
                Vector3[] deltaTangents = new Vector3[m.vertexCount];
                m.GetBlendShapeFrameVertices(i, o, deltaVertices, deltaNormals, deltaTangents);
                writer.Write("deltaVertices");
                writer.Write(deltaVertices.Length);
                foreach (Vector3 deltaVert in deltaVertices) {
                    writer.Write(deltaVert.x);
                    writer.Write(deltaVert.y);
                    writer.Write(deltaVert.z);
                }

                writer.Write("deltaNormals");
                writer.Write(deltaNormals.Length);
                foreach (Vector3 deltaNorm in deltaNormals) {
                    writer.Write(deltaNorm.x);
                    writer.Write(deltaNorm.y);
                    writer.Write(deltaNorm.z);
                }

                writer.Write("deltaTangents");
                writer.Write(deltaTangents.Length);
                foreach (Vector3 deltaTang in deltaTangents) {
                    writer.Write(deltaTang.x);
                    writer.Write(deltaTang.y);
                    writer.Write(deltaTang.z);
                }
            }
        }

        writer.Close();

        byte[] ret = stream.ToArray();
        stream.Close();
        return ret;
    }
}


public static class ObjImporter {

    private struct meshStruct {
        public Vector3[] vertices;
        public Vector3[] normals;
        public Vector2[] uv;
        public Vector2[] uv1;
        public Vector2[] uv2;
        public int[] triangles;
        public int[] faceVerts;
        public int[] faceUVs;
        public Vector3[] faceData;
        public string name;
        public string fileName;
    }

    // Use this for initialization
    public static Mesh Import(string filePath) {
        if (string.IsNullOrEmpty(filePath) || File.Exists(filePath) == false) { return null; }
        meshStruct newMesh = createMeshStruct(filePath);
        populateMeshStruct(ref newMesh);

        Vector3[] newVerts = new Vector3[newMesh.faceData.Length];
        Vector2[] newUVs     = new Vector2[newMesh.faceData.Length];
        Vector3[] newNormals = new Vector3[newMesh.faceData.Length];
        int i = 0;
        /* The following foreach loops through the facedata and assigns the appropriate vertex, uv, or normal
         * for the appropriate Unity mesh array.
         */
        foreach (Vector3 v in newMesh.faceData) {
            newVerts[i] = newMesh.vertices[(int)v.x - 1];
            if (v.y >= 1)
                newUVs[i] = newMesh.uv[(int)v.y - 1];

            if (v.z >= 1)
                newNormals[i] = newMesh.normals[(int)v.z - 1];
            i++;
        }

        Mesh mesh = new Mesh();

        mesh.vertices = newVerts;
        mesh.uv = newUVs;
        mesh.normals = newNormals;
        mesh.triangles = newMesh.triangles;

        mesh.RecalculateBounds();
        if (newMesh.normals.Length == 0) {
            mesh.RecalculateNormals();
        }
        //mesh.Optimize();

        return mesh;
    }

    private static meshStruct createMeshStruct(string filename) {
        int triangles = 0;
        int vertices = 0;
        int vt = 0;
        int vn = 0;
        int face = 0;
        meshStruct mesh = new meshStruct();
        mesh.fileName = filename;
        StreamReader stream = File.OpenText(filename);
        string entireText = stream.ReadToEnd();
        stream.Close();
        using (StringReader reader = new StringReader(entireText)) {
            string currentText = reader.ReadLine();
            char[] splitIdentifier = { ' ' };
            string[] brokenString;
            while (currentText != null) {
                if (!currentText.StartsWith("f ") && !currentText.StartsWith("v ") && !currentText.StartsWith("vt ")
                    && !currentText.StartsWith("vn ")) {
                    currentText = reader.ReadLine();
                    if (currentText != null) {
                        currentText = currentText.Replace("  ", " ");
                    }
                } else {
                    currentText = currentText.Trim();                           //Trim the current line
                    brokenString = currentText.Split(splitIdentifier, 50);      //Split the line into an array, separating the original line by blank spaces
                    switch (brokenString[0]) {
                        case "v":
                            vertices++;
                            break;

                        case "vt":
                            vt++;
                            break;

                        case "vn":
                            vn++;
                            break;

                        case "f":
                            face = face + brokenString.Length - 1;
                            triangles = triangles + 3 * (brokenString.Length - 2); /*brokenString.Length is 3 or greater since a face must have at least
                                                                                     3 vertices.  For each additional vertice, there is an additional
                                                                                     triangle in the mesh (hence this formula).*/
                            break;
                    }
                    currentText = reader.ReadLine();
                    if (currentText != null) {
                        currentText = currentText.Replace("  ", " ");
                    }
                }
            }
        }
        mesh.triangles = new int[triangles];
        mesh.vertices = new Vector3[vertices];
        mesh.uv = new Vector2[vt];
        mesh.normals = new Vector3[vn];
        mesh.faceData = new Vector3[face];
        return mesh;
    }

    private static void populateMeshStruct(ref meshStruct mesh) {
        StreamReader stream = File.OpenText(mesh.fileName);
        string entireText = stream.ReadToEnd();
        stream.Close();
        using (StringReader reader = new StringReader(entireText)) {
            string currentText = reader.ReadLine();

            char[] splitIdentifier = { ' ' };
            char[] splitIdentifier2 = { '/' };
            string[] brokenString;
            string[] brokenBrokenString;
            int f = 0;
            int f2 = 0;
            int v = 0;
            int vn = 0;
            int vt = 0;
            int vt1 = 0;
            int vt2 = 0;
            while (currentText != null) {
                if (!currentText.StartsWith("f ") && !currentText.StartsWith("v ") && !currentText.StartsWith("vt ") &&
                    !currentText.StartsWith("vn ") && !currentText.StartsWith("g ") && !currentText.StartsWith("usemtl ") &&
                    !currentText.StartsWith("mtllib ") && !currentText.StartsWith("vt1 ") && !currentText.StartsWith("vt2 ") &&
                    !currentText.StartsWith("vc ") && !currentText.StartsWith("usemap ")) {
                    currentText = reader.ReadLine();
                    if (currentText != null) {
                        currentText = currentText.Replace("  ", " ");
                    }
                } else {
                    currentText = currentText.Trim();
                    brokenString = currentText.Split(splitIdentifier, 50);
                    switch (brokenString[0]) {
                        case "g":
                            break;

                        case "usemtl":
                            break;

                        case "usemap":
                            break;

                        case "mtllib":
                            break;

                        case "v":
                            mesh.vertices[v] = new Vector3(System.Convert.ToSingle(brokenString[1]), System.Convert.ToSingle(brokenString[2]),
                                                     System.Convert.ToSingle(brokenString[3]));
                            v++;
                            break;

                        case "vt":
                            mesh.uv[vt] = new Vector2(System.Convert.ToSingle(brokenString[1]), System.Convert.ToSingle(brokenString[2]));
                            vt++;
                            break;

                        case "vt1":
                            mesh.uv[vt1] = new Vector2(System.Convert.ToSingle(brokenString[1]), System.Convert.ToSingle(brokenString[2]));
                            vt1++;
                            break;

                        case "vt2":
                            mesh.uv[vt2] = new Vector2(System.Convert.ToSingle(brokenString[1]), System.Convert.ToSingle(brokenString[2]));
                            vt2++;
                            break;

                        case "vn":
                            mesh.normals[vn] = new Vector3(System.Convert.ToSingle(brokenString[1]), System.Convert.ToSingle(brokenString[2]),
                                                    System.Convert.ToSingle(brokenString[3]));
                            vn++;
                            break;

                        case "vc":
                            break;

                        case "f":

                            int j = 1;
                            List<int> intArray = new List<int>();
                            while (j < brokenString.Length && ("" + brokenString[j]).Length > 0) {
                                Vector3 temp = new Vector3();
                                brokenBrokenString = brokenString[j].Split(splitIdentifier2, 3);    //Separate the face into individual components (vert, uv, normal)
                                temp.x = System.Convert.ToInt32(brokenBrokenString[0]);
                                if (brokenBrokenString.Length > 1)                                  //Some .obj files skip UV and normal
                                {
                                    if (brokenBrokenString[1] != "")                                    //Some .obj files skip the uv and not the normal
                                    {
                                        temp.y = System.Convert.ToInt32(brokenBrokenString[1]);
                                    }
                                    if (brokenBrokenString.Length > 2 && brokenBrokenString[2] != "") {
                                        temp.z = System.Convert.ToInt32(brokenBrokenString[2]);
                                    }
                                }
                                j++;

                                mesh.faceData[f2] = temp;
                                intArray.Add(f2);
                                f2++;
                            }
                            j = 1;
                            while (j + 2 < brokenString.Length)     //Create triangles out of the face data.  There will generally be more than 1 triangle per face.
                            {
                                mesh.triangles[f] = intArray[0];
                                f++;
                                mesh.triangles[f] = intArray[j];
                                f++;
                                mesh.triangles[f] = intArray[j + 1];
                                f++;

                                j++;
                            }
                            break;
                    }
                    currentText = reader.ReadLine();
                    if (currentText != null) {
                        currentText = currentText.Replace("  ", " ");       //Some .obj files insert double spaces, this removes them.
                    }
                }
            }
        }
    }
}

public static class ObjExporter {

    public static string MeshToString(Mesh m) {
        if (m == null) { return ""; }

        StringBuilder sb = new StringBuilder();

        sb.Append("g ").Append(m.name).Append("\n");
        foreach (Vector3 v in m.vertices) {
            sb.Append(string.Format("v {0} {1} {2}\n", v.x, v.y, v.z));
        }
        sb.Append("\n");
        foreach (Vector3 v in m.normals) {
            sb.Append(string.Format("vn {0} {1} {2}\n", v.x, v.y, v.z));
        }
        sb.Append("\n");
        foreach (Vector3 v in m.uv) {
            sb.Append(string.Format("vt {0} {1}\n", v.x, v.y));
        }
        return sb.ToString();
    }

    public static void Export(Mesh m, string filename) {
        using (StreamWriter sw = new StreamWriter(filename)) {
            sw.Write(MeshToString(m));
        }
    }
}