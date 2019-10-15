Shader "Custom/TriplanerCubic" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Main Albedo (RGB)", 2D) = "white" {}
		_MainDetailTex ("Main Detail (GBA) (Spec,Smoothenss,AO)", 2D) = "white" {}
		_MainNormalTex ("Main Normal", 2D) = "bump" {}
		_SecondaryTex ("Secondary Albedo (RGB)", 2D) = "white" {}
		_SecondaryDetailTex ("Secondary Detail (GBA) (Spec,Smoothenss,AO)", 2D) = "white" {}
		_SecondaryNormalTex ("Main Normal", 2D) = "bump" {}
		_UVScale ("UVScale",Range(0.01,1)) = 1
	}
	SubShader {
		Tags {
        "SplatCount" = "4"
        "Queue" = "Geometry-100"
        "RenderType" = "Opaque"
    }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf StandardSpecular fullforwardshadows vertex:vert

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _MainDetailTex;
		sampler2D _MainNormalTex;
		sampler2D _SecondaryTex;
		sampler2D _SecondaryDetailTex;
		sampler2D _SecondaryNormalTex;		

		struct Input {
			float2 uv_MainTex;
			float3 worldPos;
			float3 vertexNormal;
		};

		// Transfer the vertex normal to the Input structure
    void vert (inout appdata_full v, out Input o) {
      UNITY_INITIALIZE_OUTPUT(Input,o);
      o.vertexNormal = abs(v.normal);
    }


		float _UVScale;
		fixed4 _Color;

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_CBUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_CBUFFER_END
		void surf (Input IN, inout SurfaceOutputStandardSpecular o) {
			// Albedo comes from a texture tinted by color

			float2 uv1 = float2(IN.worldPos.x,IN.worldPos.z) * _UVScale;
			float2 uv2 = float2(IN.worldPos.y,IN.worldPos.z) * _UVScale;
			float2 uv3 = float2(IN.worldPos.y,IN.worldPos.x) * _UVScale;
			
			float3 normal = IN.vertexNormal;
			normal = normal * normal ;
			normal = abs(normal);
			normal.y = normal.y * 1.5;
			normal = normalize(normal);
			

			fixed4 detail_f = (tex2D (_SecondaryDetailTex, uv2).rgba * normal.x) + ( tex2D (_SecondaryDetailTex, uv1).rgba * normal.y ) + ( tex2D (_SecondaryDetailTex, uv3).rgba * normal.z );
			fixed3 color_f  = (tex2D (_SecondaryTex, uv2).rgb * normal.x) + ( tex2D (_SecondaryTex, uv1).rgb * normal.y ) + ( tex2D (_SecondaryTex, uv3).rgb * normal.z );

			fixed4 detail_f2 = (tex2D (_MainDetailTex, uv2).rgba * normal.x) + ( tex2D (_MainDetailTex, uv1).rgba * normal.y ) + ( tex2D (_MainDetailTex, uv3).rgba * normal.z );
			fixed3 color_f2  = (tex2D (_MainTex, uv2).rgb * normal.x) + ( tex2D (_MainTex, uv1).rgb * normal.y ) + ( tex2D (_MainTex, uv3).rgb * normal.z );

			float blend = clamp((detail_f.a-0.75) * 5 ,0,1);

			fixed4 detail_f3 = lerp( detail_f2 , detail_f , blend);
			fixed3 color_f3  = lerp( color_f2 , color_f , blend);

			fixed4 normal_f = (tex2D (_SecondaryNormalTex, uv2).rgba * normal.x) + ( tex2D (_MainNormalTex, uv1).rgba * normal.y ) + ( tex2D (_SecondaryNormalTex, uv3).rgba * normal.z );
			normal_f = normalize(normal_f);
			

			o.Albedo = color_f3 * _Color;
			o.Normal = UnpackNormal(normal_f);
			o.Specular = 0;//detail_f.g;
			o.Smoothness = detail_f3.b;
			o.Occlusion = detail_f3.a;
			o.Alpha = 1;
			//o.Emission = blend;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
