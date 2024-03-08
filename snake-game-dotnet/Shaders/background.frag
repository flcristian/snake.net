uniform float windowWidth;
uniform float windowHeight;
uniform float time;

void main()
{
    vec2 uv = gl_FragCoord.xy / vec2(windowWidth, windowHeight);

    float angleRad = radians(time * 2);

    float s = sin(angleRad);
    float c = cos(angleRad);

    float movement = dot(uv, vec2(c, s));

    float wave = sin(time * 5 + movement * 10.0);

    float mixFactor = (wave + 1.0) / 2.0;
    mixFactor *= 1.0 + (int(time) % 10 / 10) / 3;

    vec3 darkGreen = vec3(48, 117, 33) / 255f;
    vec3 lightGreen = vec3(79, 153, 47) / 255f;
    vec3 color = mix(lightGreen, darkGreen, mixFactor);

    gl_FragColor = vec4(color, 1.0);
}
