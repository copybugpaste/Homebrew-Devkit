// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "homebrew/wind_flag_water"
{
	Properties
	{
		_scale("scale", Float) = 0
		_time("time", Float) = 0
		_Float0("Float 0", Float) = 0
		_diiffuse("diiffuse", 2D) = "white" {}
		_specular("specular", 2D) = "white" {}
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" }
		Cull Off
		ColorMask RGB
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf StandardSpecular keepalpha addshadow fullforwardshadows vertex:vertexDataFunc 
		struct Input
		{
			float3 worldPos;
			half2 uv_texcoord;
		};

		uniform half _time;
		uniform half _scale;
		uniform half _Float0;
		uniform sampler2D _diiffuse;
		uniform float4 _diiffuse_ST;
		uniform sampler2D _specular;
		uniform float4 _specular_ST;

		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			float mulTime1 = _Time.y * _time;
			float3 ase_worldPos = mul( unity_ObjectToWorld, v.vertex );
			v.vertex.xyz += ( ( ( (0.0 + (( sin( ( mulTime1 + ( ase_worldPos.y * _scale ) ) ) * 1.0 ) - -1.0) * (1.0 - 0.0) / (1.0 - -1.0)) * _Float0 ) * v.color.r ) * half3(0,0,1) );
		}

		void surf( Input i , inout SurfaceOutputStandardSpecular o )
		{
			float2 uv_diiffuse = i.uv_texcoord * _diiffuse_ST.xy + _diiffuse_ST.zw;
			o.Albedo = tex2D( _diiffuse, uv_diiffuse ).rgb;
			float2 uv_specular = i.uv_texcoord * _specular_ST.xy + _specular_ST.zw;
			half4 tex2DNode21 = tex2D( _specular, uv_specular );
			o.Specular = tex2DNode21.rgb;
			o.Smoothness = tex2DNode21.a;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
}
/*ASEBEGIN
Version=15401
1143;116;1813;934;2312.292;16.39044;1.3;True;False
Node;AmplifyShaderEditor.WorldPosInputsNode;3;-1696.52,679.4005;Float;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.RangedFloatNode;24;-1608.99,888.4092;Float;False;Property;_scale;scale;0;0;Create;True;0;0;False;0;0;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;22;-1898.071,504.7215;Float;False;Property;_time;time;1;0;Create;True;0;0;False;0;0;2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleTimeNode;1;-1660.794,554.1354;Float;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;23;-1397.093,848.1095;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;4;-1416.514,630.7004;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;17;-1541.527,470.0792;Float;False;Constant;_Float1;Float 1;0;0;Create;True;0;0;False;0;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SinOpNode;5;-1394.714,361.9002;Float;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;16;-1284.907,443.6034;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TFHCRemapNode;6;-1196.916,617.8002;Float;False;5;0;FLOAT;0;False;1;FLOAT;-1;False;2;FLOAT;1;False;3;FLOAT;0;False;4;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;15;-1078.626,415.4471;Float;False;Property;_Float0;Float 0;2;0;Create;True;0;0;False;0;0;-0.11;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;7;-1009.917,614.5004;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ComponentMaskNode;9;-882.2535,620.4443;Float;False;True;True;True;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.VertexColorNode;19;-1048.845,915.153;Float;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;10;-632.2535,625.4443;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector3Node;13;-593.4584,878.2274;Float;False;Constant;_Vector0;Vector 0;0;0;Create;True;0;0;False;0;0,0,1;0,0,0;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.SamplerNode;20;-904.0053,-297.5415;Float;True;Property;_diiffuse;diiffuse;3;0;Create;True;0;0;False;0;None;551cedff88658ca47a1a2ee60c9a5e26;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;11;-463.9683,628.1647;Float;False;2;2;0;FLOAT;0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SamplerNode;21;-813.2889,39.40466;Float;True;Property;_specular;specular;4;0;Create;True;0;0;False;0;None;77dc0f719c6261d43855f853307964d7;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;0,0;Half;False;True;2;Half;;0;0;StandardSpecular;homebrew/wind_flag_water;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Off;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;False;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;-1;False;-1;-1;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;1;0;22;0
WireConnection;23;0;3;2
WireConnection;23;1;24;0
WireConnection;4;0;1;0
WireConnection;4;1;23;0
WireConnection;5;0;4;0
WireConnection;16;0;5;0
WireConnection;16;1;17;0
WireConnection;6;0;16;0
WireConnection;7;0;6;0
WireConnection;7;1;15;0
WireConnection;9;0;7;0
WireConnection;10;0;9;0
WireConnection;10;1;19;1
WireConnection;11;0;10;0
WireConnection;11;1;13;0
WireConnection;0;0;20;0
WireConnection;0;3;21;0
WireConnection;0;4;21;4
WireConnection;0;11;11;0
ASEEND*/
//CHKSM=DDC3BDF1A71A050F2564F22E1ADC5EEC3FD6E46D