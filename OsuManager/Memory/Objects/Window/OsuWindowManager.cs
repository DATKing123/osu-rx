﻿using System;
using System.Numerics;

namespace osu.Memory.Objects.Window
{
    public class OsuWindowManager
    {
        public OsuViewport Viewport { get; private set; }

        public Vector2 WindowSize => new Vector2(Viewport.Width, Viewport.Height);

        //TODO: this is letterboxing position, not the actual window position
        public Vector2 WindowPosition => new Vector2(Viewport.X, Viewport.Y);

        public float WindowRatio => WindowSize.Y / 480;

        public Vector2 PlayfieldSize
        {
            get
            {
                float width = 512 * WindowRatio;
                float height = 384 * WindowRatio;

                return new Vector2(width, height);
            }
        }

        public Vector2 PlayfieldPosition //topleft origin
        {
            get
            {
                var windowCentre = WindowSize / 2;
                float x = windowCentre.X - PlayfieldSize.X / 2;
                float y = windowCentre.Y - PlayfieldSize.Y / 2;

                return new Vector2(x, y);
            }
        }

        public float PlayfieldRatio => PlayfieldSize.Y / 384;

        public OsuWindowManager(UIntPtr viewportPointer)
        {
            Viewport = new OsuViewport(viewportPointer);
        }
    }
}