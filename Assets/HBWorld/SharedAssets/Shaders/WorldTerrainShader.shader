// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Custom/WorldTerrain" {
	Properties {
		[HideInInspector] _Control ("Control (RGBA)", 2D) = "red" {}
		_Color ("overall color (RGBA)",Color) = (1,1,1,1)
		_Contrast("overall contrast",Range(0.5,2)) = 0
		_GrassContrast("overall grass contrast",Range(0.5,2)) = 0
		_Splat ("Splat (RGBA)", 2D) = "red" {}
		_ColorMap ("Color Map (RGB)", 2D) = "white" {}
		_NormalMap ("Bumpmap Map (RGB)", 2D) = "bump" {}
		_PerlinNoise ("Perlin Map (RGB) bump (A) texture break",2D) = "white" {}
		_GrasAlbedo  ("Grass albedo (RGB)", 2D) = "white" {}

		_MainTex1 ("Albedo 1 (RGBA) (GRAYSCALE,SPEC,SMOOTH,AO)", 2D) = "white" {}
		_BumpMap1 ("Bumpmap 1", 2D) = "bump" {}

		_MainTex2 ("Albedo 2 (RGBA) (GRAYSCALE,SPEC,SMOOTH,AO)", 2D) = "white" {}
		_BumpMap2 ("Bumpmap 2", 2D) = "bump" {}

		_MainTex3 ("Albedo 3 (RGBA) (GRAYSCALE,SPEC,SMOOTH,AO)", 2D) = "white" {}
		_BumpMap3 ("Bumpmap 3", 2D) = "bump" {}

		_MainTex4 ("Albedo 4 (RGBA) (GRAYSCALE,SPEC,SMOOTH,AO)", 2D) = "white" {}
		_BumpMap4 ("Bumpmap 4", 2D) = "bump" {}

		_NormalPower("Normal Power",Range(0,3)) = 1

		_Range1 ("Range 1", Range(0,10000)) = 300
		_Range2 ("Range 2", Range(0,10000)) = 3000

		_Strength1 ("Blend Strength 1", Range(1,1000)) = 1
		_Strength2 ("Blend Strength 2", Range(1,1000)) = 1
		
		_Range1Max ("Range 1 Max", Range(0,1)) = 1
		_Range2Max ("Range 2 Max", Range(0,1)) = 1

		_UVScale ("UV Scale", Range(0.01,1)) = 1
		_PerlinUVScale ("Perlin UV Scale", Range(0.01,1)) = 1
		_TextureBreak_UVScale ("Texture Break UV Scale", Range(0.01,10)) = 0.1
		_TextureBreak_blend_offset ("Texture Break blend offset", Range(0,1)) = 0.1
		_TextureBreak_blend_Strength ("Texture Break bland strength", Range(0,10)) = 0.1

		_GrassColor ("Grass Color", Color) = (1,1,1,1)
		_GrassStrength ("Grass Strength", Range(0,20)) = 10
		_GrassFill ("Grass Fill", Range(-1,1)) = 0
		_GrassDistort ("Grass Distort", Range(0,5)) = 1

		_PerlinStrength1 ("PerlinStrength1", Range(0,3)) = 1
		_PerlinStrength2 ("PerlinStrength2", Range(0,3)) = 1
		_PerlinStrength3 ("PerlinStrength3", Range(0,3)) = 1
		_PerlinStrength4 ("PerlinStrength4", Range(0,3)) = 0.1

		_colorPerlinStrength ("PerlinStrength colormap", Range(0,0.005)) = 1

		_Debug ("Debug blend ranges",Range(0,1)) = 0
		_DebugTerrSplat("Debug terrain splat",Range(0,1)) = 0
		_DebugTerrSplatArtifact("Debug terrain splat artifact",Range(0,1)) = 0
		_DebugTextureBreak("Debug texture break",Range(0,1)) = 0

		_DebugGrass("Debug grass",Range(0,1)) = 0

		//_wetness ("wetness", Range(0,1)) = 1

		// Used in fallback on old cards & also for distant base map
    [HideInInspector] _MainTex ("BaseMap (RGB)", 2D) = "white" {}
    [HideInInspector] _Color ("Main Color", Color) = (1,1,1,1)
		
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
		
		uniform sampler2D _Control;
		uniform sampler2D _Splat;
		sampler2D _ColorMap;
		sampler2D _NormalMap;
		sampler2D _PerlinNoise;
		sampler2D _GrasAlbedo;

		sampler2D _MainTex1;
		sampler2D _BumpMap1;
		
		sampler2D _MainTex2;
		sampler2D _BumpMap2;
		
		sampler2D _MainTex3;
		sampler2D _BumpMap3;
		
		sampler2D _MainTex4;
		sampler2D _BumpMap4;
		
		struct Input {
			float2 uv_MainTex;
			float3 worldPos;
			float4 screenPos;
			float distance;
			float2 uv_Control : TEXCOORD0;
		};

    void vert (inout appdata_full v, out Input o) {
    		UNITY_INITIALIZE_OUTPUT(Input,o);
        o.distance = distance(_WorldSpaceCameraPos, mul(unity_ObjectToWorld, v.vertex));
    }


		float _NormalPower;
		float _Range1;
		float _Range2;
		float _Strength1;
		float _Strength2;
		float _Range1Max;
		float _Range2Max;
		float _Debug;
		float _DebugTerrSplat;
		float _DebugTerrSplatArtifact;
		float _DebugTextureBreak;
		float _DebugGrass;
		float _UVScale;
		float _PerlinUVScale;
		float4 _GrassColor;
		float _GrassStrength;
		float _GrassFill;
		float _GrassDistort;
		float _TextureBreak_UVScale;
		float _PerlinStrength1;
		float _PerlinStrength2;
		float _PerlinStrength3;
		float _PerlinStrength4;
		float _colorPerlinStrength;
		float _wetness;
		float _TextureBreak_blend_Strength;
		float _TextureBreak_blend_offset;
		float4 _Color;
		float _Contrast;
		float _GrassContrast;

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_CBUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_CBUFFER_END
		
		void surf (Input IN, inout SurfaceOutputStandardSpecular o) {
			float dist = IN.distance;
			float range1 = clamp( ((_Range1-dist) / _Range1) * _Strength1,0,_Range1Max);
			float range2 = clamp( ((_Range2-dist) / _Range2) * _Strength2,0,_Range2Max);

			float2 uv1 = float2(IN.worldPos.x,IN.worldPos.z) * _UVScale;
			float2 uv2 = float2(IN.worldPos.x,IN.worldPos.z) * 0.15 * _UVScale;
			float2 uv3 = float2(IN.worldPos.x,IN.worldPos.z) * 0.03 * _UVScale;

			float2 uv1_rotated = float2(IN.worldPos.z+0.5,IN.worldPos.x+0.5) * _UVScale * 0.777;
			float2 uv2_rotated = float2(IN.worldPos.z+0.5,IN.worldPos.x+0.5) * 0.15 * _UVScale * 0.777;
			float2 uv3_rotated = float2(IN.worldPos.z+0.5,IN.worldPos.x+0.5) * 0.03 * _UVScale * 0.777;

			float4 perlin = tex2D (_PerlinNoise,uv3 * _TextureBreak_UVScale );
			float perlinbreak = clamp((perlin.x - _TextureBreak_blend_offset)*_TextureBreak_blend_Strength,0,1);

			float2 breakupUVOffset = (float2(-0.5,-0.5) + float2(perlin.x,perlin.y)) * _colorPerlinStrength;

			float4 color =  tex2D (_ColorMap,IN.uv_Control+breakupUVOffset);
			fixed4 splat_control = tex2D (_Splat, IN.uv_Control);
			fixed3 normal_control = UnpackNormal(tex2D(_NormalMap,IN.uv_Control)) * _NormalPower;
			float artifact = 1 - (splat_control.r+splat_control.g+splat_control.b+splat_control.a);

			float grass = clamp((tex2D (_Splat, IN.uv_Control+breakupUVOffset * _GrassDistort).a - (0.5-_GrassFill)) * _GrassStrength ,0 ,1 );
			
			float4 splatnograss = splat_control;
			splatnograss.a = 0;
			splatnograss.b = 1 - ( splatnograss.g + splatnograss.r );

			splat_control = lerp( splatnograss , float4(0,0,0,1) , grass);

			//color = lerp( color , lerp(_GrassColor,lerp(tex2D(_GrasAlbedo,uv1),tex2D(_GrasAlbedo,uv1_rotated),perlinbreak) , range1) , grass);
			//color = lerp( color , saturate(lerp(half4(0.5, 0.5, 0.5,0.5),     lerp(_GrassColor,lerp(tex2D(_GrasAlbedo,uv1),tex2D(_GrasAlbedo,uv1_rotated),perlinbreak) , range1)  , _GrassContrast)) , grass);
			color = lerp( color ,  lerp(lerp(tex2D(_GrasAlbedo,uv1),tex2D(_GrasAlbedo,uv1_rotated),perlinbreak),_GrassColor,_GrassContrast) , grass);

			float4 albedo_uv1 = (tex2D (_MainTex4,uv1 ) * splat_control.a ) + (tex2D (_MainTex3,uv1 ) * splat_control.b ) + ( tex2D (_MainTex2,uv1 ) * splat_control.g ) + ( tex2D (_MainTex1,uv1 ) * splat_control.r);
			float4 albedo_uv2 = (tex2D (_MainTex4,uv2 ) * splat_control.a ) + (tex2D (_MainTex3,uv2 ) * splat_control.b ) + ( tex2D (_MainTex2,uv2 ) * splat_control.g ) + ( tex2D (_MainTex1,uv2 ) * splat_control.r);
			float4 albedo_uv3 = (tex2D (_MainTex4,uv3 ) * splat_control.a ) + (tex2D (_MainTex3,uv3 ) * splat_control.b ) + ( tex2D (_MainTex2,uv3 ) * splat_control.g ) + ( tex2D (_MainTex1,uv3 ) * splat_control.r);

			float4 normal_uv1 = (tex2D (_BumpMap4,uv1 ) * splat_control.a ) + (tex2D (_BumpMap3,uv1 ) * splat_control.b ) + ( tex2D (_BumpMap2,uv1 ) * splat_control.g ) + ( tex2D (_BumpMap1,uv1 ) * splat_control.r);
			float4 normal_uv2 = (tex2D (_BumpMap4,uv2 ) * splat_control.a ) + (tex2D (_BumpMap3,uv2 ) * splat_control.b ) + ( tex2D (_BumpMap2,uv2 ) * splat_control.g ) + ( tex2D (_BumpMap1,uv2 ) * splat_control.r);
			float4 normal_uv3 = (tex2D (_BumpMap4,uv3 ) * splat_control.a ) + (tex2D (_BumpMap3,uv3 ) * splat_control.b ) + ( tex2D (_BumpMap2,uv3 ) * splat_control.g ) + ( tex2D (_BumpMap1,uv3 ) * splat_control.r);

			float4 albedo_uv1_rotated = (tex2D (_MainTex4,uv1_rotated ) * splat_control.a ) + (tex2D (_MainTex3,uv1_rotated ) * splat_control.b ) + ( tex2D (_MainTex2,uv1_rotated ) * splat_control.g ) + ( tex2D (_MainTex1,uv1_rotated ) * splat_control.r);
			float4 albedo_uv2_rotated = (tex2D (_MainTex4,uv2_rotated ) * splat_control.a ) + (tex2D (_MainTex3,uv2_rotated ) * splat_control.b ) + ( tex2D (_MainTex2,uv2_rotated ) * splat_control.g ) + ( tex2D (_MainTex1,uv2_rotated ) * splat_control.r);
			float4 albedo_uv3_rotated = (tex2D (_MainTex4,uv3_rotated ) * splat_control.a ) + (tex2D (_MainTex3,uv3_rotated ) * splat_control.b ) + ( tex2D (_MainTex2,uv3_rotated ) * splat_control.g ) + ( tex2D (_MainTex1,uv3_rotated ) * splat_control.r);

			float4 normal_uv1_rotated = (tex2D (_BumpMap4,uv1_rotated ) * splat_control.a ) + (tex2D (_BumpMap3,uv1_rotated ) * splat_control.b ) + ( tex2D (_BumpMap2,uv1_rotated ) * splat_control.g ) + ( tex2D (_BumpMap1,uv1_rotated ) * splat_control.r);
			float4 normal_uv2_rotated = (tex2D (_BumpMap4,uv2_rotated ) * splat_control.a ) + (tex2D (_BumpMap3,uv2_rotated ) * splat_control.b ) + ( tex2D (_BumpMap2,uv2_rotated ) * splat_control.g ) + ( tex2D (_BumpMap1,uv2_rotated ) * splat_control.r);
			float4 normal_uv3_rotated = (tex2D (_BumpMap4,uv3_rotated ) * splat_control.a ) + (tex2D (_BumpMap3,uv3_rotated ) * splat_control.b ) + ( tex2D (_BumpMap2,uv3_rotated ) * splat_control.g ) + ( tex2D (_BumpMap1,uv3_rotated ) * splat_control.r);

			float4 albedo_f_regular = lerp( albedo_uv3 , lerp( albedo_uv2 , albedo_uv1 , range1 ) , range2);
			float3 normal_f_regular = UnpackNormal ( lerp( normal_uv3 , lerp( normal_uv2 , normal_uv1 , range1 ) , range2) );
			
			float4 albedo_f_rotated = lerp( albedo_uv3_rotated , lerp( albedo_uv2_rotated , albedo_uv1_rotated , range1 ) , range2);
			float3 normal_f_rotated = UnpackNormal ( lerp( normal_uv3_rotated , lerp( normal_uv2_rotated , normal_uv1_rotated , range1 ) , range2) );

			float4 albedo_f = lerp(albedo_f_regular,albedo_f_rotated,perlinbreak);
			float3 normal_f = lerp(normal_f_regular,normal_f_rotated,perlinbreak);

			float3 normal_perlin = UnpackNormal(tex2D(_PerlinNoise,uv2*_PerlinUVScale)) * ((splat_control.r * _PerlinStrength1)+(splat_control.g * _PerlinStrength2)+(splat_control.b * _PerlinStrength3)+(splat_control.a * _PerlinStrength4)) ;


			o.Albedo = saturate(lerp(half3(0.5, 0.5, 0.5), albedo_f.r * (color) * _Color, _Contrast));
			o.Normal = normalize(lerp(normal_control+normal_perlin,normalize(normal_f+normal_control+normal_perlin),range2));
			o.Specular = albedo_f.g * (_wetness*1.2);
			o.Smoothness = -0.2 + albedo_f.b + (_wetness*0.7);
			o.Emission =  (float4(range1,range2,0,1) * _Debug) + (splat_control * _DebugTerrSplat) + (float4(artifact,0,artifact,1) * _DebugTerrSplatArtifact) + ( perlinbreak * _DebugTextureBreak) + (_GrassColor * grass * _DebugGrass);
			o.Occlusion = albedo_f.a;
			o.Alpha = 1;
		}
		ENDCG
	}
	//Dependency "AddPassShader" = "Custom/WorldTerrain"
	Dependency "BaseMapShader" = "Custom/WorldTerrain"//  Diffuse"//"Custom/WorldTerrainAddPass"

	FallBack "Diffuse"
}