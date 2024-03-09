uniform float tileSize;
uniform float tileX;
uniform float tileY;

void main()
{
    vec2 uv = (gl_FragCoord.xy - vec2(tileX * tileSize - tileSize, tileY * tileSize - tileSize)) / vec2(tileSize, tileSize);

    vec2 center = vec2(abs(uv.x - 0.5), abs(0.5 - uv.y));

    float distanceX = abs(0.5 - center.x) * 2.0; 
    float distanceY = abs(0.5 - center.y) * 2.0;

    float stepFactor = 0.05;
    float alphaX = smoothstep(0.0, stepFactor, distanceX);
    float alphaY = smoothstep(0.0, stepFactor, distanceY);

    float alpha = min(alphaX, alphaY);
    if (gl_FragCoord.x > tileX * tileSize || gl_FragCoord.y > tileY * tileSize) { alpha = 1.; }
    float frameAlpha = 0.7 * 255;
    gl_FragColor = (vec4(31, 19, 15, frameAlpha) / 255f) * vec4(1.0, 1.0, 1.0, 1.0 - alpha);
}
