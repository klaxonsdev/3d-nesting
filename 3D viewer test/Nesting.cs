using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CromulentBisgetti.ContainerPacking;
using CromulentBisgetti.ContainerPacking.Entities;
using CromulentBisgetti.ContainerPacking.Algorithms;

namespace _3D_viewer
{
    class Nesting
    {
        public List<ContainerPackingResult> Nesting3D(List<Container> container, List<Item> itemtopack)
        {
            List<int> algorithms = new List<int>();
            algorithms.Add((int)AlgorithmType.EB_AFIT);
            List<ContainerPackingResult> results = PackingService.Pack(container, itemtopack, algorithms);
            return results;
        }
    }
}
