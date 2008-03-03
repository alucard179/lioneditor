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
    public class JOINLZW : BasePSXSectionedFile
    {
        protected override int NumberOfSections { get { return 5; } }

        private static Dictionary<string, long> locations;
        public override IDictionary<string, long> Locations
        {
            get
            {
                if( locations == null )
                {
                    locations = new Dictionary<string, long>();
                    locations.Add( "EVENT/JOIN.LZW", 0x00 );
                    locations.Add( "EVENT/REQUIRE.OUT", 0xCE70 );
                }

                return locations;
            }
        }

        private static string[] sectionNames = new string[5];

        private static string[][] entryNames;

        public override IList<string> SectionNames { get { return sectionNames; } }
        public override IList<IList<string>> EntryNames { get { return entryNames; } }
        public override int MaxLength { get { return 0x41F6; } }

        static JOINLZW()
        {
            entryNames = new string[5][];
            entryNames[0] = new string[1];
            entryNames[1] = new string[172];
            entryNames[2] = new string[172];
            entryNames[3] = new string[172];
            entryNames[4] = new string[155];
        }

        public JOINLZW( IList<byte> bytes )
            : base( bytes )
        {
        }
    }
}