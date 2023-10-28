Shader "2D Custom/Dissolve"
{
	Properties
	{
		_MainTex ("Sprite Texture", 2D) = "white" {}
		
		[Space(10)]
		_DissolveValue("Dissolve Value", Range(0,1)) = 0.0

		[Space(10)]
	    _DissolveTex ("Dissolve Texture", 2D) = "white" { }
		_DissolveOffset ("Disolve Offset", Range(0, 1)) = 0.0
		_DissolveScale ("Disolve Scale", Range(0, 50)) = 1.0

		[Space(10)]
		_Color ("Tint", Color) = (1,1,1,1)

		[Space(10)]
		_InnerColor ("Dissolve Inner Color", Color) = (1, 1, 1, 1)
  		_DissolveInnerLength("Dissolve Inner Length",Range(0,1)) = 0.05

		[Space(10)]
		_OuterColor ("Dissolve Outer Color", Color) = (0, 0, 0, 1)
		_DissolveOuterLength("Dissolve Outer Length",Range(0,1)) = 0.025
	}

	SubShader
	{
		Tags
		{ 
			"Queue" = "Transparent" 
			"IgnoreProjector" = "True" 
			"RenderType" = "Transparent" 
			"PreviewType" = "Plane"
			"CanUseSpriteAtlas" = "True"
		}

		Cull Off
		Lighting Off
		ZWrite Off
		Fog { Mode Off }
		Blend One OneMinusSrcAlpha

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			
			struct appdata
			{
				float4 vertex   : POSITION;
				fixed4 color    : COLOR;
				float2 uv_MainTex : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex   : SV_POSITION;
				fixed4 color    : COLOR;
				float2 uv_MainTex  : TEXCOORD0;
				float2 uv_DissolveTex : TEXCOORD1;
			};
			
			fixed4 _Color;

			v2f vert(appdata IN)
			{
				v2f OUT;
				UNITY_INITIALIZE_OUTPUT(v2f,OUT)
				OUT.vertex = UnityObjectToClipPos(IN.vertex);
				OUT.uv_MainTex = IN.uv_MainTex;
				OUT.uv_DissolveTex = UnityWorldToClipPos(IN.vertex);
				OUT.color = IN.color * _Color;
				return OUT;
			}

			sampler2D _DissolveTex;
			float4 _InnerColor, _OuterColor;
			float _DissolveInnerLength, _DissolveOuterLength, _DissolveValue, _DissolveOffset, _DissolveScale;
			sampler2D _MainTex;

			fixed4 frag(v2f IN) : SV_Target
			{
				fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
				c.rgb *= c.a;
				half dissolve = tex2D(_DissolveTex, IN.uv_DissolveTex * _DissolveScale + _DissolveOffset).r;
				
				if(dissolve - _DissolveInnerLength < _DissolveValue)
				{
					c = _InnerColor * c.a;
				}
				if(dissolve < _DissolveValue + _DissolveOuterLength)
				{
					c = _OuterColor * c.a;
				}
				if(dissolve < _DissolveValue)
				{
					c.a = 0.0;
				}					
				return c * c.a;
			}
			ENDCG
		}
	}
}
