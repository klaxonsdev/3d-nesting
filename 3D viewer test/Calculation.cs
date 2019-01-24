﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuantumConcepts.Formats.StereoLithography;

namespace _3D_viewer
{
    public class Calculation
    {
        float length;
        float width;
        float height;
        float minx = 0, miny = 0, minz = 0, maxx = 0, maxy = 0, maxz = 0;
        public double PrintVolCalc (double length, double width, double heigth)
        {
            return length * width * heigth;
        }
        public float SignedVolumeOfTriangle(Vertex p1, Vertex p2, Vertex p3)
        {
            var v321 = p3.X * p2.Y * p1.Z;
            var v231 = p2.X * p3.Y * p1.Z;
            var v312 = p3.X * p1.Y * p2.Z;
            var v132 = p1.X * p3.Y * p2.Z;
            var v213 = p2.X * p1.Y * p3.Z;
            var v123 = p1.X * p2.Y * p3.Z;
            
            if (Math.Min(Math.Min(p1.X,p2.X),p3.X) < minx)
            {
                minx = Math.Min(Math.Min(p1.X, p2.X), p3.X);
            }
            if (Math.Min(Math.Min(p1.Y, p2.Y), p3.Y) < miny)
            {
                miny = Math.Min(Math.Min(p1.Y, p2.Y), p3.Y);
            }
            if (Math.Min(Math.Min(p1.Z, p2.Z), p3.Z) > minz)
            {
                minz = Math.Min(Math.Min(p1.Z, p2.Z), p3.Z);
            }

            return (1.0f / 6.0f) * (-v321 + v231 + v312 - v132 - v213 + v123);
        }
        public float[] getBoundingBox()
        {
            length = maxx - minx;
            width = maxy - miny;
            height = Math.Abs(maxz - minz);
            return new float[] {length, width, height};
        }
        public float VolumeOfMesh(STLDocument model)
        {
            var vol = 0.0f;
            foreach (var item in model.Facets)
            {
                vol = vol + SignedVolumeOfTriangle(item.Vertices[0], item.Vertices[1], item.Vertices[2]);
            }
            return vol;
        }
    }
}
