// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Grass Simple" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_Color2 ("Color2", Color) = (1,1,1,1)
		_MainTex ("MainTex", 2D) = "white" {}
		_Cutoff ("_Cutoff",Float) = 1.0
		_GrassScale ("Grass Scale",Float) = 10.0
		_GrassHeightScale ("Grass Height Scale",Float) = 10.0
		_GrassScale2 ("Grass Scale2",Float) = 10.0
		_GrassHeightScale2 ("Grass Height Scale2",Float) = 10.0
		_FallofDist ("FallofDist",Float) = 10.0
		_FallofStrength("Fallof Strength",Float) = 5
		_WindStrength("Wind Strength",Float) = 1.5
		_DensityBias("Density",Float) = 1
		_XTiles("X Tiles",Int) = 1
		_YTiles("Y Tiles",Int) = 1
	}
	SubShader {
		Pass {
		//Tags { "RenderType" = "Opaque" }
		Tags {"LightMode"="ForwardBase"}
		CGPROGRAM
		#include "UnityCG.cginc"
		#include "UnityLightingCommon.cginc" // for _LightColor0
		#pragma vertex vert
		#pragma fragment frag
		#pragma target 3.5

		struct data {
			float2 uv : TEXCOORD0;
			float4 pos : Position;
			//fixed4 splatColor  : TEXCOORD1;
			fixed4 grassColor  : TEXCOORD2;
			//float flipped : TEXCOORD3;
		};

		float4 _Color;
		float4 _Color2;
		float _GrassScale;
		float _GrassHeightScale;
		float _GrassScale2;
		float _GrassHeightScale2;
		float _FallofDist;
		float _FallofStrength;
		float _WindStrength;
		float _Cutoff;
		float _DensityBias;
		uint  _XTiles;
		uint  _YTiles;
		sampler2D _MainTex;
		
		data vert (float4 vertex : POSITION, float4 color:COLOR,float2 uv : TEXCOORD0,uint vid : SV_VertexID) {

			//grass id , 4 verts per bilboard
			uint id = vid/4;

			//calc offset
			float4 offset = vertex;

			//set wind
			float3 windOffset = float3(0,0,1);

			//set grassuv
			float2 grassuv = uv;

			//Set normal
			float4 normal = float4(0,0,0,0);

			//Set light
			float4 light = float4(0,0,0,1);
			
			//calc dist
			float4 worldPos = mul(unity_ObjectToWorld,offset);
			float dist = distance(worldPos,_WorldSpaceCameraPos);
			
			//check if too far away
			if( dist > _FallofDist ) {// || simpleScreenPos.x < -1 || simpleScreenPos.y < -1 || simpleScreenPos.x > 1 || simpleScreenPos.y > 1) {
				vertex = float4(0,0,0,0);
			} else {
				
				//calc fallof
				float falloff = clamp(dist*(1.0/_FallofDist),0,1);
				falloff = pow(falloff,_FallofStrength);
				
				//rasterize using faloff , more distance = les grass
				uint blockCount = 1+pow(3,floor(max(falloff,(1-_DensityBias))*4));
				uint blocku = floor(abs(offset.x)*127);
				uint blockv = floor(abs(offset.z)*127);
				
				//check if splatmap wants grass and check distance raster
				if( blockCount > 1+pow(3,4) || (blocku%blockCount)*(blockv%blockCount) > 0 ) {
					vertex = float4(0,0,0,0);
				} else {

					//randomize grass scale with noise
					float grassScale = lerp(_GrassScale,_GrassScale2,color.r);
					float grassHeightScale = lerp(_GrassHeightScale,_GrassHeightScale2,color.r);

					//randomize grass uv
					if(_XTiles > 1 || _YTiles > 1 ) {
						uint rndTile = uint(color.b*(_XTiles*_YTiles));
						float2 xyOffset = float2( (float(rndTile)%float(_XTiles))/float(_XTiles) , float(rndTile/_XTiles)/float(_YTiles) );
						float2 xyScale = float2(1.0/float(_XTiles),1.0/float(_YTiles));
						grassuv = float2( xyOffset.x + uv.x * xyScale.x , xyOffset.y + uv.y * xyScale.y );
					}

					//calc flat forw direction
					float3 forw  = ObjSpaceViewDir (offset);
					forw = normalize(forw);
					float shift = abs(forw.y);
					forw.y = 0;
					forw = normalize(forw);
					
					//calc up and right
					float3 up    = float3(0,1,0);
					float3 right = normalize(cross(forw,up));

					//calc normal
					normal = float4(-forw,0);

					//calc light
            		light = float4(ShadeSH9(half4(0,1,0,1)) * _LightColor0.rgb,1);

					//calc wind
					float clampedWindStrength = clamp(_WindStrength,0.2,1);
					float windSpeed = lerp(2,6,clampedWindStrength);
					float windMoveStrength = lerp(0,0.05*grassScale*grassHeightScale,clampedWindStrength);
					float windColorStrength = lerp(0.001,0.06,clampedWindStrength);
					windOffset = float3(sin((offset.z-offset.x+(color.r*15))+(_Time.x*33*windSpeed)) * windMoveStrength,sin((offset.z+offset.x+(color.b*15))+(_Time.x*40*windSpeed))  * windMoveStrength * 0.2,1);
					windOffset.z = 1+(windOffset.x*windColorStrength*(1/windMoveStrength));

					//offset the vertices
					if(vid%4==0) {
						vertex = offset-float4(right*0.5*grassScale,sin(_Time.y));//float4(forw,0);//WorldSpaceViewDir(float3(-2,0,0));
					}
					if(vid%4==1) {
						vertex = offset+float4(right*0.5*grassScale,0);//vertex.z += 0.3;
					}
					if(vid%4==2) {
						vertex = offset+float4(right*0.5*grassScale,0)+float4(up*grassScale*grassHeightScale,0);//vertex.z += 0.4;
						vertex.x += windOffset.x*grassScale;
						vertex.z += windOffset.y*grassScale;
						
						//lay down the more we look down vertical
						vertex -= float4(forw.x*shift*grassScale*grassHeightScale*0.5,0,forw.z*shift*grassScale*grassHeightScale*0.5,0);
					}
					if(vid%4==3) {
						vertex = offset-float4(right*0.5*grassScale,0)+float4(up*grassScale*grassHeightScale,0);//vertex.z += 0.5;
						vertex.x += windOffset.x*grassScale;
						vertex.z += windOffset.y*grassScale;

						//lay down the more we look down vertical
						vertex -= float4(forw.x*shift*grassScale*grassHeightScale*0.5,0,forw.z*shift*grassScale*grassHeightScale*0.5,0);
					}
					
				} 
			}

			//apply data
			data i;
			i.uv = grassuv;
			i.pos = UnityObjectToClipPos(vertex);
			i.grassColor = float4(lerp(_Color.rgb,_Color2.rgb,color.r)*windOffset.z,1) * light * float4(1.5,1.5,1.5,1);
			return i;
		}

		fixed4 frag (data i) : SV_Target {
			float4 color = tex2D (_MainTex, i.uv) * i.grassColor;
			if(color.a < _Cutoff) discard;
			return color;
		}
		ENDCG
		}
	}
}