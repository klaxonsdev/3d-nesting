using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using g3;

namespace _3D_viewer
{
    class MeshDecimator
    {
        DMesh3 dMesh3 = new DMesh3();

        public void MeshReducer(string path, int outtriangle)
        {
            dMesh3 = StandardMeshReader.ReadMesh(path);
            Reducer reducer = new Reducer(dMesh3);
            reducer.ReduceToTriangleCount(outtriangle);
            dMesh3 = reducer.Mesh;
            string newpath = path.Insert(path.Length-4,"Reduced");
            IOWriteResult iOWrite = StandardMeshWriter.WriteFile(newpath, new List<WriteMesh> { new WriteMesh(dMesh3) }, WriteOptions.Defaults);
        }
    }
}
