// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:3,spmd:0,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:True,rprd:True,enco:False,rmgx:True,imps:True,rpth:1,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.3452325,fgcg:0.4399742,fgcb:0.500631,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:5936,x:33266,y:32750,varname:node_5936,prsc:2|diff-6547-OUT,spec-520-OUT,gloss-1127-OUT,normal-7536-OUT,difocc-867-OUT;n:type:ShaderForge.SFN_NormalVector,id:9990,x:30813,y:32742,prsc:2,pt:True;n:type:ShaderForge.SFN_ComponentMask,id:183,x:31044,y:32753,varname:node_183,prsc:2,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-9990-OUT;n:type:ShaderForge.SFN_Clamp01,id:6185,x:31227,y:32764,varname:node_6185,prsc:2|IN-183-OUT;n:type:ShaderForge.SFN_Round,id:6242,x:31512,y:32776,varname:node_6242,prsc:2|IN-6185-OUT;n:type:ShaderForge.SFN_Tex2d,id:1911,x:32032,y:32143,varname:node_1911,prsc:2,tex:186750c4b963061419998c9e4f70b73d,ntxv:0,isnm:False|TEX-903-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:903,x:31702,y:31854,ptovrint:False,ptlb:DiffuseRock,ptin:_DiffuseRock,varname:node_903,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:186750c4b963061419998c9e4f70b73d,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2dAsset,id:5308,x:31314,y:32007,ptovrint:False,ptlb:DiffuseMoss,ptin:_DiffuseMoss,varname:node_5308,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:441e7d835e626b54e89d674d8ffb15cd,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:8603,x:31748,y:32230,varname:node_8603,prsc:2,tex:441e7d835e626b54e89d674d8ffb15cd,ntxv:0,isnm:False|TEX-5308-TEX;n:type:ShaderForge.SFN_Lerp,id:6547,x:32359,y:32558,varname:node_6547,prsc:2|A-5712-OUT,B-2520-OUT,T-6242-OUT;n:type:ShaderForge.SFN_NormalVector,id:7409,x:31023,y:33093,prsc:2,pt:False;n:type:ShaderForge.SFN_ComponentMask,id:7965,x:31252,y:33098,varname:node_7965,prsc:2,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-7409-OUT;n:type:ShaderForge.SFN_Clamp01,id:2655,x:31444,y:33107,varname:node_2655,prsc:2|IN-7965-OUT;n:type:ShaderForge.SFN_Round,id:8423,x:31715,y:33099,varname:node_8423,prsc:2|IN-2655-OUT;n:type:ShaderForge.SFN_Lerp,id:7536,x:32362,y:33150,varname:node_7536,prsc:2|A-1125-OUT,B-2533-RGB,T-8423-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:1200,x:31420,y:33292,ptovrint:False,ptlb:NormalRock,ptin:_NormalRock,varname:node_1200,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:79d9b67d92116c44f8e90d21d59a879f,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2dAsset,id:5425,x:31726,y:33675,ptovrint:False,ptlb:NormalMoss,ptin:_NormalMoss,varname:node_5425,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:f274fcdb3d6760c49813fe377f09561b,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:910,x:31638,y:33312,varname:node_910,prsc:2,tex:79d9b67d92116c44f8e90d21d59a879f,ntxv:0,isnm:False|TEX-1200-TEX;n:type:ShaderForge.SFN_Tex2d,id:2533,x:31947,y:33673,varname:node_2533,prsc:2,tex:f274fcdb3d6760c49813fe377f09561b,ntxv:0,isnm:False|TEX-5425-TEX;n:type:ShaderForge.SFN_Lerp,id:1127,x:32333,y:32719,varname:node_1127,prsc:2|A-415-OUT,B-6447-OUT,T-6242-OUT;n:type:ShaderForge.SFN_Lerp,id:520,x:32368,y:33003,varname:node_520,prsc:2|A-5338-RGB,B-5946-RGB,T-6242-OUT;n:type:ShaderForge.SFN_Color,id:5338,x:32009,y:32842,ptovrint:False,ptlb:SpecularRock,ptin:_SpecularRock,varname:node_5338,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Color,id:5946,x:32045,y:33011,ptovrint:False,ptlb:SpecularMoss,ptin:_SpecularMoss,varname:node_5946,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Tex2d,id:2479,x:31546,y:32324,ptovrint:False,ptlb:AoRock,ptin:_AoRock,varname:node_2479,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:9637,x:31609,y:32497,ptovrint:False,ptlb:AoGrass,ptin:_AoGrass,varname:node_9637,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Lerp,id:867,x:32034,y:32466,varname:node_867,prsc:2|A-2479-G,B-9637-R,T-6242-OUT;n:type:ShaderForge.SFN_Tex2d,id:8086,x:32703,y:32137,varname:node_8086,prsc:2,ntxv:0,isnm:False|TEX-2866-TEX;n:type:ShaderForge.SFN_Tex2d,id:2534,x:31644,y:33493,varname:node_2534,prsc:2,ntxv:0,isnm:False|TEX-1399-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:2866,x:32478,y:32011,ptovrint:False,ptlb:DiffuseDetail,ptin:_DiffuseDetail,varname:node_2866,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Blend,id:5712,x:32953,y:32294,varname:node_5712,prsc:2,blmd:10,clmp:True|SRC-8086-RGB,DST-1911-RGB;n:type:ShaderForge.SFN_Tex2dAsset,id:1399,x:31241,y:33493,ptovrint:False,ptlb:NormalDetail,ptin:_NormalDetail,varname:node_1399,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_NormalBlend,id:1125,x:31944,y:33425,varname:node_1125,prsc:2|BSE-910-RGB,DTL-2534-RGB;n:type:ShaderForge.SFN_Color,id:8619,x:31639,y:32084,ptovrint:False,ptlb:GrassColor,ptin:_GrassColor,varname:node_8619,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Blend,id:2482,x:32030,y:32288,varname:node_2482,prsc:2,blmd:10,clmp:True|SRC-8603-RGB,DST-8619-RGB;n:type:ShaderForge.SFN_Blend,id:2520,x:32531,y:32287,varname:node_2520,prsc:2,blmd:10,clmp:True|SRC-8086-R,DST-2482-OUT;n:type:ShaderForge.SFN_Blend,id:6447,x:32280,y:32241,varname:node_6447,prsc:2,blmd:1,clmp:True|SRC-8603-A,DST-5338-A;n:type:ShaderForge.SFN_Blend,id:415,x:32281,y:32073,varname:node_415,prsc:2,blmd:1,clmp:True|SRC-1911-A,DST-5946-A;proporder:903-5308-1200-5425-5338-5946-2866-1399-2479-9637-8619;pass:END;sub:END;*/

