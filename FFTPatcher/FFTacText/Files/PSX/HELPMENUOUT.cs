﻿/*
    Copyright 2007, Joe Davidson <joedavidson@gmail.com>

    This file is part of FFTPatcher.

    FFTPatcher is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    FFTPatcher is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with FFTPatcher.  If not, see <http://www.gnu.org/licenses/>.
*/

using System.Collections.Generic;

namespace FFTPatcher.TextEditor.Files.PSX
{
    public class HELPMENUOUT : BasePSXCompressedFile
    {

		#region Static Fields (3) 

        public static string[][] entryNames;
        private static Dictionary<string, long> locations;
        private static string[] sectionNames;

		#endregion Static Fields 

		#region Fields (2) 

        private const string filename = "HELPMENU.OUT";
        private const int numberOfSections = 21;

		#endregion Fields 

		#region Properties (6) 


        protected override int NumberOfSections { get { return numberOfSections; } }

        public override IList<IList<string>> EntryNames { get { return entryNames; } }

        public override string Filename { get { return filename; } }

        public override IDictionary<string, long> Locations
        {
            get
            {
                if( locations == null )
                {
                    locations = new Dictionary<string, long>();
                    locations.Add( "EVENT/HELPMENU.OUT", 0x1B30 );
                    locations.Add( "WORLD/WORLD.BIN", 0x777E0 );
                }

                return locations;
            }
        }

        public override int MaxLength { get { return 0x169C0; } }

        public override IList<string> SectionNames { get { return sectionNames; } }


		#endregion Properties 

		#region Constructors (3) 

        private HELPMENUOUT()
        {
        }

        static HELPMENUOUT()
        {
            sectionNames = new string[21];
            entryNames = new string[numberOfSections][];

            for( int i = 0; i < entryNames.Length; i++ )
            {
                entryNames[i] = new string[2048];
            }
        }

        public HELPMENUOUT( IList<byte> bytes )
        {
            Sections = new List<IList<string>>( NumberOfSections );
            for( int i = 0; i < NumberOfSections; i++ )
            {
                uint start = Utilities.BytesToUInt32( bytes.Sub( i * 4, i * 4 + 3 ) );
                uint stop = Utilities.BytesToUInt32( bytes.Sub( (i + 1) * 4, (i + 1) * 4 + 3 ) ) - 1;
                if( i == NumberOfSections - 1 )
                {
                    stop = (uint)bytes.Count - 1 - dataStart;
                }

                IList<byte> thisSection = TextUtilities.Decompress(
                    bytes,
                    bytes.Sub( (int)(start + dataStart), (int)(stop + dataStart) ),
                    (int)(start + dataStart) );
                Sections.Add( TextUtilities.ProcessList( thisSection, CharMap ) );
            }
        }

		#endregion Constructors 

		#region Methods (1) 


        protected override IList<byte> ToFinalBytes()
        {
            return Compress();
        }


		#endregion Methods 

    }
}