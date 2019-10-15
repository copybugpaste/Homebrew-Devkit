// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:3,spmd:0,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:True,rprd:True,enco:False,rmgx:True,imps:True,rpth:1,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:32719,y:32712,varname:node_2865,prsc:2|diff-5240-OUT,spec-4904-RGB,gloss-4904-A,normal-983-OUT,difocc-6345-OUT;n:type:ShaderForge.SFN_Tex2d,id:7072,x:31232,y:32110,cmnt:Rock Far UV,varname:node_7072,prsc:2,ntxv:0,isnm:False|UVIN-7049-OUT,TEX-7112-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:7112,x:30549,y:32047,ptovrint:False,ptlb:Rock D,ptin:_RockD,varname:node_7112,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:7976,x:31239,y:32279,cmnt:Rock Far UV,varname:node_7976,prsc:2,ntxv:0,isnm:False|UVIN-351-OUT,TEX-367-TEX;n:type:ShaderForge.SFN_ChannelBlend,id:5084,x:31677,y:32338,cmnt:Dif_Triplaner Blend,varname:node_5084,prsc:2,chbt:0|M-837-OUT,R-7072-RGB,G-7976-RGB,B-9183-RGB;n:type:ShaderForge.SFN_Abs,id:837,x:31246,y:32588,varname:node_837,prsc:2|IN-1252-OUT;n:type:ShaderForge.SFN_NormalVector,id:9838,x:30910,y:32492,prsc:2,pt:False;n:type:ShaderForge.SFN_Append,id:7049,x:30555,y:32428,cmnt:YZ projection,varname:node_7049,prsc:2|A-5493-Y,B-5493-Z;n:type:ShaderForge.SFN_FragmentPosition,id:5493,x:30309,y:32552,varname:node_5493,prsc:2;n:type:ShaderForge.SFN_Append,id:7244,x:30550,y:32708,cmnt:Xy projection,varname:node_7244,prsc:2|A-5493-X,B-5493-Y;n:type:ShaderForge.SFN_Append,id:351,x:30548,y:32573,cmnt:ZX projection,varname:node_351,prsc:2|A-5493-Z,B-5493-X;n:type:ShaderForge.SFN_Color,id:4904,x:32466,y:32668,ptovrint:False,ptlb:Specular Gloss(A),ptin:_SpecularGlossA,varname:node_4904,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Tex2d,id:4498,x:31199,y:32892,varname:node_4498,prsc:2,ntxv:0,isnm:False|UVIN-7049-OUT,TEX-6672-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:6672,x:30553,y:32885,ptovrint:False,ptlb:ROCK N,ptin:_ROCKN,varname:node_6672,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:2481,x:31200,y:33013,varname:node_2481,prsc:2,ntxv:0,isnm:False|UVIN-351-OUT,TEX-6185-TEX;n:type:ShaderForge.SFN_Tex2d,id:4551,x:31204,y:33148,varname:node_4551,prsc:2,ntxv:0,isnm:False|UVIN-7244-OUT,TEX-6672-TEX;n:type:ShaderForge.SFN_ChannelBlend,id:2849,x:31639,y:32914,cmnt:Norm Triplaner,varname:node_2849,prsc:2,chbt:0|M-837-OUT,R-4498-RGB,G-2481-RGB,B-4551-RGB;n:type:ShaderForge.SFN_Tex2d,id:9183,x:31241,y:32427,cmnt:Rock Far UV,varname:node_9183,prsc:2,ntxv:0,isnm:False|UVIN-7244-OUT,TEX-7112-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:367,x:30542,y:32242,ptovrint:False,ptlb:Moss D,ptin:_MossD,varname:node_367,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2dAsset,id:6185,x:30559,y:33085,ptovrint:False,ptlb:MOSS N,ptin:_MOSSN,varname:node_6185,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:9258,x:31232,y:31598,cmnt:Rock Close UV,varname:node_9258,prsc:2,ntxv:0,isnm:False|UVIN-2677-OUT,TEX-7112-TEX;n:type:ShaderForge.SFN_Tex2d,id:1016,x:31234,y:31753,cmnt:Rock Close UV,varname:node_1016,prsc:2,ntxv:0,isnm:False|UVIN-8928-OUT,TEX-367-TEX;n:type:ShaderForge.SFN_Tex2d,id:6842,x:31238,y:31938,cmnt:Rock Close UV,varname:node_6842,prsc:2,ntxv:0,isnm:False|UVIN-7015-OUT,TEX-7112-TEX;n:type:ShaderForge.SFN_Multiply,id:2677,x:30910,y:31602,varname:node_2677,prsc:2|A-7049-OUT,B-2030-OUT;n:type:ShaderForge.SFN_Multiply,id:8928,x:30910,y:31740,varname:node_8928,prsc:2|A-351-OUT,B-2030-OUT;n:type:ShaderForge.SFN_Multiply,id:7015,x:30930,y:31922,varname:node_7015,prsc:2|A-7244-OUT,B-2030-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2030,x:29668,y:32580,ptovrint:False,ptlb:Scale UV close,ptin:_ScaleUVclose,varname:node_2030,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_ChannelBlend,id:2313,x:31681,y:31936,varname:node_2313,prsc:2,chbt:0|M-837-OUT,R-9258-RGB,G-1016-RGB,B-6842-RGB;n:type:ShaderForge.SFN_Lerp,id:4017,x:32309,y:32412,varname:node_4017,prsc:2|A-2313-OUT,B-5084-OUT,T-3798-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:2681,x:31568,y:32536,varname:node_2681,prsc:2;n:type:ShaderForge.SFN_ViewPosition,id:3406,x:31569,y:32696,varname:node_3406,prsc:2;n:type:ShaderForge.SFN_Distance,id:8465,x:31738,y:32557,varname:node_8465,prsc:2|A-2681-XYZ,B-3406-XYZ;n:type:ShaderForge.SFN_Divide,id:549,x:31890,y:32558,varname:node_549,prsc:2|A-8465-OUT,B-6557-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6557,x:31723,y:32730,ptovrint:False,ptlb:DistanceBlend,ptin:_DistanceBlend,varname:node_6557,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:4.5;n:type:ShaderForge.SFN_Power,id:744,x:32047,y:32557,varname:node_744,prsc:2|VAL-549-OUT,EXP-8529-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8529,x:31723,y:32806,ptovrint:False,ptlb:FalloFf Blend,ptin:_FalloFfBlend,varname:node_8529,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:500;n:type:ShaderForge.SFN_Clamp01,id:3798,x:32186,y:32555,varname:node_3798,prsc:2|IN-744-OUT;n:type:ShaderForge.SFN_Tex2d,id:5611,x:31213,y:33341,varname:node_5611,prsc:2,ntxv:0,isnm:False|UVIN-6578-OUT,TEX-6672-TEX;n:type:ShaderForge.SFN_Tex2d,id:2179,x:31202,y:33461,varname:node_2179,prsc:2,ntxv:0,isnm:False|UVIN-4657-OUT,TEX-6185-TEX;n:type:ShaderForge.SFN_Tex2d,id:6961,x:31195,y:33576,varname:node_6961,prsc:2,ntxv:0,isnm:False|UVIN-584-OUT,TEX-6672-TEX;n:type:ShaderForge.SFN_Multiply,id:6578,x:30993,y:33315,varname:node_6578,prsc:2|A-7049-OUT,B-2030-OUT;n:type:ShaderForge.SFN_Multiply,id:4657,x:30988,y:33435,varname:node_4657,prsc:2|A-351-OUT,B-2030-OUT;n:type:ShaderForge.SFN_Multiply,id:584,x:30988,y:33563,varname:node_584,prsc:2|A-7244-OUT,B-2030-OUT;n:type:ShaderForge.SFN_ChannelBlend,id:8591,x:31616,y:33379,varname:node_8591,prsc:2,chbt:0|M-837-OUT,R-5611-RGB,G-2179-RGB,B-6961-RGB;n:type:ShaderForge.SFN_Lerp,id:983,x:32229,y:32994,varname:node_983,prsc:2|A-8591-OUT,B-2849-OUT,T-3798-OUT;n:type:ShaderForge.SFN_NormalVector,id:4002,x:30893,y:32658,prsc:2,pt:False;n:type:ShaderForge.SFN_ValueProperty,id:6847,x:30899,y:32817,ptovrint:False,ptlb:blend value,ptin:_blendvalue,varname:node_6847,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:7232,x:31162,y:32730,varname:node_7232,prsc:2|A-4002-OUT,B-6847-OUT;n:type:ShaderForge.SFN_Blend,id:1252,x:31087,y:32528,varname:node_1252,prsc:2,blmd:10,clmp:True|SRC-9838-OUT,DST-9590-OUT;n:type:ShaderForge.SFN_Abs,id:9590,x:31281,y:32730,varname:node_9590,prsc:2|IN-7232-OUT;n:type:ShaderForge.SFN_Color,id:8456,x:32320,y:32220,ptovrint:False,ptlb:DIff Color,ptin:_DIffColor,varname:node_8456,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Blend,id:5240,x:32532,y:32367,varname:node_5240,prsc:2,blmd:10,clmp:False|SRC-8456-RGB,DST-4017-OUT;n:type:ShaderForge.SFN_ChannelBlend,id:4716,x:31690,y:32129,varname:node_4716,prsc:2,chbt:0|M-837-OUT,R-9258-A,G-1016-A,B-7072-A;n:type:ShaderForge.SFN_ValueProperty,id:4765,x:31965,y:32879,ptovrint:False,ptlb:AO BLEND,ptin:_AOBLEND,varname:node_4765,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Blend,id:6345,x:32171,y:32830,varname:node_6345,prsc:2,blmd:10,clmp:False|SRC-4716-OUT,DST-4765-OUT;proporder:7112-4904-6672-367-6185-2030-6557-8529-6847-8456-4765;pass:END;sub:END;*/