Shader "Custom/Rock_Moss_Direction" {
    Properties {
        _DiffuseRock ("DiffuseRock", 2D) = "white" {}
        _DiffuseMoss ("DiffuseMoss", 2D) = "white" {}
        _NormalRock ("NormalRock", 2D) = "bump" {}
        _NormalMoss ("NormalMoss", 2D) = "bump" {}
        _SpecularRock ("SpecularRock", Color) = (0.5,0.5,0.5,1)
        _SpecularMoss ("SpecularMoss", Color) = (0.5,0.5,0.5,1)
        _DiffuseDetail ("DiffuseDetail", 2D) = "white" {}
        _NormalDetail ("NormalDetail", 2D) = "bump" {}
        _AoRock ("AoRock", 2D) = "white" {}
        _AoGrass ("AoGrass", 2D) = "white" {}
        _GrassColor ("GrassColor", Color) = (0.5,0.5,0.5,1)
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
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _DiffuseRock; uniform float4 _DiffuseRock_ST;
            uniform sampler2D _DiffuseMoss; uniform float4 _DiffuseMoss_ST;
            uniform sampler2D _NormalRock; uniform float4 _NormalRock_ST;
            uniform sampler2D _NormalMoss; uniform float4 _NormalMoss_ST;
            uniform float4 _SpecularRock;
            uniform float4 _SpecularMoss;
            uniform sampler2D _AoRock; uniform float4 _AoRock_ST;
            uniform sampler2D _AoGrass; uniform float4 _AoGrass_ST;
            uniform sampler2D _DiffuseDetail; uniform float4 _DiffuseDetail_ST;
            uniform sampler2D _NormalDetail; uniform float4 _NormalDetail_ST;
            uniform float4 _GrassColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD7;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
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
                float3 node_910 = UnpackNormal(tex2D(_NormalRock,TRANSFORM_TEX(i.uv0, _NormalRock)));
                float3 node_2534 = UnpackNormal(tex2D(_NormalDetail,TRANSFORM_TEX(i.uv0, _NormalDetail)));
                float3 node_1125_nrm_base = node_910.rgb + float3(0,0,1);
                float3 node_1125_nrm_detail = node_2534.rgb * float3(-1,-1,1);
                float3 node_1125_nrm_combined = node_1125_nrm_base*dot(node_1125_nrm_base, node_1125_nrm_detail)/node_1125_nrm_base.z - node_1125_nrm_detail;
                float3 node_1125 = node_1125_nrm_combined;
                float3 node_2533 = UnpackNormal(tex2D(_NormalMoss,TRANSFORM_TEX(i.uv0, _NormalMoss)));
                float3 normalLocal = lerp(node_1125,node_2533.rgb,round(saturate(i.normalDir.g)));
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
////// Lighting:
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float4 node_1911 = tex2D(_DiffuseRock,TRANSFORM_TEX(i.uv0, _DiffuseRock));
                float4 node_8603 = tex2D(_DiffuseMoss,TRANSFORM_TEX(i.uv0, _DiffuseMoss));
                float node_6242 = round(saturate(normalDirection.g));
                float gloss = lerp(saturate((node_1911.a*_SpecularMoss.a)),saturate((node_8603.a*_SpecularRock.a)),node_6242);
                float perceptualRoughness = 1.0 - lerp(saturate((node_1911.a*_SpecularMoss.a)),saturate((node_8603.a*_SpecularRock.a)),node_6242);
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
                float3 specularColor = lerp(_SpecularRock.rgb,_SpecularMoss.rgb,node_6242);
                float specularMonochrome;
                float4 node_8086 = tex2D(_DiffuseDetail,TRANSFORM_TEX(i.uv0, _DiffuseDetail));
                float3 diffuseColor = lerp(saturate(( node_1911.rgb > 0.5 ? (1.0-(1.0-2.0*(node_1911.rgb-0.5))*(1.0-node_8086.rgb)) : (2.0*node_1911.rgb*node_8086.rgb) )),saturate(( saturate(( _GrassColor.rgb > 0.5 ? (1.0-(1.0-2.0*(_GrassColor.rgb-0.5))*(1.0-node_8603.rgb)) : (2.0*_GrassColor.rgb*node_8603.rgb) )) > 0.5 ? (1.0-(1.0-2.0*(saturate(( _GrassColor.rgb > 0.5 ? (1.0-(1.0-2.0*(_GrassColor.rgb-0.5))*(1.0-node_8603.rgb)) : (2.0*_GrassColor.rgb*node_8603.rgb) ))-0.5))*(1.0-node_8086.r)) : (2.0*saturate(( _GrassColor.rgb > 0.5 ? (1.0-(1.0-2.0*(_GrassColor.rgb-0.5))*(1.0-node_8603.rgb)) : (2.0*_GrassColor.rgb*node_8603.rgb) ))*node_8086.r) )),node_6242); // Need this for specular when using metallic
                diffuseColor = EnergyConservationBetweenDiffuseAndSpecular(diffuseColor, specularColor, specularMonochrome);
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = max(0.0,dot( normalDirection, viewDirection ));
                half grazingTerm = saturate( gloss + specularMonochrome );
                float3 indirectSpecular = (gi.indirect.specular);
                indirectSpecular *= FresnelLerp (specularColor, grazingTerm, NdotV);
/////// Diffuse:
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += gi.indirect.diffuse;
                float4 _AoRock_var = tex2D(_AoRock,TRANSFORM_TEX(i.uv0, _AoRock));
                float4 _AoGrass_var = tex2D(_AoGrass,TRANSFORM_TEX(i.uv0, _AoGrass));
                indirectDiffuse *= lerp(_AoRock_var.g,_AoGrass_var.r,node_6242); // Diffuse AO
                diffuseColor *= 1-specularMonochrome;
/// Final Color:
                outDiffuse = half4( diffuseColor, lerp(_AoRock_var.g,_AoGrass_var.r,node_6242) );
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
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _DiffuseRock; uniform float4 _DiffuseRock_ST;
            uniform sampler2D _DiffuseMoss; uniform float4 _DiffuseMoss_ST;
            uniform sampler2D _NormalRock; uniform float4 _NormalRock_ST;
            uniform sampler2D _NormalMoss; uniform float4 _NormalMoss_ST;
            uniform float4 _SpecularRock;
            uniform float4 _SpecularMoss;
            uniform sampler2D _AoRock; uniform float4 _AoRock_ST;
            uniform sampler2D _AoGrass; uniform float4 _AoGrass_ST;
            uniform sampler2D _DiffuseDetail; uniform float4 _DiffuseDetail_ST;
            uniform sampler2D _NormalDetail; uniform float4 _NormalDetail_ST;
            uniform float4 _GrassColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD10;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
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
                float3 node_910 = UnpackNormal(tex2D(_NormalRock,TRANSFORM_TEX(i.uv0, _NormalRock)));
                float3 node_2534 = UnpackNormal(tex2D(_NormalDetail,TRANSFORM_TEX(i.uv0, _NormalDetail)));
                float3 node_1125_nrm_base = node_910.rgb + float3(0,0,1);
                float3 node_1125_nrm_detail = node_2534.rgb * float3(-1,-1,1);
                float3 node_1125_nrm_combined = node_1125_nrm_base*dot(node_1125_nrm_base, node_1125_nrm_detail)/node_1125_nrm_base.z - node_1125_nrm_detail;
                float3 node_1125 = node_1125_nrm_combined;
                float3 node_2533 = UnpackNormal(tex2D(_NormalMoss,TRANSFORM_TEX(i.uv0, _NormalMoss)));
                float3 normalLocal = lerp(node_1125,node_2533.rgb,round(saturate(i.normalDir.g)));
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
                float4 node_1911 = tex2D(_DiffuseRock,TRANSFORM_TEX(i.uv0, _DiffuseRock));
                float4 node_8603 = tex2D(_DiffuseMoss,TRANSFORM_TEX(i.uv0, _DiffuseMoss));
                float node_6242 = round(saturate(normalDirection.g));
                float gloss = lerp(saturate((node_1911.a*_SpecularMoss.a)),saturate((node_8603.a*_SpecularRock.a)),node_6242);
                float perceptualRoughness = 1.0 - lerp(saturate((node_1911.a*_SpecularMoss.a)),saturate((node_8603.a*_SpecularRock.a)),node_6242);
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
                float3 specularColor = lerp(_SpecularRock.rgb,_SpecularMoss.rgb,node_6242);
                float specularMonochrome;
                float4 node_8086 = tex2D(_DiffuseDetail,TRANSFORM_TEX(i.uv0, _DiffuseDetail));
                float3 diffuseColor = lerp(saturate(( node_1911.rgb > 0.5 ? (1.0-(1.0-2.0*(node_1911.rgb-0.5))*(1.0-node_8086.rgb)) : (2.0*node_1911.rgb*node_8086.rgb) )),saturate(( saturate(( _GrassColor.rgb > 0.5 ? (1.0-(1.0-2.0*(_GrassColor.rgb-0.5))*(1.0-node_8603.rgb)) : (2.0*_GrassColor.rgb*node_8603.rgb) )) > 0.5 ? (1.0-(1.0-2.0*(saturate(( _GrassColor.rgb > 0.5 ? (1.0-(1.0-2.0*(_GrassColor.rgb-0.5))*(1.0-node_8603.rgb)) : (2.0*_GrassColor.rgb*node_8603.rgb) ))-0.5))*(1.0-node_8086.r)) : (2.0*saturate(( _GrassColor.rgb > 0.5 ? (1.0-(1.0-2.0*(_GrassColor.rgb-0.5))*(1.0-node_8603.rgb)) : (2.0*_GrassColor.rgb*node_8603.rgb) ))*node_8086.r) )),node_6242); // Need this for specular when using metallic
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
                float4 _AoRock_var = tex2D(_AoRock,TRANSFORM_TEX(i.uv0, _AoRock));
                float4 _AoGrass_var = tex2D(_AoGrass,TRANSFORM_TEX(i.uv0, _AoGrass));
                indirectDiffuse *= lerp(_AoRock_var.g,_AoGrass_var.r,node_6242); // Diffuse AO
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
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _DiffuseRock; uniform float4 _DiffuseRock_ST;
            uniform sampler2D _DiffuseMoss; uniform float4 _DiffuseMoss_ST;
            uniform sampler2D _NormalRock; uniform float4 _NormalRock_ST;
            uniform sampler2D _NormalMoss; uniform float4 _NormalMoss_ST;
            uniform float4 _SpecularRock;
            uniform float4 _SpecularMoss;
            uniform sampler2D _DiffuseDetail; uniform float4 _DiffuseDetail_ST;
            uniform sampler2D _NormalDetail; uniform float4 _NormalDetail_ST;
            uniform float4 _GrassColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
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
                float3 node_910 = UnpackNormal(tex2D(_NormalRock,TRANSFORM_TEX(i.uv0, _NormalRock)));
                float3 node_2534 = UnpackNormal(tex2D(_NormalDetail,TRANSFORM_TEX(i.uv0, _NormalDetail)));
                float3 node_1125_nrm_base = node_910.rgb + float3(0,0,1);
                float3 node_1125_nrm_detail = node_2534.rgb * float3(-1,-1,1);
                float3 node_1125_nrm_combined = node_1125_nrm_base*dot(node_1125_nrm_base, node_1125_nrm_detail)/node_1125_nrm_base.z - node_1125_nrm_detail;
                float3 node_1125 = node_1125_nrm_combined;
                float3 node_2533 = UnpackNormal(tex2D(_NormalMoss,TRANSFORM_TEX(i.uv0, _NormalMoss)));
                float3 normalLocal = lerp(node_1125,node_2533.rgb,round(saturate(i.normalDir.g)));
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
                float4 node_1911 = tex2D(_DiffuseRock,TRANSFORM_TEX(i.uv0, _DiffuseRock));
                float4 node_8603 = tex2D(_DiffuseMoss,TRANSFORM_TEX(i.uv0, _DiffuseMoss));
                float node_6242 = round(saturate(normalDirection.g));
                float gloss = lerp(saturate((node_1911.a*_SpecularMoss.a)),saturate((node_8603.a*_SpecularRock.a)),node_6242);
                float perceptualRoughness = 1.0 - lerp(saturate((node_1911.a*_SpecularMoss.a)),saturate((node_8603.a*_SpecularRock.a)),node_6242);
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float3 specularColor = lerp(_SpecularRock.rgb,_SpecularMoss.rgb,node_6242);
                float specularMonochrome;
                float4 node_8086 = tex2D(_DiffuseDetail,TRANSFORM_TEX(i.uv0, _DiffuseDetail));
                float3 diffuseColor = lerp(saturate(( node_1911.rgb > 0.5 ? (1.0-(1.0-2.0*(node_1911.rgb-0.5))*(1.0-node_8086.rgb)) : (2.0*node_1911.rgb*node_8086.rgb) )),saturate(( saturate(( _GrassColor.rgb > 0.5 ? (1.0-(1.0-2.0*(_GrassColor.rgb-0.5))*(1.0-node_8603.rgb)) : (2.0*_GrassColor.rgb*node_8603.rgb) )) > 0.5 ? (1.0-(1.0-2.0*(saturate(( _GrassColor.rgb > 0.5 ? (1.0-(1.0-2.0*(_GrassColor.rgb-0.5))*(1.0-node_8603.rgb)) : (2.0*_GrassColor.rgb*node_8603.rgb) ))-0.5))*(1.0-node_8086.r)) : (2.0*saturate(( _GrassColor.rgb > 0.5 ? (1.0-(1.0-2.0*(_GrassColor.rgb-0.5))*(1.0-node_8603.rgb)) : (2.0*_GrassColor.rgb*node_8603.rgb) ))*node_8086.r) )),node_6242); // Need this for specular when using metallic
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
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _DiffuseRock; uniform float4 _DiffuseRock_ST;
            uniform sampler2D _DiffuseMoss; uniform float4 _DiffuseMoss_ST;
            uniform float4 _SpecularRock;
            uniform float4 _SpecularMoss;
            uniform sampler2D _DiffuseDetail; uniform float4 _DiffuseDetail_ST;
            uniform float4 _GrassColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
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
                
                float4 node_8086 = tex2D(_DiffuseDetail,TRANSFORM_TEX(i.uv0, _DiffuseDetail));
                float4 node_1911 = tex2D(_DiffuseRock,TRANSFORM_TEX(i.uv0, _DiffuseRock));
                float4 node_8603 = tex2D(_DiffuseMoss,TRANSFORM_TEX(i.uv0, _DiffuseMoss));
                float node_6242 = round(saturate(normalDirection.g));
                float3 diffColor = lerp(saturate(( node_1911.rgb > 0.5 ? (1.0-(1.0-2.0*(node_1911.rgb-0.5))*(1.0-node_8086.rgb)) : (2.0*node_1911.rgb*node_8086.rgb) )),saturate(( saturate(( _GrassColor.rgb > 0.5 ? (1.0-(1.0-2.0*(_GrassColor.rgb-0.5))*(1.0-node_8603.rgb)) : (2.0*_GrassColor.rgb*node_8603.rgb) )) > 0.5 ? (1.0-(1.0-2.0*(saturate(( _GrassColor.rgb > 0.5 ? (1.0-(1.0-2.0*(_GrassColor.rgb-0.5))*(1.0-node_8603.rgb)) : (2.0*_GrassColor.rgb*node_8603.rgb) ))-0.5))*(1.0-node_8086.r)) : (2.0*saturate(( _GrassColor.rgb > 0.5 ? (1.0-(1.0-2.0*(_GrassColor.rgb-0.5))*(1.0-node_8603.rgb)) : (2.0*_GrassColor.rgb*node_8603.rgb) ))*node_8086.r) )),node_6242);
                float3 specColor = lerp(_SpecularRock.rgb,_SpecularMoss.rgb,node_6242);
                float specularMonochrome = max(max(specColor.r, specColor.g),specColor.b);
                diffColor *= (1.0-specularMonochrome);
                float roughness = 1.0 - lerp(saturate((node_1911.a*_SpecularMoss.a)),saturate((node_8603.a*_SpecularRock.a)),node_6242);
                o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
