uniform float windowWidth;
uniform float windowHeight;
uniform float time;

void main()
{
    vec2 uv = gl_FragCoord.xy / vec2(windowWidth, windowHeight);

    float speed = 2.0;
    float angleRad = radians(time * speed);

    float s = sin(angleRad);
    float c = cos(angleRad);

    float movement = dot(uv, vec2(c, s));


    float wave = sin(time * speed + movement * 10.0);

    float mixFactor = (wave + 1.0) / 2.0;
    mixFactor *= 1.0 + (int(time) % 10 / 10) / 3;

    vec3 color1 = vec3(48, 117, 33) / 255f;
    vec3 color2 = vec3(79, 153, 47) / 255f;
    /*vec3 color1 = vec3(224, 58, 58) / 255f;
    vec3 color2 = vec3(32, 212, 173) / 255f;*/
    vec3 color = mix(color1, color2, mixFactor);

    gl_FragColor = vec4(color, 1.0);
}
