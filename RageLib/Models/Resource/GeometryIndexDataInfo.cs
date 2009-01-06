/**********************************************************************\

 RageLib
 Copyright (C) 2008  Arushan/Aru <oneforaru at gmail.com>

 This program is free software: you can redistribute it and/or modify
 it under the terms of the GNU General Public License as published by
 the Free Software Foundation, either version 3 of the License, or
 (at your option) any later version.

 This program is distributed in the hope that it will be useful,
 but WITHOUT ANY WARRANTY; without even the implied warranty of
 MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 GNU General Public License for more details.

 You should have received a copy of the GNU General Public License
 along with this program.  If not, see <http://www.gnu.org/licenses/>.

\**********************************************************************/

using System.IO;
using RageLib.Common;
using RageLib.Common.Resources;

namespace RageLib.Models.Resource
{
    // grcIndexBufferD3D 
    internal class GeometryIndexDataInfo : IFileAccess
    {
        private uint VTable { get; set; }
        public uint IndexCount { get; private set; }
        public uint DataOffset { get; private set; }

        public ushort[] IndexData { get; private set; }

        public GeometryIndexDataInfo()
        {
        }

        public GeometryIndexDataInfo(BinaryReader br)
        {
            Read(br);
        }

        public void ReadData(BinaryReader br)
        {
            br.BaseStream.Seek(DataOffset, SeekOrigin.Begin);

            IndexData = new ushort[IndexCount];
            for(int i=0; i<IndexCount; i++)
            {
                IndexData[i] = br.ReadUInt16();
            }
        }

        #region Implementation of IFileAccess

        public void Read(BinaryReader br)
        {
            VTable = br.ReadUInt32();
            IndexCount = br.ReadUInt32();

            DataOffset = ResourceUtil.ReadDataOffset(br);

            var p1Offset = ResourceUtil.ReadOffset(br);
        }

        public void Write(BinaryWriter bw)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}