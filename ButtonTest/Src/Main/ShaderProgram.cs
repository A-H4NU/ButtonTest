using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.IO;

namespace ButtonTest.Src.Main
{
    internal class ShaderProgram : IDisposable
    {
        private readonly int _program;
        private bool _linked;

        public int Program => this._program;
        public bool Linked => this._linked;

        public Dictionary<ShaderType, int> _shaders;

        public ShaderProgram()
        {
            this._program = GL.CreateProgram();
            this._shaders = new Dictionary<ShaderType, int>();
            this._linked = false;
        }

        public bool AddShader(ShaderType type, string filepath)
        {
            if (this._linked)
            {
                Logger.Warn($"Program {this._program:X} is already linked");
                return false;
            }
            if (!File.Exists(filepath))
            {
                Logger.Error($"Cannot find file: {Path.GetFullPath(filepath)}");
                return false;
            }

            if (this._shaders.TryGetValue(type, out _))
            {
                Logger.Info($"Program {this._program:X} already has {type}");
                return false;
            }

            int shader = GL.CreateShader(type);
            string content = File.ReadAllText(filepath);
            GL.ShaderSource(shader, content);

            GL.CompileShader(shader);
            string info = GL.GetShaderInfoLog(shader);
            if (!String.IsNullOrEmpty(info))
            {
                Logger.Error($"Shader {shader}({type}) has info log:");
                Logger.Error(info);
                return false;
            }

            this._shaders.Add(type, shader);
            return true;
        }

        public bool RemoveShader(ShaderType type)
        {
            if (this._linked)
            {
                Logger.Warn($"Program {this._program:X} is already linked");
                return false;
            }
            return this._shaders.Remove(type);
        }

        public bool Link()
        {
            if (this._linked)
            {
                Logger.Warn($"Program {this._program:X} is already linked");
                return false;
            }

            foreach (int shader in this._shaders.Values)
            {
                GL.AttachShader(this._program, shader);
            }

            GL.LinkProgram(this._program);
            string info = GL.GetProgramInfoLog(this._program);
            if (!String.IsNullOrEmpty(info))
            {
                Logger.Error($"Program {this._program:X} has info log:");
                Logger.Error(info);
            }
            foreach (int shader in this._shaders.Values)
            {
                GL.DetachShader(this._program, shader);
                GL.DeleteShader(shader);
            }

            this._shaders.Clear();
            this._shaders = null;

            this._linked = true;
            return true;
        }

        public void Dispose()
        {
            GL.DeleteProgram(this._program);

            GC.SuppressFinalize(this);
        }
    }
}
