#version 450 core

layout (location = 0) in vec4 position;
layout (location = 1) in vec4 color;

layout (location = 20) uniform mat4 modelview;
layout (location = 21) uniform mat4 projection;

out vec4 vt_color;

void main() {
	gl_Position = modelview * projection * position;
	vt_color = color;
}