Shader "Shader Forge/RockMoss" {
    Properties {
        _RockD ("Rock D", 2D) = "white" {}
        _SpecularGlossA ("Specular Gloss(A)", Color) = (0.5,0.5,0.5,1)
        _ROCKN ("ROCK N", 2D) = "bump" {}
        _MossD ("Moss D", 2D) = "white" {}
        _MOSSN ("MOSS N", 2D) = "bump" {}
        _ScaleUVclose ("Scale UV close", Float ) = 0
        _DistanceBlend ("DistanceBlend", Float ) = 4.5
        _FalloFfBlend ("FalloFf Blend", Float ) = 500
        _blendvalue ("blend value", Float ) = 1
        _DIffColor ("DIff Color", Color) = (0.5,0.5,0.5,1)
        _AOBLEND ("AO BLEND", Float ) = 1
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        LOD 200
        Pass {
            Name "DEFERRED"
            Tags {
                "LightMode"="Deferred"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_DEFERRED
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile ___ UNITY_HDR_ON
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles n3ds wiiu 
            #pragma target 3.0
            uniform sampler2D _RockD; uniform float4 _RockD_ST;
            uniform float4 _SpecularGlossA;
            uniform sampler2D _ROCKN; uniform float4 _ROCKN_ST;
            uniform sampler2D _MossD; uniform float4 _MossD_ST;
            uniform sampler2D _MOSSN; uniform float4 _MOSSN_ST;
            uniform float _ScaleUVclose;
            uniform float _DistanceBlend;
            uniform float _FalloFfBlend;
            uniform float _blendvalue;
            uniform float4 _DIffColor;
            uniform float _AOBLEND;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv1 : TEXCOORD0;
                float2 uv2 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
                float3 normalDir : TEXCOORD3;
                float3 tangentDir : TEXCOORD4;
                float3 bitangentDir : TEXCOORD5;
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD6;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                #ifdef LIGHTMAP_ON
                    o.ambientOrLightmapUV.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
                    o.ambientOrLightmapUV.zw = 0;
                #endif
                #ifdef DYNAMICLIGHTMAP_ON
                    o.ambientOrLightmapUV.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
                #endif
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            void frag(
                VertexOutput i,
                out half4 outDiffuse : SV_Target0,
                out half4 outSpecSmoothness : SV_Target1,
                out half4 outNormal : SV_Target2,
                out half4 outEmission : SV_Target3 )
            {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 node_837 = abs(saturate(( abs((i.normalDir*_blendvalue)) > 0.5 ? (1.0-(1.0-2.0*(abs((i.normalDir*_blendvalue))-0.5))*(1.0-i.normalDir)) : (2.0*abs((i.normalDir*_blendvalue))*i.normalDir) )));
                float2 node_7049 = float2(i.posWorld.g,i.posWorld.b); // YZ projection
                float2 node_6578 = (node_7049*_ScaleUVclose);
                float3 node_5611 = UnpackNormal(tex2D(_ROCKN,TRANSFORM_TEX(node_6578, _ROCKN)));
                float2 node_351 = float2(i.posWorld.b,i.posWorld.r); // ZX projection
                float2 node_4657 = (node_351*_ScaleUVclose);
                float3 node_2179 = UnpackNormal(tex2D(_MOSSN,TRANSFORM_TEX(node_4657, _MOSSN)));
                float2 node_7244 = float2(i.posWorld.r,i.posWorld.g); // Xy projection
                float2 node_584 = (node_7244*_ScaleUVclose);
                float3 node_6961 = UnpackNormal(tex2D(_ROCKN,TRANSFORM_TEX(node_584, _ROCKN)));
                float3 node_4498 = UnpackNormal(tex2D(_ROCKN,TRANSFORM_TEX(node_7049, _ROCKN)));
                float3 node_2481 = UnpackNormal(tex2D(_MOSSN,TRANSFORM_TEX(node_351, _MOSSN)));
                float3 node_4551 = UnpackNormal(tex2D(_ROCKN,TRANSFORM_TEX(node_7244, _ROCKN)));
                float node_3798 = saturate(pow((distance(i.posWorld.rgb,_WorldSpaceCameraPos)/_DistanceBlend),_FalloFfBlend));
                float3 normalLocal = lerp((node_837.r*node_5611.rgb + node_837.g*node_2179.rgb + node_837.b*node_6961.rgb),(node_837.r*node_4498.rgb + node_837.g*node_2481.rgb + node_837.b*node_4551.rgb),node_3798);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
////// Lighting:
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = _SpecularGlossA.a;
                float perceptualRoughness = 1.0 - _SpecularGlossA.a;
                float roughness = perceptualRoughness * perceptualRoughness;
/////// GI Data:
                UnityLight light; // Dummy light
                light.color = 0;
                light.dir = half3(0,1,0);
                light.ndotl = max(0,dot(normalDirection,light.dir));
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = 1;
                #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
                    d.ambient = 0;
                    d.lightmapUV = i.ambientOrLightmapUV;
                #else
                    d.ambient = i.ambientOrLightmapUV;
                #endif
                #if UNITY_SPECCUBE_BLENDING || UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMin[0] = unity_SpecCube0_BoxMin;
                    d.boxMin[1] = unity_SpecCube1_BoxMin;
                #endif
                #if UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMax[0] = unity_SpecCube0_BoxMax;
                    d.boxMax[1] = unity_SpecCube1_BoxMax;
                    d.probePosition[0] = unity_SpecCube0_ProbePosition;
                    d.probePosition[1] = unity_SpecCube1_ProbePosition;
                #endif
                d.probeHDR[0] = unity_SpecCube0_HDR;
                d.probeHDR[1] = unity_SpecCube1_HDR;
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
////// Specular:
                float3 specularColor = _SpecularGlossA.rgb;
                float specularMonochrome;
                float2 node_2677 = (node_7049*_ScaleUVclose);
                float4 node_9258 = tex2D(_RockD,TRANSFORM_TEX(node_2677, _RockD)); // Rock Close UV
                float2 node_8928 = (node_351*_ScaleUVclose);
                float4 node_1016 = tex2D(_MossD,TRANSFORM_TEX(node_8928, _MossD)); // Rock Close UV
                float2 node_7015 = (node_7244*_ScaleUVclose);
                float4 node_6842 = tex2D(_RockD,TRANSFORM_TEX(node_7015, _RockD)); // Rock Close UV
                float4 node_7072 = tex2D(_RockD,TRANSFORM_TEX(node_7049, _RockD)); // Rock Far UV
                float4 node_7976 = tex2D(_MossD,TRANSFORM_TEX(node_351, _MossD)); // Rock Far UV
                float4 node_9183 = tex2D(_RockD,TRANSFORM_TEX(node_7244, _RockD)); // Rock Far UV
                float3 diffuseColor = ( lerp((node_837.r*node_9258.rgb + node_837.g*node_1016.rgb + node_837.b*node_6842.rgb),(node_837.r*node_7072.rgb + node_837.g*node_7976.rgb + node_837.b*node_9183.rgb),node_3798) > 0.5 ? (1.0-(1.0-2.0*(lerp((node_837.r*node_9258.rgb + node_837.g*node_1016.rgb + node_837.b*node_6842.rgb),(node_837.r*node_7072.rgb + node_837.g*node_7976.rgb + node_837.b*node_9183.rgb),node_3798)-0.5))*(1.0-_DIffColor.rgb)) : (2.0*lerp((node_837.r*node_9258.rgb + node_837.g*node_1016.rgb + node_837.b*node_6842.rgb),(node_837.r*node_7072.rgb + node_837.g*node_7976.rgb + node_837.b*node_9183.rgb),node_3798)*_DIffColor.rgb) ); // Need this for specular when using metallic
                diffuseColor = EnergyConservationBetweenDiffuseAndSpecular(diffuseColor, specularColor, specularMonochrome);
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = max(0.0,dot( normalDirection, viewDirection ));
                half grazingTerm = saturate( gloss + specularMonochrome );
                float3 indirectSpecular = (gi.indirect.specular);
                indirectSpecular *= FresnelLerp (specularColor, grazingTerm, NdotV);
/////// Diffuse:
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += gi.indirect.diffuse;
                indirectDiffuse *= ( _AOBLEND > 0.5 ? (1.0-(1.0-2.0*(_AOBLEND-0.5))*(1.0-(node_837.r*node_9258.a + node_837.g*node_1016.a + node_837.b*node_7072.a))) : (2.0*_AOBLEND*(node_837.r*node_9258.a + node_837.g*node_1016.a + node_837.b*node_7072.a)) ); // Diffuse AO
                diffuseColor *= 1-specularMonochrome;
/// Final Color:
                outDiffuse = half4( diffuseColor, ( _AOBLEND > 0.5 ? (1.0-(1.0-2.0*(_AOBLEND-0.5))*(1.0-(node_837.r*node_9258.a + node_837.g*node_1016.a + node_837.b*node_7072.a))) : (2.0*_AOBLEND*(node_837.r*node_9258.a + node_837.g*node_1016.a + node_837.b*node_7072.a)) ) );
                outSpecSmoothness = half4( specularColor, gloss );
                outNormal = half4( normalDirection * 0.5 + 0.5, 1 );
                outEmission = half4(0,0,0,1);
                outEmission.rgb += indirectSpecular * 1;
                outEmission.rgb += indirectDiffuse * diffuseColor;
                #ifndef UNITY_HDR_ON
                    outEmission.rgb = exp2(-outEmission.rgb);
                #endif
            }
            ENDCG
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles n3ds wiiu 
            #pragma target 3.0
            uniform sampler2D _RockD; uniform float4 _RockD_ST;
            uniform float4 _SpecularGlossA;
            uniform sampler2D _ROCKN; uniform float4 _ROCKN_ST;
            uniform sampler2D _MossD; uniform float4 _MossD_ST;
            uniform sampler2D _MOSSN; uniform float4 _MOSSN_ST;
            uniform float _ScaleUVclose;
            uniform float _DistanceBlend;
            uniform float _FalloFfBlend;
            uniform float _blendvalue;
            uniform float4 _DIffColor;
            uniform float _AOBLEND;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv1 : TEXCOORD0;
                float2 uv2 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
                float3 normalDir : TEXCOORD3;
                float3 tangentDir : TEXCOORD4;
                float3 bitangentDir : TEXCOORD5;
                LIGHTING_COORDS(6,7)
                UNITY_FOG_COORDS(8)
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD9;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                #ifdef LIGHTMAP_ON
                    o.ambientOrLightmapUV.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
                    o.ambientOrLightmapUV.zw = 0;
                #endif
                #ifdef DYNAMICLIGHTMAP_ON
                    o.ambientOrLightmapUV.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
                #endif
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 node_837 = abs(saturate(( abs((i.normalDir*_blendvalue)) > 0.5 ? (1.0-(1.0-2.0*(abs((i.normalDir*_blendvalue))-0.5))*(1.0-i.normalDir)) : (2.0*abs((i.normalDir*_blendvalue))*i.normalDir) )));
                float2 node_7049 = float2(i.posWorld.g,i.posWorld.b); // YZ projection
                float2 node_6578 = (node_7049*_ScaleUVclose);
                float3 node_5611 = UnpackNormal(tex2D(_ROCKN,TRANSFORM_TEX(node_6578, _ROCKN)));
                float2 node_351 = float2(i.posWorld.b,i.posWorld.r); // ZX projection
                float2 node_4657 = (node_351*_ScaleUVclose);
                float3 node_2179 = UnpackNormal(tex2D(_MOSSN,TRANSFORM_TEX(node_4657, _MOSSN)));
                float2 node_7244 = float2(i.posWorld.r,i.posWorld.g); // Xy projection
                float2 node_584 = (node_7244*_ScaleUVclose);
                float3 node_6961 = UnpackNormal(tex2D(_ROCKN,TRANSFORM_TEX(node_584, _ROCKN)));
                float3 node_4498 = UnpackNormal(tex2D(_ROCKN,TRANSFORM_TEX(node_7049, _ROCKN)));
                float3 node_2481 = UnpackNormal(tex2D(_MOSSN,TRANSFORM_TEX(node_351, _MOSSN)));
                float3 node_4551 = UnpackNormal(tex2D(_ROCKN,TRANSFORM_TEX(node_7244, _ROCKN)));
                float node_3798 = saturate(pow((distance(i.posWorld.rgb,_WorldSpaceCameraPos)/_DistanceBlend),_FalloFfBlend));
                float3 normalLocal = lerp((node_837.r*node_5611.rgb + node_837.g*node_2179.rgb + node_837.b*node_6961.rgb),(node_837.r*node_4498.rgb + node_837.g*node_2481.rgb + node_837.b*node_4551.rgb),node_3798);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = _SpecularGlossA.a;
                float perceptualRoughness = 1.0 - _SpecularGlossA.a;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
                    d.ambient = 0;
                    d.lightmapUV = i.ambientOrLightmapUV;
                #else
                    d.ambient = i.ambientOrLightmapUV;
                #endif
                #if UNITY_SPECCUBE_BLENDING || UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMin[0] = unity_SpecCube0_BoxMin;
                    d.boxMin[1] = unity_SpecCube1_BoxMin;
                #endif
                #if UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMax[0] = unity_SpecCube0_BoxMax;
                    d.boxMax[1] = unity_SpecCube1_BoxMax;
                    d.probePosition[0] = unity_SpecCube0_ProbePosition;
                    d.probePosition[1] = unity_SpecCube1_ProbePosition;
                #endif
                d.probeHDR[0] = unity_SpecCube0_HDR;
                d.probeHDR[1] = unity_SpecCube1_HDR;
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float3 specularColor = _SpecularGlossA.rgb;
                float specularMonochrome;
                float2 node_2677 = (node_7049*_ScaleUVclose);
                float4 node_9258 = tex2D(_RockD,TRANSFORM_TEX(node_2677, _RockD)); // Rock Close UV
                float2 node_8928 = (node_351*_ScaleUVclose);
                float4 node_1016 = tex2D(_MossD,TRANSFORM_TEX(node_8928, _MossD)); // Rock Close UV
                float2 node_7015 = (node_7244*_ScaleUVclose);
                float4 node_6842 = tex2D(_RockD,TRANSFORM_TEX(node_7015, _RockD)); // Rock Close UV
                float4 node_7072 = tex2D(_RockD,TRANSFORM_TEX(node_7049, _RockD)); // Rock Far UV
                float4 node_7976 = tex2D(_MossD,TRANSFORM_TEX(node_351, _MossD)); // Rock Far UV
                float4 node_9183 = tex2D(_RockD,TRANSFORM_TEX(node_7244, _RockD)); // Rock Far UV
                float3 diffuseColor = ( lerp((node_837.r*node_9258.rgb + node_837.g*node_1016.rgb + node_837.b*node_6842.rgb),(node_837.r*node_7072.rgb + node_837.g*node_7976.rgb + node_837.b*node_9183.rgb),node_3798) > 0.5 ? (1.0-(1.0-2.0*(lerp((node_837.r*node_9258.rgb + node_837.g*node_1016.rgb + node_837.b*node_6842.rgb),(node_837.r*node_7072.rgb + node_837.g*node_7976.rgb + node_837.b*node_9183.rgb),node_3798)-0.5))*(1.0-_DIffColor.rgb)) : (2.0*lerp((node_837.r*node_9258.rgb + node_837.g*node_1016.rgb + node_837.b*node_6842.rgb),(node_837.r*node_7072.rgb + node_837.g*node_7976.rgb + node_837.b*node_9183.rgb),node_3798)*_DIffColor.rgb) ); // Need this for specular when using metallic
                diffuseColor = EnergyConservationBetweenDiffuseAndSpecular(diffuseColor, specularColor, specularMonochrome);
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                half surfaceReduction;
                #ifdef UNITY_COLORSPACE_GAMMA
                    surfaceReduction = 1.0-0.28*roughness*perceptualRoughness;
                #else
                    surfaceReduction = 1.0/(roughness*roughness + 1.0);
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                half grazingTerm = saturate( gloss + specularMonochrome );
                float3 indirectSpecular = (gi.indirect.specular);
                indirectSpecular *= FresnelLerp (specularColor, grazingTerm, NdotV);
                indirectSpecular *= surfaceReduction;
                float3 specular = (directSpecular + indirectSpecular);
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += gi.indirect.diffuse;
                indirectDiffuse *= ( _AOBLEND > 0.5 ? (1.0-(1.0-2.0*(_AOBLEND-0.5))*(1.0-(node_837.r*node_9258.a + node_837.g*node_1016.a + node_837.b*node_7072.a))) : (2.0*_AOBLEND*(node_837.r*node_9258.a + node_837.g*node_1016.a + node_837.b*node_7072.a)) ); // Diffuse AO
                diffuseColor *= 1-specularMonochrome;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles n3ds wiiu 
            #pragma target 3.0
            uniform sampler2D _RockD; uniform float4 _RockD_ST;
            uniform float4 _SpecularGlossA;
            uniform sampler2D _ROCKN; uniform float4 _ROCKN_ST;
            uniform sampler2D _MossD; uniform float4 _MossD_ST;
            uniform sampler2D _MOSSN; uniform float4 _MOSSN_ST;
            uniform float _ScaleUVclose;
            uniform float _DistanceBlend;
            uniform float _FalloFfBlend;
            uniform float _blendvalue;
            uniform float4 _DIffColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv1 : TEXCOORD0;
                float2 uv2 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
                float3 normalDir : TEXCOORD3;
                float3 tangentDir : TEXCOORD4;
                float3 bitangentDir : TEXCOORD5;
                LIGHTING_COORDS(6,7)
                UNITY_FOG_COORDS(8)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 node_837 = abs(saturate(( abs((i.normalDir*_blendvalue)) > 0.5 ? (1.0-(1.0-2.0*(abs((i.normalDir*_blendvalue))-0.5))*(1.0-i.normalDir)) : (2.0*abs((i.normalDir*_blendvalue))*i.normalDir) )));
                float2 node_7049 = float2(i.posWorld.g,i.posWorld.b); // YZ projection
                float2 node_6578 = (node_7049*_ScaleUVclose);
                float3 node_5611 = UnpackNormal(tex2D(_ROCKN,TRANSFORM_TEX(node_6578, _ROCKN)));
                float2 node_351 = float2(i.posWorld.b,i.posWorld.r); // ZX projection
                float2 node_4657 = (node_351*_ScaleUVclose);
                float3 node_2179 = UnpackNormal(tex2D(_MOSSN,TRANSFORM_TEX(node_4657, _MOSSN)));
                float2 node_7244 = float2(i.posWorld.r,i.posWorld.g); // Xy projection
                float2 node_584 = (node_7244*_ScaleUVclose);
                float3 node_6961 = UnpackNormal(tex2D(_ROCKN,TRANSFORM_TEX(node_584, _ROCKN)));
                float3 node_4498 = UnpackNormal(tex2D(_ROCKN,TRANSFORM_TEX(node_7049, _ROCKN)));
                float3 node_2481 = UnpackNormal(tex2D(_MOSSN,TRANSFORM_TEX(node_351, _MOSSN)));
                float3 node_4551 = UnpackNormal(tex2D(_ROCKN,TRANSFORM_TEX(node_7244, _ROCKN)));
                float node_3798 = saturate(pow((distance(i.posWorld.rgb,_WorldSpaceCameraPos)/_DistanceBlend),_FalloFfBlend));
                float3 normalLocal = lerp((node_837.r*node_5611.rgb + node_837.g*node_2179.rgb + node_837.b*node_6961.rgb),(node_837.r*node_4498.rgb + node_837.g*node_2481.rgb + node_837.b*node_4551.rgb),node_3798);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = _SpecularGlossA.a;
                float perceptualRoughness = 1.0 - _SpecularGlossA.a;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float3 specularColor = _SpecularGlossA.rgb;
                float specularMonochrome;
                float2 node_2677 = (node_7049*_ScaleUVclose);
                float4 node_9258 = tex2D(_RockD,TRANSFORM_TEX(node_2677, _RockD)); // Rock Close UV
                float2 node_8928 = (node_351*_ScaleUVclose);
                float4 node_1016 = tex2D(_MossD,TRANSFORM_TEX(node_8928, _MossD)); // Rock Close UV
                float2 node_7015 = (node_7244*_ScaleUVclose);
                float4 node_6842 = tex2D(_RockD,TRANSFORM_TEX(node_7015, _RockD)); // Rock Close UV
                float4 node_7072 = tex2D(_RockD,TRANSFORM_TEX(node_7049, _RockD)); // Rock Far UV
                float4 node_7976 = tex2D(_MossD,TRANSFORM_TEX(node_351, _MossD)); // Rock Far UV
                float4 node_9183 = tex2D(_RockD,TRANSFORM_TEX(node_7244, _RockD)); // Rock Far UV
                float3 diffuseColor = ( lerp((node_837.r*node_9258.rgb + node_837.g*node_1016.rgb + node_837.b*node_6842.rgb),(node_837.r*node_7072.rgb + node_837.g*node_7976.rgb + node_837.b*node_9183.rgb),node_3798) > 0.5 ? (1.0-(1.0-2.0*(lerp((node_837.r*node_9258.rgb + node_837.g*node_1016.rgb + node_837.b*node_6842.rgb),(node_837.r*node_7072.rgb + node_837.g*node_7976.rgb + node_837.b*node_9183.rgb),node_3798)-0.5))*(1.0-_DIffColor.rgb)) : (2.0*lerp((node_837.r*node_9258.rgb + node_837.g*node_1016.rgb + node_837.b*node_6842.rgb),(node_837.r*node_7072.rgb + node_837.g*node_7976.rgb + node_837.b*node_9183.rgb),node_3798)*_DIffColor.rgb) ); // Need this for specular when using metallic
                diffuseColor = EnergyConservationBetweenDiffuseAndSpecular(diffuseColor, specularColor, specularMonochrome);
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                diffuseColor *= 1-specularMonochrome;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles n3ds wiiu 
            #pragma target 3.0
            uniform sampler2D _RockD; uniform float4 _RockD_ST;
            uniform float4 _SpecularGlossA;
            uniform sampler2D _MossD; uniform float4 _MossD_ST;
            uniform float _ScaleUVclose;
            uniform float _DistanceBlend;
            uniform float _FalloFfBlend;
            uniform float _blendvalue;
            uniform float4 _DIffColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv1 : TEXCOORD0;
                float2 uv2 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
                float3 normalDir : TEXCOORD3;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                o.Emission = 0;
                
                float3 node_837 = abs(saturate(( abs((i.normalDir*_blendvalue)) > 0.5 ? (1.0-(1.0-2.0*(abs((i.normalDir*_blendvalue))-0.5))*(1.0-i.normalDir)) : (2.0*abs((i.normalDir*_blendvalue))*i.normalDir) )));
                float2 node_7049 = float2(i.posWorld.g,i.posWorld.b); // YZ projection
                float2 node_2677 = (node_7049*_ScaleUVclose);
                float4 node_9258 = tex2D(_RockD,TRANSFORM_TEX(node_2677, _RockD)); // Rock Close UV
                float2 node_351 = float2(i.posWorld.b,i.posWorld.r); // ZX projection
                float2 node_8928 = (node_351*_ScaleUVclose);
                float4 node_1016 = tex2D(_MossD,TRANSFORM_TEX(node_8928, _MossD)); // Rock Close UV
                float2 node_7244 = float2(i.posWorld.r,i.posWorld.g); // Xy projection
                float2 node_7015 = (node_7244*_ScaleUVclose);
                float4 node_6842 = tex2D(_RockD,TRANSFORM_TEX(node_7015, _RockD)); // Rock Close UV
                float4 node_7072 = tex2D(_RockD,TRANSFORM_TEX(node_7049, _RockD)); // Rock Far UV
                float4 node_7976 = tex2D(_MossD,TRANSFORM_TEX(node_351, _MossD)); // Rock Far UV
                float4 node_9183 = tex2D(_RockD,TRANSFORM_TEX(node_7244, _RockD)); // Rock Far UV
                float node_3798 = saturate(pow((distance(i.posWorld.rgb,_WorldSpaceCameraPos)/_DistanceBlend),_FalloFfBlend));
                float3 diffColor = ( lerp((node_837.r*node_9258.rgb + node_837.g*node_1016.rgb + node_837.b*node_6842.rgb),(node_837.r*node_7072.rgb + node_837.g*node_7976.rgb + node_837.b*node_9183.rgb),node_3798) > 0.5 ? (1.0-(1.0-2.0*(lerp((node_837.r*node_9258.rgb + node_837.g*node_1016.rgb + node_837.b*node_6842.rgb),(node_837.r*node_7072.rgb + node_837.g*node_7976.rgb + node_837.b*node_9183.rgb),node_3798)-0.5))*(1.0-_DIffColor.rgb)) : (2.0*lerp((node_837.r*node_9258.rgb + node_837.g*node_1016.rgb + node_837.b*node_6842.rgb),(node_837.r*node_7072.rgb + node_837.g*node_7976.rgb + node_837.b*node_9183.rgb),node_3798)*_DIffColor.rgb) );
                float3 specColor = _SpecularGlossA.rgb;
                float specularMonochrome = max(max(specColor.r, specColor.g),specColor.b);
                diffColor *= (1.0-specularMonochrome);
                float roughness = 1.0 - _SpecularGlossA.a;
                o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
